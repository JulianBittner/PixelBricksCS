using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay.Bricks
{
  internal class BrickShape
  {
    private readonly BrickID[,] _cells;

    public BrickShape(BrickID[,] shape) {
      _cells = shape;
    }

    public BrickID this[int y, int x] => _cells [y, x];
    public int Height => _cells.GetLength (0);
    public int Width => _cells.GetLength (1); 
  }
}
