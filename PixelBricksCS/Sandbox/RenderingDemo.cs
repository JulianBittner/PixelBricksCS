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
    private static DemoBoard board = new();
    public static void Run()
    {
      GameConsole.InitConsole(80, 40);
      for (int i = 0; i < 16; i++) {
        GameConsole.Present(TestBoardFrameAnimation());
        Thread.Sleep(500);
      }
      DiagnosticsScreen.PresentOverlayAtLine(10);
      Console.SetCursorPosition(0, 20);
    }

    public static FrameBuffer TestBoardFrameAnimation() {
      FrameBuffer frameBuffer = new FrameBuffer(40,80);
      frameBuffer.Clear();
      Region boardRegion = new Region(frameBuffer, new(20,20), GridPosition.Zero);
      IComposer tileMapComposer = new TileMapComposer<MinoID>(boardRegion, board, new MinoTileSet());

      tileMapComposer.Compose();
      board.Animate();
      return frameBuffer;
    }

    public static FrameBuffer AssembleGameTileFrame() {
      FrameBuffer frameBuffer = new FrameBuffer(40, 80);

      TextComposer.WriteTextToFrameBuffer(
        frameBuffer, 
        GameTitle.Lines, 
        GridPosition.Zero, 
        CellColor.Cyan);

      return frameBuffer;
    }
  }
}
