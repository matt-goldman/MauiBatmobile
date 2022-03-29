using CommunityToolkit.Mvvm.ComponentModel;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using MauiBatmobile;

namespace BatShared.Clients;

public class RpmClient : ObservableObject
{
    bool _ignition = false;
    public bool IgnitionOn
    {
        get => _ignition;
        set
        {
            _ignition = value;
            OnPropertyChanged();
            if (_ignition)
            {
                Task.Run(async () => await SendRpm());
            }
            else
            {
                Rpm = 0;
            }
        }
    }

    bool _computerOn;
    public bool IsComputerOn
    {
        get => _computerOn;
        set
        {
            _computerOn = value;
            if (_computerOn)
            {
                Task.Run(async () => await GetRpm());
            }
        }
    }

    int _rpm;
    public int Rpm
    {
        get => _rpm;
        set
        {
            _rpm = value;
            OnPropertyChanged();
        }
    }

    Rpm.RpmClient rpmClient;

    string batRelayAddress = "http://localhost:5007";

    public RpmClient()
    {
        var channel = GrpcChannel.ForAddress(batRelayAddress);

        rpmClient = new Rpm.RpmClient(channel);
    }

    async Task SendRpm()
    {
        using (var call = rpmClient.SendRpm())
        {
            do
            {
                var request = new LogRequest { Rpm = _rpm };

                await call.RequestStream.WriteAsync(request);

                await Task.Delay(100);

            } while (_ignition);

            await call.RequestStream.CompleteAsync();
        }
    }

    async Task GetRpm()
    {
        using (var call = rpmClient.GetRpm(new Empty()))
        {
            await foreach (var request in call.ResponseStream.ReadAllAsync())
            {
                if (!_computerOn)
                {
                    return;
                }

                Rpm = request.Rpm;
            }
        }
    }
}
