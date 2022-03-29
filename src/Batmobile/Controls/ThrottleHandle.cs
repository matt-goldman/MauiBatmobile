namespace Batmobile.Controls;

public class ThrottleHandle : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 4;

        var path = new PathF();

        path.MoveTo(10, 10);        
        path.AddArc(450, 10, 450, 100, 70, 110, true);        
        path.LineTo(10, 100);
        path.AddArc(10, 100, 10, 10, 110, 70, true);
        path.Close();

        canvas.DrawPath(path);
        canvas.SetShadow(new SizeF(10, -10), 4, Colors.Grey);

    }
}
