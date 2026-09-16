using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Game;
using PixelBricksCS.Game.Assets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PixelBricksCS.Sandbox
{
  // temporary class for the current sprint
  internal class RenderingDemo
  {
    public static void Run() {
      GameConsole.InitConsole(80, 40);

      DemoScreen();

      DiagnosticsScreen.PresentOverlayAtLine(20);
      Console.SetCursorPosition(0, 25);
    }

    public static void DemoScreen() {
      Renderer renderer = new Renderer(new FrameBuffer(40, 80));
      DemoBoard board1 = new();
      DemoBoard board2 = new();
      DemoBoard board3 = new();

      // Add all elements to be rendered in this scene:
      renderer.AddStaticComposer(
        new BlockTextComposer("PIXELBRICKS", CellColor.Magenta),
        GridPosition.Zero);
      // Renders a static DemoBoard to the middle of the screen
      renderer.AddStaticComposer(
        new TileMapComposer<MinoID>(board1, new MinoTileSet()),
        new GridPosition(16, 5));
      // Renders two animated DemoBoards below the BlockText
      renderer.AddDynamicComposer(
        new TileMapComposer<MinoID>(board2, new MinoTileSet()),
        new GridPosition(6, 5));
      renderer.AddDynamicComposer(
        new TileMapComposer<MinoID>(board3, new MinoTileSet()),
        new GridPosition(6, 20));

      renderer.RenderStaticContent();
      // Animate scene
      for (int i = 0; i < 16; i++) {
        board2.Animate();
        renderer.RenderDynamicContent();
        board3.Animate();
        GameConsole.Present(renderer.TargetBuffer);
        Thread.Sleep(500);
      }
    }

    public static FrameBuffer AssembleGameTileFrame() {
      FrameBuffer frameBuffer = new FrameBuffer(40, 80);
      IComposer composer = new BlockComposer(GameTitle.Lines);

      composer.Compose(
        frameBuffer,
        GridPosition.Zero);

      return frameBuffer;
    }
  }
}
