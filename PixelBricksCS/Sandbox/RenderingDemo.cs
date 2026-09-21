using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Engine.StateMachine;
using PixelBricksCS.Game;
using PixelBricksCS.Game.Assets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PixelBricksCS.Sandbox
{
  // temporary class for the current sprint
  internal class RenderingDemo : IEngineState<DemoStateID>
  {
    private Renderer _renderer = new Renderer(new FrameBuffer());
    IContextHandle<DemoStateID> _contextHandle = null!;
    CountdownTimer _animationTimer = new(seconds: 0.5);

    DemoBoard _board1 = new();
    DemoBoard _board2 = new();
    DemoBoard _board3 = new();

    DemoStateID IEngineState<DemoStateID>.StateID => DemoStateID.Demo;
    FrameBuffer IEngineState<DemoStateID>.TargetBuffer => _renderer.TargetBuffer; 

    void IEngineState<DemoStateID>.Update(double deltaTime) {
      if (_animationTimer.TimeUp(deltaTime)) {
        _board2.Animate();
        _board3.Animate();
        _animationTimer.Reset();
      }
    }

    public void Init() {
      // Add all elements to be rendered in this scene:
      _renderer.AddStaticComposer(
        new BlockTextComposer("PIXELBRICKS", CellColor.Magenta),
        GridPosition.Zero);
      // Renders a static DemoBoard to the middle of the screen
      _renderer.AddStaticComposer(
        new TileMapComposer<MinoID>(_board1, new MinoTileSet()),
        new GridPosition(16, 5));
      // Renders two animated DemoBoards below the BlockText
      _renderer.AddDynamicComposer(
        new TileMapComposer<MinoID>(_board2, new MinoTileSet()),
        new GridPosition(6, 5));
      _renderer.AddDynamicComposer(
        new TileMapComposer<MinoID>(_board3, new MinoTileSet()),
        new GridPosition(6, 20));

      _renderer.RenderStaticContent();
    }

    void IEngineState<DemoStateID>.Enter(IContextHandle<DemoStateID> contextHandle) {
      _contextHandle = contextHandle;
    }

    void IEngineState<DemoStateID>.Render() {
      _renderer.RenderDynamicContent();
    }

    void IEngineState<DemoStateID>.Exit() {
      //do nothing
    }
  }
}
