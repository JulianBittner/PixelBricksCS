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
      GameAction.Left  => MoveLeft(brick),
      GameAction.Right => MoveRight(brick),
      _ => ActionResult.None
    };

    private ActionResult MoveLeft(Brick brick) {
      brick.MoveLeft();
      return ActionResult.Moved;
    }
    private ActionResult MoveRight(Brick brick) {
      brick.MoveRight();
      return ActionResult.Moved;
    }
  }
}
