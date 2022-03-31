using System.Diagnostics;

namespace Batcave.Controls;

public partial class Dashboard : ContentView
{
	public static BindableProperty RpmProperty = BindableProperty.Create(nameof(Rpm), typeof(int), typeof(Dashboard), null);
    public int Rpm
    {
        get { return (int)GetValue(RpmProperty); }
        set 
        { 
            SetValue(RpmProperty, value);
            DrawPointer(value);
        }
    }

    public Dashboard()
	{
		InitializeComponent();
        //Pointer.Drawable = new Pointer();
	}

    /*
     * Max RPM is 15,000
     * Degrees in the guage is 180
     * 15,000 / 180 = 83.333
     * 1 degree = 84 RPM
     */
    private float rpmDegrees = 84;

    // hypotenuse
    private float pointerLength = 125;

    public void DrawPointer(int rpm)
    {
        // theta
        var degrees = rpm / rpmDegrees;

        var sin = Math.Sin(degrees);
        var cos = Math.Cos(degrees);

        // adjacent = x
        var x = sin * pointerLength;

        // opposite = y
        var y = cos * pointerLength;

        float endX;
        float endY = (float)y;

        if (rpm < 7500)
        {
            endX = 155 - (float)x;
        }
        else
        {
            endX = 155 + (float)x;
        }

        Debug.WriteLine($"Drawing line to {endX}, {endY}");

        Pointer.Drawable = new Pointer(endX, endY);
    }
}