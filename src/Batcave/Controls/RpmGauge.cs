namespace Batcave.Controls;

public class RpmGauge : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeSize = 4;

        canvas.StrokeColor = Colors.Red;
        var path = new PathF();
        path.MoveTo(0, 100);
        path.LineTo(200, 100);
        path.Close();

        canvas.DrawPath(path);

        var bluePath = new PathF();
        canvas.StrokeColor = Colors.Blue;
        bluePath.MoveTo(100, 105);
        bluePath.LineTo(200, 105);
        bluePath.LineTo(200, 105);
        bluePath.Close();

        canvas.DrawPath(bluePath); 

        canvas.StrokeColor = Colors.Black;
        canvas.DrawArc(0, 0, 200, 200, 0, 180, false, false);        
    }
}
