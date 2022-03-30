namespace Batmobile.Controls;

public partial class Throttle : ContentView
{
    public static BindableProperty RpmProperty = BindableProperty.Create(nameof(Rpm), typeof(int), typeof(Throttle), null);
    public int Rpm
    {
        get { return (int)GetValue(RpmProperty); }
        set { SetValue(RpmProperty, value); }
    }

    public Throttle()
	{
		InitializeComponent();
	}

    private void ThrottlePanUpdated(object sender, PanUpdatedEventArgs e)
    {
        if (e.TotalY > 0 && e.TotalY < 300 && IsEnabled)
        {
            handle.TranslationY = e.TotalY;

            // Total RPM will be a fraction of 15,000 (max)
            // TotalY will be a number between 0 and 300
            // Set Rpm to TotalY * 50 to give the fraction of
            // max RPM set by this translation
            Rpm = (int)e.TotalY * 50;
        }

        if (e.StatusType == GestureStatus.Completed || e.StatusType == GestureStatus.Canceled)
            Rpm = 0;
    }
}