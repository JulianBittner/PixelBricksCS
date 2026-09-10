using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Game.Assets.AsciiArt;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Sandbox
{
  internal class SpeedTestCollection
  {
    public static void RunTests() {
      FrameBuffer frameBuffer = new FrameBuffer(40, 80);

      for (SpeedProbe probe = new("Create 40x80 FrameBuffer");
           probe.RepeatLoop();
           probe.Continue()) {
        frameBuffer = new(40, 80);
      }

      for (SpeedProbe probe = new("ClearBuffer");
           probe.RepeatLoop();
           probe.Continue()) {
        frameBuffer.Clear();
      }

      for (SpeedProbe probe = new("WriteGameTitleToFrameBuffer");
           probe.RepeatLoop();
           probe.Continue()) {
        TextComposer.WriteTextToFrameBuffer(
          frameBuffer,
          GameTitle.Lines,
          GridPosition.Zero,
          CellColor.Cyan);
      }      
    }
  }
}
