using PixelBricksCS.Engine.Assets;
using PixelBricksCS.Engine.Audio;
using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Engine.StateMachine;
using PixelBricksCS.Game.Assets.Sounds;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.SplashScreen
{
  internal class SplashScreen : IEngineState<GameStateID>
  {
    private IContextHandle<GameStateID> _contextHandle = null!;

    private readonly Renderer _renderer;
    private LetterAnimationComposer _lastComposer = null!;
    private IEnumerator<LetterAnimationComposer> _animation = null!;

    private string _splashTitle;
    private CellColor[] _colors;

    private CountdownTimer _animationTimer = new(Seconds: 0.020);
    private CountdownTimer _delayTimer = new(Seconds: 1.0);

    GameStateID IEngineState<GameStateID>.StateID => GameStateID.SplashScreen;

    FrameBuffer IEngineState<GameStateID>.TargetBuffer => _renderer.TargetBuffer;

    public SplashScreen(string splashTitle, CellColor[] colors) {
      _splashTitle = splashTitle;
      _colors = colors;
      _renderer = new Renderer(new FrameBuffer());
      var animation = GetAnimationSequence();
    }

    void IEngineState<GameStateID>.Enter(
      IContextHandle<GameStateID> contextHandle, 
      IAudioHandle audioHandle) 
    {
      _contextHandle = contextHandle;
      _animation = GetAnimationSequence();
      _animation.MoveNext();
      _lastComposer = _animation.Current;
      audioHandle.PlaySound(SplashScreenSound.CreateSplashScreenPling(EngineConfig.MenuSoundVolume));
    }

    void IEngineState<GameStateID>.Update(double deltaTime, ConsoleKey userInputKey) {     
      if (!_lastComposer.AnimationFinished) {
        if (!_animationTimer.TimeUp(deltaTime)) return;
        _animation.MoveNext();
        _lastComposer = _animation.Current;
        _renderer.RenderDynamicContent();
        return;
      }
      
      if (_delayTimer.TimeUp(deltaTime)) {
        _contextHandle.RequestStateChange(GameStateID.Menu);
      }      
    }

    /// <summary>
    /// Iterates over the splash title, instantiates an animation composer for each letter, 
    /// and registers it with the renderer.
    /// </summary>
    /// <returns>
    /// An enumerator that yields each <see cref="LetterAnimationComposer"/> step by step as the animation progresses.
    /// </returns>
    public IEnumerator<LetterAnimationComposer> GetAnimationSequence() {
      int _letterOffset = 0;

      for (int i = 0; i < _splashTitle.Length; i++) {
        CharSprite blockLetter = BlockLetterFont.GetLetter(_splashTitle[i]);
        LetterAnimationComposer nextComposer = new LetterAnimationComposer(blockLetter, _colors[i % _colors.Length]);

        _renderer.AddDynamicComposer(nextComposer, new GridPosition(0, _letterOffset));

        _letterOffset += blockLetter.Width;
        yield return nextComposer;
      }
    }    

    void IEngineState<GameStateID>.Render() {
      _renderer.RenderDynamicContent();
    }

    void IEngineState<GameStateID>.Exit() {
      // do nothing
    }
  }
}
