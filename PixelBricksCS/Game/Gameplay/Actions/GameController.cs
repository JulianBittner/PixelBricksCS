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
      GameAction.RotateLeft => RotateLeft(brick),
      GameAction.RotateRight => RotateRight(brick),
      _ => ActionResult.None
    };

    private ActionResult MoveLeft(Brick brick) {
      BrickPreview preview = brick.PreviewMoveLeft();
      if (GameMechanics.Collides(_gameBoard, preview)) 
        return ActionResult.Blocked;

      brick.ApplyPreview(preview);
      return ActionResult.Moved;
    }
    private ActionResult MoveRight(Brick brick) {
      BrickPreview preview = brick.PreviewMoveRight();
      if (GameMechanics.Collides(_gameBoard, preview))
        return ActionResult.Blocked;

      brick.ApplyPreview(preview);
      return ActionResult.Moved;
    }
    private ActionResult RotateLeft(Brick brick) {
      BrickPreview preview = brick.PreviewRotateLeft();
      if (GameMechanics.Collides(_gameBoard, preview))
        return ActionResult.Blocked;

      brick.ApplyPreview(preview);
      return ActionResult.Rotated;
    }
    private ActionResult RotateRight(Brick brick) {
      BrickPreview preview = brick.PreviewRotateRight();
      if (GameMechanics.Collides(_gameBoard, preview))
        return ActionResult.Blocked;

      brick.ApplyPreview(preview);
      return ActionResult.Rotated;
    }
  }
}
