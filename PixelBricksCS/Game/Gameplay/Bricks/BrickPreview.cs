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
  }
}
