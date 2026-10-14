using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay.Actions
{
  internal static class GameInputMapper
  {
    public static GameAction ToAction(ConsoleKey key) => key switch {
      ConsoleKey.LeftArrow => GameAction.MoveLeft,
      ConsoleKey.RightArrow => GameAction.MoveRight,
      ConsoleKey.UpArrow => GameAction.RotateRight,
      ConsoleKey.DownArrow => GameAction.RotateLeft,
      _ => GameAction.None,
    };
  }
}
