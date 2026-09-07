using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Game;
using PixelBricksCS.Game.Assets;
using PixelBricksCS.Game.Assets.AsciiArt;

namespace PixelBricksCS.Sandbox
{
  // temporary class for the current sprint
  internal class RenderingDemo
  {
    public static void Run()
    {
      GameConsole.InitConsole(80, 40);
      
      GameConsole.Present(AssembleTestBoardFrame());
      DiagnosticsScreen.PresentOverlayAtLine(10);
      Console.SetCursorPosition(0, 20);
    }

    public static FrameBuffer AssembleTestBoardFrame() {
      FrameBuffer fb = new FrameBuffer(40,80);
      Region boardRegion = new Region(20,20,new());
      DemoBoard board = new();

      IComposer tileMapComposer = new TileMapComposer<MinoID>(boardRegion, board, new MinoTileSet());      
      tileMapComposer.Compose();
      
      SandboxRenderer.RenderRegionToFrame(fb, boardRegion);
      return fb;
    }

    public static FrameBuffer AssembleGameTileFrame() {
      FrameBuffer frameBuffer = new FrameBuffer(40, 80);
      Region gameTitle = Region.Empty;

      TextComposer.WriteTextToFrameBuffer(
        frameBuffer, 
        GameTitle.Lines, 
        GridPosition.Zero, 
        CellColor.Cyan);

      SandboxRenderer.RenderRegionToFrame(frameBuffer, gameTitle);
      return frameBuffer;
    }
  }
}
