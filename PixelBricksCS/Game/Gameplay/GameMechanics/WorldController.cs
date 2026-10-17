using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.StateMachine;
using PixelBricksCS.Game.Gameplay.Bricks;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay.GameMechanics
{
  internal class WorldController
  {
    private GameBoard _gameBoard;
    private GhostBrick _ghostBrick;
    private CountdownTimer _timer;

    public WorldController(GameBoard gameBoard, GhostBrick ghostBrick) { 
      _gameBoard = gameBoard;
      _ghostBrick = ghostBrick;
      _timer = new(GameMetadata.DefaultCeilingSeconds);
    }

    public bool DescentCeiling(double deltaTime, Brick brick) {
      if (_timer.IsTimeUp(deltaTime)) {
        _gameBoard.SpawnCeilingRow();
        _ghostBrick.UpdateGhostBrick(brick);
        _timer.Reset();

        if (GameMechanicUtils.Collides(_gameBoard, brick.ToPreview()))
          return true;
        if (GameMechanicUtils.CeilingReachedBottom(_gameBoard))
          return true;
      }
      return false;
    }
  }
}
