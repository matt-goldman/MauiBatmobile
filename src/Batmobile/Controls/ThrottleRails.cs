namespace Batmobile.Controls;

public class ThrottleRails : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 2;

        var path = new PathF();

        path.MoveTo(60, 40);

        path.LineTo(60, 410);

        path.LineTo(70, 410);

        path.LineTo(70, 40);

        path.Close();

        canvas.DrawPath(path);


        path.MoveTo(430, 40);

        path.LineTo(430, 410);

        path.LineTo(440, 410);

        path.LineTo(440, 40);

        path.Close();

        canvas.DrawPath(path);
    }
}
