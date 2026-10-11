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

          // Wall collision
          if (boardPosition.X >= gameBoard.Width || boardPosition.X < 0) return true;
          // Pixel collision
          if (gameBoard[boardPosition.Y, boardPosition.X] != BrickID.None) return true;
        }
      }
      return false;
    }

    public static BrickPreview TryWallkick(GameBoard gameBoard, BrickPreview preview) {
      BrickPreview wallkick = preview.WithPositionOffset(0, -1);

      if (Collides(gameBoard, wallkick)) wallkick = preview.WithPositionOffset(0, +1);
      else return wallkick;

      if (Collides(gameBoard, wallkick)) wallkick = preview.WithPositionOffset(0, -2);
      else return wallkick;

      if (Collides(gameBoard, wallkick)) wallkick = preview.WithPositionOffset(0, +2);
      else return wallkick;

      if (Collides(gameBoard, wallkick)) return preview;
      else return wallkick;
    }
  }
}
