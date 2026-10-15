using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Game.Gameplay.Actions;
using PixelBricksCS.Game.Gameplay.Bricks;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay.GameMechanics
{
  internal static class GameMechanicUtils
  {
    public static bool Collides(GameBoard gameBoard, BrickPreview preview) {
      for (int y = 0; y < preview.Shape.Height; y++) {
        for (int x = 0; x < preview.Shape.Width; x++) {
          BrickID pixel = preview.Shape[y, x];
          if (pixel == BrickID.None) continue;
          GridPosition pixelPosition = new(y + preview.Position.Y, x + preview.Position.X);

          // Ceiling collision
          if (pixelPosition.Y < 0) return true;
          // Wall collision
          if (pixelPosition.X < 0 || pixelPosition.X >= gameBoard.Width) return true;
          // Pixel collision
          if (gameBoard[pixelPosition.Y, pixelPosition.X] != BrickID.None) return true;
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

    public static HashSet<GridPosition> FindContactPixels(GameBoard gameBoard, Brick brick) {
      HashSet<GridPosition> contacts = new();
      BrickShape shape = brick.Shape;

      for (int y = 0; y < shape.Height; y++) {
        for (int x = 0; x < shape.Width; x++) {
          BrickID pixel = shape[y, x];
          if (pixel == BrickID.None) continue;

          GridPosition boardPosition = new (brick.Position.Y + y, brick.Position.X + x);
          if (gameBoard.GetIDAt(boardPosition.WithOffset( 0, -1)) != BrickID.None)
            contacts.Add(boardPosition.WithOffset(0, -1));

          if (gameBoard.GetIDAt(boardPosition.WithOffset( 0, +1)) != BrickID.None)
            contacts.Add(boardPosition.WithOffset(0, +1));

          if (gameBoard.GetIDAt(boardPosition.WithOffset(-1,  0)) != BrickID.None)
            contacts.Add(boardPosition.WithOffset(-1, 0));

          if (gameBoard.GetIDAt(boardPosition.WithOffset(+1,  0)) != BrickID.None)
            contacts.Add(boardPosition.WithOffset(+1, 0));
        }
      }
      return contacts;
    }

    public static ImpactResult DeterminBlastArea(
      GameBoard gameBoard, Brick brick, HashSet<GridPosition> contactPixels) 
    {
      throw new NotImplementedException("Not yet implemented");
      return new ImpactResult(new(), 0, 0);
    }

    public static bool CeilingReachedBottom(GameBoard gameBoard) {
      throw new NotImplementedException("Not yet implemented");
    }
  }
}
