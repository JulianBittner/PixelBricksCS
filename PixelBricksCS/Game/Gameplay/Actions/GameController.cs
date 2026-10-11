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

    private ActionResult MoveLeft(Brick brick) => TryMove(brick, brick.PreviewMoveLeft());
    private ActionResult MoveRight(Brick brick) => TryMove(brick, brick.PreviewMoveRight());
    private ActionResult TryMove(Brick brick, BrickPreview preview) {
      if (GameMechanics.Collides(_gameBoard, preview))
        return ActionResult.Blocked;

      brick.ApplyPreview(preview);
      return ActionResult.Moved;
    }

    private ActionResult RotateLeft(Brick brick) => TryRotate(brick, brick.PreviewRotateLeft());
    private ActionResult RotateRight(Brick brick) => TryRotate(brick, brick.PreviewRotateRight());
    private ActionResult TryRotate(Brick brick, BrickPreview preview) {
      // If the rotation collides, try shifting the brick to nearby positions.
      if (GameMechanics.Collides(_gameBoard, preview)) {
        BrickPreview wallkick = GameMechanics.TryWallkick(_gameBoard, preview);
        if (wallkick.Position == preview.Position)
          return ActionResult.Blocked;

        preview = wallkick;
      }

      brick.ApplyPreview(preview);
      return ActionResult.Rotated;
    }
  }
}
