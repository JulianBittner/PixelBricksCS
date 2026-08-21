using PixelBricksCS.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Rendering
{
  internal class Region : FrameBufferBase
  {
    // Represents a region with zero dimensions.Used as an empty default instance
    public static readonly Region Empty = new Region(0, 0, new(0,0));
    public readonly GridPosition Position;

    public Region(int height, int width, GridPosition position) : base(height, width) {
      Position = position;
    }
  }
}
