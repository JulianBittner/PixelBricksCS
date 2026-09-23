using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Composing
{
  internal readonly record struct Tile
  {
    public readonly string Symbols;
    public readonly char Symbol0;
    public readonly char Symbol1;
    public readonly CellColor Color;
    public Tile() {
      Symbols = "??";
      Color = CellColor.Red;
      Symbol0 = Symbols[0];
      Symbol1 = Symbols[1];
    }
    public Tile(string symbols,
                CellColor color) {
      if (symbols.Length != 2) throw new Exception("DoubleTile: symbols must be a string of lenth 2");
      Symbols = symbols;
      Symbol0 = Symbols[0];
      Symbol1 = Symbols[1];
      Color   = color;
    }
  }
}
