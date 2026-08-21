using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Rendering
{
  internal readonly record struct Cell (char Character, CellColor Color = CellColor.Default)
  {
  }
}
