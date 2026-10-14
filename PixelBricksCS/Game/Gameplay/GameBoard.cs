using PixelBricksCS.Engine.Composing;
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

    public void SpawnCeilingRaw() {
      throw new NotImplementedException("Not yet implemented");
    }

    public void MergeBrick(Brick brick) {
      throw new NotImplementedException("Not yet implemented");
    }

    public void ApplyBlast(ImpactResult impactResult) {
      throw new NotImplementedException("Not yet implemented");
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
