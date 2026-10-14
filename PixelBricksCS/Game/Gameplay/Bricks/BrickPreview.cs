using PixelBricksCS.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay.Bricks
{
  internal record struct BrickPreview(
    BrickShape Shape,
    GridPosition Position,
    BrickRotation Rotation)
  {
    public BrickPreview WithPositionOffset(int y, int x) {
      GridPosition offsetPosition = new GridPosition(Position.Y + y, Position.X + x);
      return new BrickPreview(Shape, offsetPosition, Rotation);
    }
  }
}
