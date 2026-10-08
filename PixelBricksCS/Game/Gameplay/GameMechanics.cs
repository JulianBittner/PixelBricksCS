using PixelBricksCS.Engine.Core;
using PixelBricksCS.Game.Gameplay.Bricks;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay
{
  internal static class GameMechanics
  {
    public static bool Collides(GameBoard gameBoard, BrickPreview preview) {
      for (int y = 0; y < preview.Shape.Height; y++) {
        for (int x = 0; x < preview.Shape.Width; x++) {
          BrickID pixel = preview.Shape[y, x];
          if (pixel == BrickID.None) continue;
          GridPosition boardPosition = new(y + preview.Position.Y, x + preview.Position.X);

          // Right wall collision
          if (boardPosition.X >= gameBoard.Width || boardPosition.X < 0) return true;
          // Pixel collision
          if (gameBoard[boardPosition.Y, boardPosition.X] != BrickID.None) return true;
        }
      }
      return false;
    }
  }
}
