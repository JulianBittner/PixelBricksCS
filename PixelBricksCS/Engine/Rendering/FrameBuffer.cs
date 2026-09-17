using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Rendering
{
  internal class FrameBuffer
  {    
    private readonly Cell[,] _cells;
    private readonly int _height;
    private readonly int _width;

    public FrameBuffer() {
      _height = EngineConfig.GameConsoleSize.Height;
      _width  = EngineConfig.GameConsoleSize.Width;
      _cells  = new Cell[_height, _width];
      Clear();
    }

    public int Height { get => _height; }
    public int Width { get => _width; }

    public Cell this[int y, int x] {
      get {
        if (y >= _height || y < 0 ||
            x >= _width  || x < 0) {
          return Cell.Blank;
        }
        return _cells[y, x];
      }
      set {
        if (y >= _height || y < 0 ||
            x >= _width  || x < 0) {
          return;
        }
        _cells[y, x] = value;
      }
    }
    public void Clear() {
      for (int y = 0; y < _height; y++) {
        for (int x = 0; x < _width; x++) {
          _cells[y, x] = Cell.Blank;
        }
      }
    }
  }
}
