using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Sandbox
{
  internal class TestPattern
  {
    public static void Run() {
      GameConsole.InitConsole(80, 40);
      for (; ; ) {
        GameConsole.Present(AssembleRandomizeFarmeBuffer());
        Thread.Sleep(500);
        GameConsole.Present(AssembleHorizontalLineFarmeBuffer());
        Thread.Sleep(500);
        GameConsole.Present(AssembleVerticalColorsFarmeBuffer());
        Thread.Sleep(500);
      }
    }

    private static FrameBuffer AssembleRandomizeFarmeBuffer() {
      var frameBuffer = new FrameBuffer(20, 40);

      var random = new Random();
      var colors = Enum.GetValues<CellColor>();
      char[] symbols = { '░', '▒', '▓', '█' };

      for (int y = 0; y < frameBuffer.Height; y++) {
        for (int x = 0; x < frameBuffer.Width; x++) {
          frameBuffer[y, x] = new Cell {
            Character = symbols[random.Next(symbols.Length)],
            Color = colors[random.Next(colors.Length)]
          };
        }
      }

      return frameBuffer;
    }

    private static FrameBuffer AssembleHorizontalLineFarmeBuffer() {
      var frameBuffer = new FrameBuffer(20, 40);

      for (int y = 0; y < frameBuffer.Height; y++) {
        for (int x = 0; x < frameBuffer.Width; x++) {
          frameBuffer[y, x] = new Cell {
            Character = '█',
            Color = (CellColor)(x % 15) + 1
          };
        }
      }
      return frameBuffer;
    }
    private static FrameBuffer AssembleVerticalColorsFarmeBuffer() {
      var frameBuffer = new FrameBuffer(20, 40);

      for (int y = 0; y < frameBuffer.Height; y++) {
        for (int x = 0; x < frameBuffer.Width; x++) {
          frameBuffer[y, x] = new Cell {
            Character = '█',
            Color = (CellColor)(y % 15) + 1
          };
        }
      }
      return frameBuffer;
    }
  }
}
