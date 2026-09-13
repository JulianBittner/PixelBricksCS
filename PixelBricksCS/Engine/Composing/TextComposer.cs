using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Composing
{
  internal class TextComposer : IComposer
  {
    private readonly string[] _text;
    private readonly CellColor _color;

    public TextComposer(string[] text, CellColor color = CellColor.Default) {
      _text = text;
      _color = color;
    }

    void IComposer.Compose(FrameBuffer frameBuffer, GridPosition position) {
      WriteTextToFrameBuffer(frameBuffer, _text, position, _color);
    }
    public void WriteTextToFrameBuffer(FrameBuffer fb,
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
