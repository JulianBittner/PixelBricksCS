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
    private CountdownTimer _timer;

    public WorldController(GameBoard gameBoard) { 
      _gameBoard = gameBoard;
      _timer = new(GameMetadata.DefaultCeilingSeconds);
    }

    public bool DescentCeiling(double deltaTime, Brick brick) {
      if (_timer.IsTimeUp(deltaTime)) {
        _gameBoard.SpawnCeilingRaw();

        if (GameMechanicUtils.Collides(_gameBoard, brick.ToPreview()))
          return true;
        if (GameMechanicUtils.CeilingReachedBottom(_gameBoard))
          return true;

        _timer.Reset();
      }
      return false;
    }
  }
}
