namespace Batcave.Controls;

public class Pointer : IDrawable
{
    public float endX { get; set; } = 155;
    public float endY { get; set; } = 30;

    public Pointer()
    {

    }

    public Pointer(float x, float y)
    {
        endX = x;
        endY = y;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeSize = 8;

        canvas.StrokeColor = Colors.Black;

        canvas.StrokeLineCap = LineCap.Round;

        canvas.DrawLine(155, 155, endX, endY);
    }
}
