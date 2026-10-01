using PixelBricksCS.Engine.Audio;
using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Engine.StateMachine;
using PixelBricksCS.Game.Assets.Sounds;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game
{
  internal class ExitScreen : IEngineState<GameStateID>
  {
    private FrameBuffer _frameBuffer = new();
    private Renderer _renderer;

    private IContextHandle<GameStateID> _contextHandle = null!;
    private IAudioHandle _audioHandle = null!;

    CountdownTimer _waitTimer = new(Seconds: 1.0);

    public ExitScreen() {
      _renderer = new(_frameBuffer);
    }

    GameStateID IEngineState<GameStateID>.StateID => GameStateID.ExitScreen;
    FrameBuffer IEngineState<GameStateID>.TargetBuffer => _frameBuffer;

    public void Init() {
      int centerCorrection = 30;
      _renderer.AddStaticComposer(
        new BlockTextComposer("GOODBYE", GameMetadata.TitleColor),
        new GridPosition(0, (EngineConfig.GameConsoleSize.Width / 2 - centerCorrection)));

      string message = "Thanks for playing PixelBricks!";
      int textPosition = (EngineConfig.GameConsoleSize.Width / 2) - (message.Length / 2);
      _renderer.AddStaticComposer(
        new BlockComposer(new CharSprite([message]), CellColor.Default),
        new GridPosition(8, textPosition));

      _renderer.RenderStaticContent();
    }

    void IEngineState<GameStateID>.Enter(IContextHandle<GameStateID> contextHandle, IAudioHandle audioHandle) {
      _contextHandle = contextHandle;
      _audioHandle = audioHandle;
      _audioHandle.PlaySound(ExitScreenSound.CreateFarewell());
    }

    void IEngineState<GameStateID>.Exit() {
      // do nothing
    }

    void IEngineState<GameStateID>.Render() {
      // do nothing
    }

    void IEngineState<GameStateID>.Update(double deltaTime, ConsoleKey UserInputKey) {
      if (_waitTimer.TimeUp(deltaTime)) { 
        _contextHandle.RequestShutdown();
      }
    }
  }
}
