using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.SplashScreen
{
  /// <summary>
  /// Animates a single letter dropping into place in phases.
  /// Each time this composer is invoked by the renderer, the letter advances one step.
  /// </summary>
  internal class LetterAnimationComposer(CharSprite letter, CellColor color): IComposer {
    private CharSprite _letter = letter;
    private CellColor _color = color;
    private int _animationPhase = 0;
    private bool _isFinished = false;

    public bool AnimationFinished => _isFinished;

    void IComposer.Compose(FrameBuffer frameBuffer, GridPosition position) {
      ComposerUtils.ClearArea(
        frameBuffer, position, new GridSize(_letter.Height+2, _letter.Width));
      ComposerUtils.WriteSprite(
        frameBuffer, GetCurrentPosition(position), _letter, _color);

      // Advances the animation by one step. Signals completion once the animation is over.
      if (_animationPhase < 10) _animationPhase++;
      else _isFinished = true;
    }

    // Returns the letter position for the current animation phase.
    private GridPosition GetCurrentPosition(GridPosition Position ) => _animationPhase switch {
      0 => Position.WithOffset(-5, 0),
      1 => Position.WithOffset(-4, 0),
      2 => Position.WithOffset(-3, 0),
      3 => Position.WithOffset(-2, 0),
      4 => Position.WithOffset(-1, 0),
      5 => Position.WithOffset( 0, 0),
      6 => Position.WithOffset( 1, 0),
      7 => Position.WithOffset( 2, 0),
      8 => Position.WithOffset( 1, 0),
      9 => Position.WithOffset( 0, 0),
      _ => Position,
    };
  }
}
