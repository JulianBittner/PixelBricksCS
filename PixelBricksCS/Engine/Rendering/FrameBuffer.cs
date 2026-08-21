using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Rendering
{
  internal class FrameBuffer(int height, int width) : FrameBufferBase(height, width)
  {
    // Represents a FrameBuffer with zero dimensions.Used as an empty default instance
    public static readonly FrameBuffer Empty = new FrameBuffer(0, 0);
  }
}
