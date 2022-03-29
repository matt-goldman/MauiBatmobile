using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace MauiBatmobile.Services;

public class RpmService : Rpm.RpmBase
{
    public override async Task<LogResponse> SendRpm(IAsyncStreamReader<LogRequest> requestStream, ServerCallContext context)
    {
        await foreach (var request in requestStream.ReadAllAsync())
        {
            Values.LatestRpm = request.Rpm;
            Console.WriteLine($"Batmobile RPM: {Values.LatestRpm}");
        }

        Console.WriteLine("Batmobile connection terminated");

        return new LogResponse { ResponseMessage = "Slow down master Bruce! " };
    }

    public override async Task GetRpm(Empty _, IServerStreamWriter<LogRequest> serverStream, ServerCallContext context)
    {
        while(!context.CancellationToken.IsCancellationRequested)
        {
            await Task.Delay(100);

            Console.WriteLine($"Sending RPM count to Batcave: {Values.LatestRpm}");

            await serverStream.WriteAsync(new LogRequest { Rpm = Values.LatestRpm });
        }

        Console.WriteLine("Batcave connection terminated");
    }
}
