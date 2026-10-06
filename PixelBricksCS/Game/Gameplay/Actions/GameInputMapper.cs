using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay.Actions
{
  internal static class GameInputMapper
  {
    public static GameAction ToAction(ConsoleKey key) => key switch {
      ConsoleKey.LeftArrow => GameAction.Left,
      ConsoleKey.RightArrow => GameAction.Right,
      _ => GameAction.None,
    };
  }
}
