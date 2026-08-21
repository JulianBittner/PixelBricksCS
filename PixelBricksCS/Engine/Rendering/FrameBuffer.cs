using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Rendering
{
  internal class FrameBuffer
  {
    
    private Cell[,] _cells;

    public FrameBuffer(int height, int width) {
      _cells = new Cell[height, width];
    }

    public Cell this[int y, int x] {
      get => _cells[y, x];
      set => _cells[y, x] = value;
    }

    public int Height {  get => _cells.GetLength(0); }
    public int Width  { get => _cells.GetLength(1); }
  }
}
