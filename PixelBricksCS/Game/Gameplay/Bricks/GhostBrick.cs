using PixelBricksCS.Engine.Core;
using PixelBricksCS.Game.Gameplay.GameMechanics;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay.Bricks
{
  internal class GhostBrick
  {
    GameBoard _gameBoard;
    BrickShape _shape;
    GridPosition _position;
    BrickRotation _rotation;

    public GhostBrick(GameBoard gameBoard, Brick brick) {
      _gameBoard = gameBoard;
      _shape = brick.Shape;
      _rotation = brick.Rotation;
      UpdateGhostBrick(brick);
    }

    public BrickShape Shape => _shape;
    public GridPosition Position => _position;

    public BrickPreview ToPreview() {
      return new(_shape, _position, _rotation);
    }

    public void UpdateGhostBrick(Brick brick) {
      BrickPreview current = brick.ToPreview();
      _shape = brick.Shape;
      _rotation = brick.Rotation;

      while (true) {
        BrickPreview next = current.WithPositionOffset(-1, 0);
        if (GameMechanicUtils.Collides(_gameBoard, next)) {
          _position = current.Position;
          return;
        }
        current = next;
      }
    }
  }
}
