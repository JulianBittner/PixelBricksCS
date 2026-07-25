using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Game.Assets.AsciiArt;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PixelBricksCS.Sandbox
{
  // temporary class for the current sprint
  internal class RenderingDemo
  {
    public static void Run()
    {
      GameConsole.InitConsole(80, 36);
      foreach (string str in GameTitle.Lines) {
        Console.WriteLine(str);
      }

      DiagnisticsTest();
    }

    private static FrameBuffer AssembleTestFarmeBuffer0() {
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

    private static FrameBuffer AssembleTestFarmeBuffer1() {
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

    private static FrameBuffer AssembleTestFarmeBuffer2() {
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

    public static void DiagnisticsTest() {
      var fb1 = AssembleTestFarmeBuffer1();
      var fb2 = AssembleTestFarmeBuffer2();

      for (SpeedProbe probe = new("AssambleFarmeBuffer");
           probe.RepeatLoop(500);
           probe.Continue()) {
        AssembleTestFarmeBuffer0();
      }
      for (SpeedProbe probe = new("AssambleFarmeBuffer");
           probe.RepeatLoop();
           probe.Continue()) {
        AssembleTestFarmeBuffer0();
      }
      ValueTracer.TraceValue("test1", "123");

      IssueLog.AddIssueMessage("ERROR Hello1");
      IssueLog.AddIssueMessage("ERROR Hello2");
      IssueLog.AddIssueMessage("ERROR Hello3");

      DiagnosticsScreen.PresentOverlayAtLine(10);
    }
  }
}
