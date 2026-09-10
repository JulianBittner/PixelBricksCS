using PixelBricksCS.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Rendering
{
  internal class Region
  {
    public readonly GridSize Size;
    public readonly GridPosition Position;
    private readonly FrameBuffer _frameBuffer;

    private readonly GridPosition _bounds;
    public Region(FrameBuffer frameBuffer, GridSize size, GridPosition position = new()) {
      _frameBuffer = frameBuffer;
      Size = size;
      Position = position;
      _bounds = new(Position.Y + Size.Y, Position.X + Size.X);
    }
    public Cell this[int y, int x] {
      get {
        int offsettedY = Position.Y + y;
        int offsettedX = Position.X + x;
        if (y < 0 || x < 0 || 
            offsettedX > _bounds.X || offsettedY > _bounds.Y) 
          return Cell.Blank;

        return _frameBuffer[offsettedY, offsettedX]; 
      }
      set {
        int offsettedY = Position.Y + y;
        int offsettedX = Position.X + x;
        if (y < 0 || x < 0 || 
            offsettedX > _bounds.X || offsettedY > _bounds.Y) 
          return;

        _frameBuffer[offsettedY, offsettedX] = value;
      }
    }
  }
}
