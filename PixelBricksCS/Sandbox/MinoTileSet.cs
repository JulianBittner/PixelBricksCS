using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Sandbox
{
  internal class MinoTileSet : ITileSet<MinoID>
  {
    private readonly Dictionary<MinoID, Tile> tiles = new();
    public int TileCount { get => tiles.Count; }
    public MinoTileSet() {
      tiles[MinoID.None] = new Tile("  ", CellColor.White);
      tiles[MinoID.I] = new Tile("██", CellColor.Cyan);
      tiles[MinoID.O] = new Tile("██", CellColor.BrightYellow);
      tiles[MinoID.T] = new Tile("██", CellColor.Magenta);
      tiles[MinoID.L] = new Tile("██", CellColor.Yellow);
      tiles[MinoID.J] = new Tile("██", CellColor.Black);
      tiles[MinoID.S] = new Tile("██", CellColor.Green);
      tiles[MinoID.Z] = new Tile("██", CellColor.BrightRed);
    }
    public Tile this[MinoID tileID] {
      get {
        return tiles[tileID];
      }
    }
  }
}
