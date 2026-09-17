using PixelBricksCS.Engine.Assets;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Composing
{
  internal class BlockTextComposer : IComposer
  {
    private string _text;
    private CellColor _color;

    public BlockTextComposer(string text, CellColor color) {
      _text = text;
      _color = color;
    }

    void IComposer.Compose(FrameBuffer frameBuffer, GridPosition position) {
      int letterPosition = 0;

      for (int i = 0; i < _text.Length; i++) {
        CharSprite blockLetter = (_text[i] == ' ') 
          ? BlockLetterFont.WhiteSpace 
          : BlockLetterFont.GetLetter(_text[i]);

        ComposerUtils.WriteSprite(
          frameBuffer, position.WithOffset(0, letterPosition), blockLetter, _color);
        letterPosition += blockLetter[0].Length;
      }
    }
  }
}
