using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CSharpMath.System.Drawing.Common.GraphicsCommands {
  public class RectangleCommand : IGraphicsCommand {
    private readonly Color color;
    private readonly float left;
    private readonly float top;
    private readonly float width;
    private readonly float height;
    private readonly DrawAction drawAction;
    public RectangleCommand(float left, float top, float width, float height, Color color, DrawAction drawAction) {
      this.left = left;
      this.top = top;
      this.width = width;
      this.height = height;
      this.color = color;
      this.drawAction = drawAction;
    }

    public void FlushChanges(Graphics graphics) {
      switch (drawAction) {
        case DrawAction.Fill:
          using (SolidBrush brush = new SolidBrush(color))
            graphics.FillRectangle(brush, left, top, width, height);
            break;
        case DrawAction.Stroke:
          using (Pen pen= new Pen(color))
            graphics.DrawRectangle(pen, left, top, width, height);
          break;
      }

    }
  }
}
