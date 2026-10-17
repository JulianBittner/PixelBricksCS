using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Game.Gameplay;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Assets.Sprites
{
  internal class BrickTileSet : ITileSet<BrickID>
  {
    private readonly Dictionary<BrickID, Tile> tiles = new();
    public int TileCount { get => tiles.Count; }
    public BrickTileSet() {
      tiles[BrickID.None] = new Tile("  ", CellColor.White);
      tiles[BrickID.I] = new Tile("██", CellColor.Blue);
      tiles[BrickID.O] = new Tile("██", CellColor.BrightYellow);
      tiles[BrickID.T] = new Tile("██", CellColor.Magenta);
      tiles[BrickID.L] = new Tile("██", CellColor.Yellow);
      tiles[BrickID.J] = new Tile("██", CellColor.Gray);
      tiles[BrickID.S] = new Tile("██", CellColor.Green);
      tiles[BrickID.Z] = new Tile("██", CellColor.BrightRed);
      tiles[BrickID.Ceiling] = new Tile("██", CellColor.Cyan);
    }
    public Tile this[BrickID tileID] {
      get {
        return tiles[tileID];
      }
    }
  }
}
