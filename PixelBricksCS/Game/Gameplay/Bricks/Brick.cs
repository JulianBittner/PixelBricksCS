using PixelBricksCS.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay.Bricks
{
  internal class Brick
  {
    private static readonly int RotationCount = Enum.GetValues<BrickRotation>().Length;

    private BrickBody _body;
    private BrickID _brickID = BrickID.None;
    private GridPosition _position;
    private BrickRotation _rotation = BrickRotation.Spawn;

    public Brick(BrickID brickID) {
      _brickID = brickID;
      _body = BrickBodySet.Get(brickID);
      int startPositionY = GameMetadata.BoardHeight - _body.Height;
      int startPositionX = (GameMetadata.BoardWidth /2) - (_body.Width / 2);
      if (brickID  == BrickID.I) {
        startPositionX--;
        startPositionY--;
      }
      _position = new GridPosition(startPositionY, startPositionX);
    }

    public BrickID ID => _brickID;
    public BrickShape Shape => _body[(int)_rotation];
    public GridPosition Position => _position;

    public void ApplyPreview(BrickPreview preview) {
      _rotation = preview.Rotation;
      _position = preview.Position;
    }

    public BrickPreview PreviewMoveLeft() => 
      new(Shape, _position.WithOffset(0, -1), _rotation);

    public BrickPreview PreviewMoveRight() =>
      new(Shape, _position.WithOffset(0, +1), _rotation);

    public BrickPreview PreviewRotateLeft() =>
      new(Shape, _position, (BrickRotation)(((int)_rotation + 1) % 4));

    public BrickPreview PreviewRotateRight() =>
      new(Shape, _position, (BrickRotation)(((int)_rotation -1 +RotationCount) % 4));
  }
}
