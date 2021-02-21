using System;
using CSharpMath.Rendering.FrontEnd;
using System.Drawing;
using System.Collections.Generic;
using CSharpMath.System.Drawing.Common.GraphicsCommands;

namespace CSharpMath.System.Drawing.Common {
  public sealed class GDIPlusCanvas : ICanvas {
    public global::System.Drawing.Image Image { get; }
    public bool AntialiasingEnabled = true;

    internal global::System.Drawing.Drawing2D.SmoothingMode GetSmoothingMode() {
      if (AntialiasingEnabled)
        return global::System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

      return global::System.Drawing.Drawing2D.SmoothingMode.None;
    }

    private readonly Queue<IGraphicsCommand> drawQueue = new Queue<IGraphicsCommand>();



    public GDIPlusCanvas(global::System.Drawing.Image image, bool antialiasingEnabled) {
      Image = image;
      AntialiasingEnabled = antialiasingEnabled;
    }

    public float Width => Image.Width;

    public float Height => Image.Height;

    public Color DefaultColor { get; set; }
    public Color? CurrentColor { get; set; }
    public PaintStyle CurrentStyle { get; set; }

    public void DrawLine(float x1, float y1, float x2, float y2, float lineThickness) => drawQueue.Enqueue(new DrawLineCommand(x1, y1, x2, y2, CurrentColor ?? DefaultColor, lineThickness));
    public void FillRect(float left, float top, float width, float height) => drawQueue.Enqueue(new RectangleCommand(left, top, width, height, CurrentColor ?? DefaultColor, DrawAction.Fill));

    public void Restore() => drawQueue.Clear();

    public void Save() {
      using (Graphics graphics = Graphics.FromImage(Image)) {
        graphics.SmoothingMode = GetSmoothingMode();

        while (drawQueue.Count > 0) {
          drawQueue.Dequeue().FlushChanges(graphics);
        }
      }
    }

    public void Scale(float sx, float sy) => drawQueue.Enqueue(new ScaleCommand(sx, sy));
    public Path StartNewPath() => new GDIPlusPath(this);
    public void StrokeRect(float left, float top, float width, float height) => drawQueue.Enqueue(new RectangleCommand(left, top, width, height, CurrentColor ?? DefaultColor, DrawAction.Stroke));
    public void Translate(float dx, float dy) => throw new NotImplementedException();
  }
}
