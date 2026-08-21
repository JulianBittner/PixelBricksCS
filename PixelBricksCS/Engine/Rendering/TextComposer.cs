using PixelBricksCS.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Rendering
{
  internal static class TextComposer
  {
    public static void WriteTextToFrameBuffer(FrameBufferBase fb,
                                              string[] text,
                                              GridPosition position,
                                              CellColor color = CellColor.Default) {
      for (int y = 0; y < text.Length; y++) {
        for (int x = 0; x < text[y].Length; x++) {
          fb[y, x] = new(text[y][x], color);
        }
      }
    }
  }
}
