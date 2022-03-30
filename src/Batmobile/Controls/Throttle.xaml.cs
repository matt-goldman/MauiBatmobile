namespace Batmobile.Controls;

public partial class Throttle : ContentView
{
	public Throttle()
	{
		InitializeComponent();
	}

    private void ThrottlePanUpdated(object sender, PanUpdatedEventArgs e)
    {
        if (e.TotalY > 0 && e.TotalY < 300)
            handle.TranslationY = e.TotalY;
    }
}