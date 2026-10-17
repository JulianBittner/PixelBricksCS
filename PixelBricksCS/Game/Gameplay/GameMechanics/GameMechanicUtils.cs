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

          // Roof collision
          if (pixelPosition.Y < 0) return true;
          // Wall collision
          if (pixelPosition.X < 0 || pixelPosition.X >= gameBoard.Width) return true;
          // Ceiling collision
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

    public static ImpactResult ImpactAnalysis(GameBoard gameBoard, Brick brick) {
      HashSet<GridPosition> contactPixels = new();
      int contacts = 0;

      BrickShape shape = brick.Shape;

      for (int y = 0; y < shape.Height; y++) {
        for (int x = 0; x < shape.Width; x++) {
          BrickID pixel = shape[y, x];
          if (pixel == BrickID.None) continue;

          GridPosition boardPosition = new (brick.Position.Y + y, brick.Position.X + x);
          if (gameBoard.GetIDAt(boardPosition.WithOffset(0, -1)) != BrickID.None) {
            contactPixels.Add(boardPosition.WithOffset(0, -1));
            contacts++;
          }

          if (gameBoard.GetIDAt(boardPosition.WithOffset(0, +1)) != BrickID.None) {
            contactPixels.Add(boardPosition.WithOffset(0, +1));
            contacts++;
          }

          if (gameBoard.GetIDAt(boardPosition.WithOffset(-1, 0)) != BrickID.None) {
            contactPixels.Add(boardPosition.WithOffset(-1, 0));
            contacts++;
          }

          if (gameBoard.GetIDAt(boardPosition.WithOffset(+1, 0)) != BrickID.None) {
            contactPixels.Add(boardPosition.WithOffset(+1, 0));
            contacts++;
          }
        }
      }

      int range = 0;
      if      (contacts >= GameMetadata.MegaBlastThreshold) range = 3;
      else if (contacts >=  GameMetadata.BigBlastThreshold) range = 2;
      else if (contacts >=     GameMetadata.BlastThreshold) range = 1;

      return new(contactPixels, contacts, range);
    }

    public static ImpactResult DeterminBlastArea(GameBoard gameBoard, ImpactResult impactResult) 
    {
      // blastArea[0] -> blast pixels
      // blastArea[1] -> bigBlast pixels
      // blastArea[2] -> MegaBlast pixels
      HashSet<GridPosition>[] blastLayers = [impactResult.AffectedPixels, new(), new()];

      for (int i = 1; i < impactResult.Range; i++) {
        foreach (GridPosition pixel in blastLayers[i-1]) {
          if (gameBoard.GetIDAt(pixel.WithOffset(0, -1)) != BrickID.None)
            blastLayers[i].Add(pixel.WithOffset(0, -1));

          if (gameBoard.GetIDAt(pixel.WithOffset(0, +1)) != BrickID.None)
            blastLayers[i].Add(pixel.WithOffset(0, +1));
         
          if (gameBoard.GetIDAt(pixel.WithOffset(-1, 0)) != BrickID.None)
            blastLayers[i].Add(pixel.WithOffset(-1, 0));         

          if (gameBoard.GetIDAt(pixel.WithOffset(+1, 0)) != BrickID.None)
            blastLayers[i].Add(pixel.WithOffset(+1, 0));
        }
      }
      HashSet<GridPosition> blastArea = new(blastLayers[0]);
      blastArea.UnionWith(blastLayers[1]);
      blastArea.UnionWith(blastLayers[2]);

      return new ImpactResult(blastArea, impactResult.Contacts, impactResult.Range);
    }

    public static bool CeilingReachedBottom(GameBoard gameBoard) {
      int y = gameBoard.Height -1;
      for (int x = 0; x < gameBoard.Width; x++) {
        if (gameBoard[y, x] != BrickID.None) return true;
      }
      return false;
    }
  }
}
