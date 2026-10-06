using PixelBricksCS.Engine.Audio;
using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Engine.StateMachine;
using PixelBricksCS.Game.Assets.Sounds;
using PixelBricksCS.Game.Assets.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay
{
  internal class GameplayState : IEngineState<GameStateID>
  {
    private FrameBuffer _frameBuffer = new();
    private Renderer _renderer;

    private IContextHandle<GameStateID> _contextHandle = null!;
    private IAudioHandle _audioHandle = null!;

    private GameBoard _board = new();

    public GameplayState() {
      _renderer = new(_frameBuffer);
    }

    GameStateID IEngineState<GameStateID>.StateID => GameStateID.Gameplay;

    FrameBuffer IEngineState<GameStateID>.TargetBuffer => _frameBuffer;

    public void Init() {
      TileMapComposer<BrickID> tileMapComposer = new(_board, new BrickTileSet());
      _renderer.AddDynamicComposer(tileMapComposer, position: new(8,10));

      _renderer.AddStaticComposer(new BlockTextComposer("PIXELBRICKS", CellColor.Cyan), GridPosition.Zero);
      _renderer.RenderStaticContent();
    }

    void IEngineState<GameStateID>.Enter(IContextHandle<GameStateID> contextHandle, IAudioHandle audioHandle) {
      _contextHandle = contextHandle;
      _audioHandle = audioHandle;
      _audioHandle.PlayMusicLoop(new GameMusicTrack1());
    }

    void IEngineState<GameStateID>.Exit() {
      _audioHandle.StopMusicLoop();
      _board.Reset();
    }

    void IEngineState<GameStateID>.Render() {
      _renderer.RenderDynamicContent();
    }

    void IEngineState<GameStateID>.Update(double deltaTime, ConsoleKey UserInputKey) {
      ValueTracer.TraceValue("Delta Time: ", deltaTime.ToString());
    }
  }
}
