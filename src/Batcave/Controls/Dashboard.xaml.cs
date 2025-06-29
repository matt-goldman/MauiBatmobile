namespace Batcave.Controls;

public partial class Dashboard : ContentView
{
	public static BindableProperty RpmProperty = BindableProperty.Create(
        nameof(Rpm),
        typeof(int),
        typeof(Dashboard),
        0,
        propertyChanged: RpmChanged);
    public int Rpm
    {
        get => (int)GetValue(RpmProperty);
        set => SetValue(RpmProperty, value);
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
    private const float rpmDegrees = 84;

    // hypotenuse
    private const float pointerLength = 125;

    static void RpmChanged(BindableObject prop, object oldVal, object newVal)
    {
        var dash = (Dashboard)prop;
        dash.DrawPointer();
    }

    public void DrawPointer()
    {
        // theta
        float degrees;

        // Rpm is 0 to 15,000
        // 0 to 180 degrees
        // 0 to 7500 is 0 to 90 degrees (opposite on the left side of the gauge)
        // 7500 to 15,000 is 90 to 180 degrees (opposite on the right side of the gauge)
        if (Rpm >= 7500)
        {
            degrees = 180 - (Rpm / rpmDegrees);
        }
        else
        {
            degrees = Rpm / rpmDegrees;
        }

        // Annoyingly, even though Sin and Cos are formally defined
        // with degrees, the BCL expects us to provide radians to
        // the functions in hte Math namespace.
        var radians = degrees * Math.PI / 180;

        var sin = Math.Sin(radians);
        var cos = Math.Cos(radians);

        // opposite = y
        var y = sin * pointerLength;

        // adjacent = x
        var x = cos * pointerLength;

        // We'll have to determine whether to add or subtract
        // this to the pointer origin based on RPM
        float endX;

        // Y doesn't invert based on RPM so we can just calculate it
        var endY = 155 - (float)y;

        if (Rpm < 7500)
        {
            // if RPM is less than 7500, x will be on the left
            // side of the gauge
            endX = 155 - (float)x;
        }
        else
        {
            // if RPM is greater than 7500, x will be on the
            // right side of the gauge
            endX = 155 + (float)Math.Abs(x);
        }

        MathCheck.Text = $"Receiving Batmobile Telemetry::: Rpm: {Rpm}; deg: {degrees}; sin: {sin}; Cos: {cos}; Adj: {x}; opp: {y}; endX: {endX}; endY: {endY}";

        Pointer.Drawable = new Pointer(endX, endY);
    }
}
