using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CSharpMath.System.Drawing.Common.GraphicsCommands {
  public class ScaleCommand : IGraphicsCommand {
    private readonly float sx;
    private readonly float sy;

    public ScaleCommand(float sx, float sy) {
      this.sx = sx;
      this.sy = sy;
    }


    public void FlushChanges(Graphics graphics) => graphics.ScaleTransform(sx, sy);
  }
}
