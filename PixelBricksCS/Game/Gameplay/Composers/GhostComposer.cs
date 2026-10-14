using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Game.Gameplay.Bricks;

namespace PixelBricksCS.Game.Gameplay.Composers
{
  internal class GhostComposer : IComposer
  {
    private const int TileWidth = 2;

    private readonly GhostBrick _ghostBrick;

    public GhostComposer(GhostBrick ghostBrick) {
      _ghostBrick = ghostBrick;
    }

    void IComposer.Compose(FrameBuffer frameBuffer, GridPosition boardPosition) {
      GridPosition position = _ghostBrick.Position;
      BrickShape shape = _ghostBrick.Shape;

      for (int y = 0; y < shape.Height; y++) {
        for (int x = 0; x < shape.Width; x++) {
          BrickID id = shape[y, x];
          if (id == BrickID.None)
            continue;

          int cellY = boardPosition.Y +  position.Y + y;
          int cellX = boardPosition.X + (position.X + x) * TileWidth;

          frameBuffer[cellY, cellX    ] = new('[', CellColor.Default);
          frameBuffer[cellY, cellX + 1] = new(']', CellColor.Default);
        }
      }
    }
  }
}