using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game
{
  internal static class GameMetadata
  {
    // Game Title
    public static string GameTitle = "PIXELBRICKS";
    public static CellColor TitleColor = CellColor.Cyan;
    public static readonly CellColor[] GameTitleColors = [
      CellColor.BrightRed,
      CellColor.BrightYellow,
      CellColor.BrightGreen,
      CellColor.BrightCyan,
      CellColor.BrightBlue,
      CellColor.BrightMagenta
    ];

    // Game Board
    public static int BoardHeight => 24;
    public static int BoardWidth => 14;

    // Game Rouls
    public const int BlastThreshold = 3;   // contact points needed for a blast
    public const int BigBlastThreshold = 6;   // contact points needed for a big blast
    public const int MegaBlastThreshold = 8;   // contact points needed for a mega blast

    public const double DefaultCeilingSeconds = 1000.0;
  }
}
