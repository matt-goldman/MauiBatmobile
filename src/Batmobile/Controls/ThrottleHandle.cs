namespace Batmobile.Controls;

public class ThrottleHandle : IDrawable
{
    private static readonly LinearGradientPaint Gradient = new LinearGradientPaint
    {
        StartColor = Color.FromRgb(103, 103, 103),
        EndColor = Color.FromHsv(226, 18, 100),
        StartPoint = new Point(0.5, 1),
        EndPoint = new Point(0.5, 0)
    };
    
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 5;

        var path = new PathF();

        path.MoveTo(50, 50);
        path.LineTo(450, 50);
        path.CurveTo(new PointF(470, 50), new PointF(470, 100), new PointF(450, 100));
        path.LineTo(50, 100);
        path.CurveTo(new PointF(30, 100), new PointF(30, 50), new PointF(50, 50));
        path.Close();

        var fillRect = new RectF(30, 50, 440, 50);
        canvas.SetFillPaint(Gradient, fillRect);
        
        canvas.ClipPath(path);
        canvas.FillRoundedRectangle(fillRect, 12);

        //canvas.FillPath(path);

        canvas.DrawPath(path);

        //canvas.ClipPath(path);
        canvas.SetShadow(new SizeF(10, -10), 4, Colors.Grey);

    }
}
