using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Game.Gameplay.Bricks;
using PixelBricksCS.Game.Gameplay.GameMechanics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay
{
  internal class GameBoard : ITileMap<BrickID> {
    BrickID[,] _grid;

    public GameBoard() {
      _grid = new BrickID[Height, Width];
    }

    public int Height => GameMetadata.BoardHeight;
    public int Width => GameMetadata.BoardWidth;

    public BrickID this[int y, int x] => _grid[y, x];

    public BrickID GetIDAt(GridPosition position) {
      if (position.Y >= Height || position.Y < 0) return BrickID.None;
      if (position.X >= Width  || position.X < 0) return BrickID.None;
      return _grid[position.Y, position.X];
    }

    public void SpawnCeilingRaw() {
      throw new NotImplementedException("Not yet implemented");
    }

    public void MergeBrick(Brick brick) {
      BrickShape shape = brick.Shape;

      for (int y = 0; y < shape.Height; y++) {
        for (int x = 0; x < shape.Width; x++) {
          BrickID pixel = shape[y, x];
          if (pixel == BrickID.None) continue;

          GridPosition boardPosition = new(brick.Position.Y +y, brick.Position.X +x);
          _grid[boardPosition.Y, boardPosition.X] = pixel;
        }
      }
    }

    public void ApplyBlast(ImpactResult impactResult) {
      foreach (var pixel in impactResult.AffectedPixels) {
        _grid[pixel.Y, pixel.X] = BrickID.None;
      }
    }

    public void Reset() {
      for (int y = 0; y < Height; y++) {
        for (int x = 0; x < Width; x++) {
          if (y + x % 2 == 0)
            _grid[y, x] = BrickID.None;
        }
      }
    }
  }
}
