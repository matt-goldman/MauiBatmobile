namespace Batcave.Controls;

public class RpmGauge : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeSize = 4;
        
        //canvas.StrokeColor = Colors.Red;
        var path = new PathF();
        path.MoveTo(155, 155);
        path.LineTo(305, 155);
        path.LineTo(305, 155);
        path.CurveTo(new PointF(305, 155), new PointF(305, 140), new PointF(290, 90));
        path.LineTo(155, 155);
        path.Close();

        //canvas.DrawPath(path);

        canvas.FillColor = Colors.Red;

        canvas.FillPath(path);

        canvas.StrokeColor = Colors.Black;
        canvas.DrawArc(5, 5, 300, 300, 0, 180, false, false);
    }    
}
