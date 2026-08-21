using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Core
{
  internal readonly record struct GridPosition(int Y, int X)
  {
    public GridPosition WithOffset(int offsetY, int offsetX) {
      return new GridPosition(Y + offsetY, X + offsetX);
    }
  }
}
