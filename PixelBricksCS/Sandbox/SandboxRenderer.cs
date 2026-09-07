using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Sandbox
{
  internal class SandboxRenderer
  {
    public static void RenderRegionToFrame(FrameBuffer frameBuffer, Region region) {
      int offY = region.Position.Y;
      int offX = region.Position.X;

      for (int y = 0; y < region.Height; y++) {
        for (int x = 0; x < region.Width; x++) {
          frameBuffer[y + offY, x + offX] = region[y, x];
        }
      }
    }
  }
}
