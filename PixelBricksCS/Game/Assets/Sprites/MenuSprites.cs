using PixelBricksCS.Engine.Composing;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Assets.Sprites
{
  internal static class MenuSprites
  {
    public static readonly CharSprite ItemBox = new([
      "╔════════════════════╗",
      "║       PLAY         ║",
      "║                    ║",
      "║       CREDITS      ║",
      "║                    ║",
      "║       EXIT         ║",
      "╚════════════════════╝",
      ]);

    public static readonly CharSprite GrayedItems = new([
      "PLAY   ",
      "       ",
      "CREDITS",      
      ]);

    public static readonly CharSprite PlayArrow = new([
      ">",
      " ",
      " ",
      " ",
      " ",
      ]); 
    
    public static readonly CharSprite CreditsArrow = new([
      " ",
      " ",
      ">",
      " ",
      " ",
      ]);

    public static readonly CharSprite ExitArrow = new([
      " ",
      " ",
      " ",
      " ",
      ">",
      ]);
  }
}
