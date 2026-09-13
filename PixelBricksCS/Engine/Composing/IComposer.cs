using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Composing
{
  internal interface IComposer
  {
    public void Compose(FrameBuffer frameBuffer, GridPosition position);
  }
}
