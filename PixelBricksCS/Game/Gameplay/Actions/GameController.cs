using PixelBricksCS.Game.Gameplay.Bricks;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay.Actions
{
  internal class GameController
  {
    private GameBoard _gameBoard;

    public GameController(GameBoard gameBoard) {
      _gameBoard = gameBoard;
    }

    public ActionResult Apply(Brick brick, GameAction action) => action switch {
      GameAction.MoveLeft  => MoveLeft(brick),
      GameAction.MoveRight => MoveRight(brick),
      _ => ActionResult.None
    };

    private ActionResult MoveLeft(Brick brick) {
      BrickPreview preview = brick.PreviewMoveLeft();
      brick.ApplyPreview(preview);
      return ActionResult.Moved;
    }
    private ActionResult MoveRight(Brick brick) {
      BrickPreview preview = brick.PreviewMoveRight();
      brick.ApplyPreview(preview);
      return ActionResult.Moved;
    }
    
  }
}
