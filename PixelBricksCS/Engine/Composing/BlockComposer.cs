using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Composing
{
  internal class BlockComposer : IComposer
  {
    private CharSprite _sprite;
    private readonly CellColor _color;

    public CharSprite Sprite {
      get { return _sprite; }
      set { _sprite = value; }
    }

    public BlockComposer(CharSprite sprite, CellColor color = CellColor.Default) {
      _sprite = sprite;
      _color = color;
    }

    void IComposer.Compose(FrameBuffer frameBuffer, GridPosition position) {
      ComposerUtils.WriteSprite(frameBuffer, position, _sprite, _color);
    }
  }
}
