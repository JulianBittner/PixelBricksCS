using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay.Bricks
{
  internal class BrickBody
  {
    private BrickShape[] _shapes;

    public BrickBody(BrickShape[] shapes) {
      if (shapes.Length != Count) {
        throw new ArgumentException(
          $"A brick body needs exactly {Count} shapes, but got {shapes.Length}.",
          nameof(shapes));
      }
      _shapes = shapes;
    }
    public BrickShape this[int r] => _shapes[r];
    public static int Count => 4;
    public int Height => _shapes[0].Height;
    public int Width => _shapes[0].Width;
  }
}
