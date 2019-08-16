using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CSharpMath.Editor {
  using Structures;
  public struct CaretHandle {
    public CaretHandle(float fontSize, PointF midPoint) {
      var scale = fontSize / CaretHandle.CaretFontSize;
      this = new CaretHandle {
        Color = new Color(0, 0, 0, 153),
        Width = CaretHandleWidth * scale,
        Height = CaretHandleHeight * scale,
        Position = new PointF(
          -(CaretHandle.CaretHandleWidth - CaretHandle.CaretWidth) * scale / 2,
          (CaretHandle.CaretHeight + CaretHandle.CaretHandleDescent) * scale
        ).Plus(midPoint)
      };

    }

    public static readonly TimeSpan InitialBlinkDelay = TimeSpan.FromSeconds(0.7);
    public static readonly TimeSpan BlinkRate = TimeSpan.FromSeconds(0.5);
    // The settings below make sense for the given font size. They are scaled appropriately when the fontsize changes.
    public const float CaretFontSize = 30;
    public const int CaretAscent = 25;  // How much should te caret be above the baseline
    public const int CaretWidth = 3;
    public const int CaretDescent = 7;  // How much should the caret be below the baseline
    public const int CaretHandleWidth = 15;
    public const int CaretHandleDescent = 8;
    public const int CaretHandleHeight = 20;
    public const int CaretHandleHitAreaSize = 44;

    public const int CaretHeight = CaretAscent + CaretDescent;

    public Color Color { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public PointF Position { get; set; }
  }
}