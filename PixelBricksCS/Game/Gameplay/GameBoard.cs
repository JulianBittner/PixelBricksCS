using PixelBricksCS.Engine.Composing;
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
