using PixelBricksCS.Engine.Composing;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Assets.Sprites
{
  internal class GameBoardFrame
  {
    // Frame around the 14×20 game board (cells are 2 characters wide).
    // Place it one row above and one column left of the board's position.
    public static readonly CharSprite Sprite = new([
      "╔════════════════════════════╗",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "║                            ║",
      "╚════════════════════════════╝",
    ]);
  }
}
