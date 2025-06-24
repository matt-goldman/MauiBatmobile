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
        var degrees = 90 - (Rpm / rpmDegrees);

        if (degrees > 90)
            degrees -= 90;

        var radians = degrees * Math.PI / 180;

        var sin = Math.Sin(radians);
        var cos = Math.Cos(radians);

        // adjacent = x
        var x = sin * pointerLength;

        // opposite = y
        var y = cos * pointerLength;

        float endX;
        float endY = 155 - (float)y;

        if (Rpm < 7500)
        {
            endX = 155 - (float)x;
        }
        else
        {
            endX = 155 + (float)Math.Abs(x);
        }

        MathCheck.Text = $"Receiving Batmobile Telemetry::: Rpm: {Rpm}; deg: {degrees}; sin: {sin}; Cos: {cos}; Adj: {x}; opp: {y}; endX: {endX}; endY: {endY}";

        Pointer.Drawable = new Pointer(endX, endY);
    }
}