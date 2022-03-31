namespace Batcave.Controls;

public partial class Dashboard : ContentView
{
	public static BindableProperty RpmProperty = BindableProperty.Create(nameof(Rpm), typeof(int), typeof(Dashboard), null, propertyChanged: RpmChanged);
    public int Rpm
    {
        get { return (int)GetValue(RpmProperty); }
        set 
        { 
            SetValue(RpmProperty, value);
        }
    }

    public Dashboard()
	{
		InitializeComponent();
        Pointer.Drawable = new Pointer();
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

    static void RpmChanged(BindableObject prop, object oldVal, object newVal)
    {
        var dash = (Dashboard)prop;
        dash.DrawPointer();
    }

    public void DrawPointer()
    {
        // theta
        var degrees = Rpm / rpmDegrees;

        var sin = Math.Sin(degrees);
        var cos = Math.Cos(degrees);

        // adjacent = x
        var x = sin * pointerLength;

        // opposite = y
        var y = cos * pointerLength;

        float endX;
        float endY = (float)y;

        if (Rpm < 7500)
        {
            endX = 155 - (float)x;
        }
        else
        {
            endX = 155 + (float)x;
        }

        Pointer.Drawable = new Pointer(endX, endY);
    }
}