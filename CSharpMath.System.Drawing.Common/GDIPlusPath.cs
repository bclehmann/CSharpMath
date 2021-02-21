using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CSharpMath.System.Drawing.Common {
  public class GDIPlusPath : Rendering.FrontEnd.Path {
    private readonly GDIPlusCanvas owner;
    private readonly global::System.Drawing.Drawing2D.GraphicsPath path = new global::System.Drawing.Drawing2D.GraphicsPath();
    private PointF location = new PointF(0, 0);

    public GDIPlusPath(GDIPlusCanvas owner) => this.owner = owner;

    public override Color? Foreground { get; set; }

    public override void CloseContour() => path.CloseFigure();
    public override void Curve3(float x1, float y1, float x2, float y2) {
      path.AddCurve(new PointF[] { new PointF(x1, y1), new PointF(x2, y2) });
      location = path.GetLastPoint();
    }

    public override void Curve4(float x1, float y1, float x2, float y2, float x3, float y3) {
      path.AddCurve(new PointF[] { new PointF(x1, y1), new PointF(x2, y2), new PointF(x3, y3) });
      location = path.GetLastPoint();
    }
    public override void Dispose() {
      Color color = Foreground ?? owner.CurrentColor ?? owner.DefaultColor;

      using Pen pen = new Pen(color);
      using (Graphics graphics = Graphics.FromImage(owner.Image)) {
        graphics.SmoothingMode = GetSmoothingMode();
        graphics.DrawPath(pen, path);
      }

      path.Dispose();
    }
    public override void LineTo(float x1, float y1) {
      path.AddLine(location, new PointF(x1, y1));
      location = path.GetLastPoint();
    }
    public override void MoveTo(float x0, float y0) => location = new PointF(x0, y0);
  }
}
