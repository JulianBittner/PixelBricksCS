using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Menu
{
  internal static class MenuInputMapper
  {
    public static MenuAction ToAction(ConsoleKey consoleKey) => consoleKey switch {
      ConsoleKey.UpArrow   => MenuAction.MoveUp,
      ConsoleKey.DownArrow => MenuAction.MoveDown,
      ConsoleKey.Enter     => MenuAction.Confirm,
      _                    => MenuAction.None,
    };
  }
}