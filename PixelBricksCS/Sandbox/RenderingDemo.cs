using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Game;
using PixelBricksCS.Game.Assets;
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
      GameConsole.InitConsole(80, 40);
      GameConsole.Present(ComposingTest());
      DiagnosticsScreen.PresentOverlayAtLine(10);
      Console.SetCursorPosition(0, 20);          
    }

    public static FrameBuffer ComposingTest() {
      FrameBuffer fb = new FrameBuffer(40,40);
      Region rg = new Region(20,20,new());

      DemoBoard brd = new();
      TileMapComposer<MinoID> tmComposer = new TileMapComposer<MinoID>(rg, brd, new MinoTileSet());
      IComposer cp = tmComposer;
      
      cp.Compose();
      for (SpeedProbe probe = new("DempMapComposer");
           probe.RepeatLoop(1000);
           probe.Continue()) {
        cp.Compose();
      }

      RenderRegionToFrame(fb, rg);
      return fb;
    }

    public static FrameBuffer DiagnisticsTest() {
      FrameBuffer frameBuffer = new FrameBuffer(40, 80);
      var fb1 = AssembleHorizontalLineFarmeBuffer();
      var fb2 = AssembleVerticalColorsFarmeBuffer();
      Region gameTitle = Region.Empty;

      for (SpeedProbe probe = new("TextComposer");
           probe.RepeatLoop();
           probe.Continue()) {
        TextComposer.WriteTextToFrameBuffer(
          frameBuffer, 
          GameTitle.Lines, 
          GridPosition.Zero, 
          CellColor.Cyan);
      }

      for (SpeedProbe probe = new("AssambleFarmeBuffer");
           probe.RepeatLoop();
           probe.Continue()) {
        fb1 = AssembleRandomizeFarmeBuffer();
      }

      for (SpeedProbe probe = new("RenderRegionToFrame");
           probe.RepeatLoop();
           probe.Continue()) {
        RenderRegionToFrame(frameBuffer, gameTitle);
      }      

      for (SpeedProbe probe = new("Create FrameBuffer");
           probe.RepeatLoop();
           probe.Continue()) {
        FrameBuffer fb3 = new(40,80);
      }

      for (SpeedProbe probe = new("ResetBuffer");
           probe.RepeatLoop();
           probe.Continue()) {
        frameBuffer.Clear();
      }

      TextComposer.WriteTextToFrameBuffer(
        frameBuffer, 
        GameTitle.Lines, 
        GridPosition.Zero, 
        CellColor.Cyan);

      RenderRegionToFrame(frameBuffer, gameTitle);
      return frameBuffer;
    }

    private static void RenderRegionToFrame(FrameBuffer frameBuffer,Region region) {
      int offY = region.Position.Y;
      int offX = region.Position.X;
      
      for (int y = 0; y < region.Height; y++) {
        for (int x = 0; x < region.Width; x++) {
          frameBuffer[y + offY, x + offX] = region[y,x];
        }
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
