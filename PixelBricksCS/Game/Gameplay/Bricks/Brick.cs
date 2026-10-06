using PixelBricksCS.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay.Bricks
{
  internal class Brick
  {
    private BrickBody _body;
    private BrickID _brickID = BrickID.None;
    private GridPosition _position;
    private Rotation _rotation = Rotation.Spawn;

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
  }
}
