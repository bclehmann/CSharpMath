using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CSharpMath.System.Drawing.Common.GraphicsCommands {
  public class DrawLineCommand : IGraphicsCommand {
    private readonly Color color;
    private readonly float x1;
    private readonly float y1;
    private readonly float x2;
    private readonly float y2;
    private readonly float lineThickness;

    public DrawLineCommand(float x1, float y1, float x2, float y2, Color color, float lineThickness) {
      this.x1 = x1;
      this.y1 = y1;
      this.x2 = x2;
      this.y2 = y2;
      this.color = color;
      this.lineThickness = lineThickness;
    }

    public void FlushChanges(Graphics graphics) {
      using (Pen pen = new Pen(color, lineThickness))
        graphics.DrawLine(pen, x1, y1, x2, y2);
    }
  }
}
