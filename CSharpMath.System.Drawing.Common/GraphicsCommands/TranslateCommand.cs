using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CSharpMath.System.Drawing.Common.GraphicsCommands {
  class TranslateCommand : IGraphicsCommand {
    private readonly float dx;
    private readonly float dy;

    public TranslateCommand(float dx, float dy) {
      this.dx = dx;
      this.dy = dy;
    }
    public void FlushChanges(Graphics graphics) => graphics.TranslateTransform(dx, dy);
  }
}
