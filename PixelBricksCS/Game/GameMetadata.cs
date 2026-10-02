using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game
{
  internal static class GameMetadata
  {
    public static string GameTitle = "PIXELBRICKS";
    public static readonly CellColor[] GameTitleColors = [
      CellColor.BrightRed,
      CellColor.BrightYellow,
      CellColor.BrightGreen,
      CellColor.BrightCyan,
      CellColor.BrightBlue,
      CellColor.BrightMagenta
    ];

    public static CellColor TitleColor = CellColor.Cyan;
  }
}
