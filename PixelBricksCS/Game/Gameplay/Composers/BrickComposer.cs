using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Game.Gameplay.Bricks;

namespace PixelBricksCS.Game.Gameplay.Composers
{
  internal class BrickComposer : IComposer
  {
    private const int TileWidth = 2;

    private Brick _brick;
    private readonly ITileSet<BrickID> _tileSet;

    public BrickComposer(Brick brick, ITileSet<BrickID> tileSet) {
      _brick = brick;
      _tileSet = tileSet;
    }

    public void ReplaceBrick(Brick brick) {
      _brick = brick;
    }

    void IComposer.Compose(FrameBuffer frameBuffer, GridPosition boardPosition) {
      BrickShape shape = _brick.Shape;

      for (int y = 0; y < shape.Height; y++) {
        for (int x = 0; x < shape.Width; x++) {
          BrickID id = shape[y, x];
          if (id == BrickID.None)
            continue;   // empty cells must not overwrite the board

          Tile tile = _tileSet[id];
          int cellY = boardPosition.Y +  _brick.Position.Y + y;
          int cellX = boardPosition.X + (_brick.Position.X + x) * TileWidth;

          frameBuffer[cellY, cellX    ] = new(tile.Symbol0, tile.Color);
          frameBuffer[cellY, cellX + 1] = new(tile.Symbol1, tile.Color);
        }
      }
    }
  }
}