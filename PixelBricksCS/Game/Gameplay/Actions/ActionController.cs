using PixelBricksCS.Engine.Core;
using PixelBricksCS.Game.Gameplay.Bricks;
using PixelBricksCS.Game.Gameplay.GameMechanics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PixelBricksCS.Game.Gameplay.Actions
{
  internal class ActionController
  {
    private GameBoard _gameBoard;
    private GhostBrick _ghostBrick;

    // ### Controller API
    public ActionController(GameBoard gameBoard, GhostBrick ghostBrick) {
      _gameBoard = gameBoard;
      _ghostBrick = ghostBrick;
    }

    public ActionResult Apply(Brick brick, GameAction action) => action switch {
      GameAction.MoveLeft => MoveLeft(brick),
      GameAction.MoveRight => MoveRight(brick),
      GameAction.RotateLeft => RotateLeft(brick),
      GameAction.RotateRight => RotateRight(brick),
      GameAction.LaunchBrick => LaunchBrick(brick),
      _ => ActionResult.None
    };

    // ### Movement
    private ActionResult MoveLeft(Brick brick) => TryMove(brick, brick.PreviewMoveLeft());
    private ActionResult MoveRight(Brick brick) => TryMove(brick, brick.PreviewMoveRight());
    private ActionResult TryMove(Brick brick, BrickPreview preview) {
      if (GameMechanicUtils.Collides(_gameBoard, preview)) {
        return ActionResult.Blocked;
      }
      brick.ApplyPreview(preview);
      _ghostBrick.UpdateGhostBrick(brick);
      return ActionResult.Moved;
    }

    // ### Rotation
    private ActionResult RotateLeft(Brick brick) => TryRotate(brick, brick.PreviewRotateLeft());
    private ActionResult RotateRight(Brick brick) => TryRotate(brick, brick.PreviewRotateRight());
    private ActionResult TryRotate(Brick brick, BrickPreview preview) {
      if (GameMechanicUtils.Collides(_gameBoard, preview)) {
        BrickPreview wallkick = GameMechanicUtils.TryWallkick(_gameBoard, preview);
        if (wallkick.Position == preview.Position) {
          return ActionResult.Blocked;
        }
        preview = wallkick;
      }

      brick.ApplyPreview(preview);
      _ghostBrick.UpdateGhostBrick(brick);
      return ActionResult.Rotated;
    }

    // ### Launch
    private ActionResult LaunchBrick(Brick brick) {
      brick.ApplyPreview(_ghostBrick.ToPreview());
      return ActionResult.Locked;
    }
  }
}
