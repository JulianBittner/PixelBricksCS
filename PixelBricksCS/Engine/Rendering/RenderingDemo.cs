using PixelBricksCS.Game.Assets.AsciiArt;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Rendering
{
  // temporary class for the current sprint
  internal class RenderingDemo
  {
    public static void Run()
    {
      GameConsole.InitConsole(80, 36);
      Console.WriteLine("Hello:");

      foreach (string str in GameTitle.Lines) {
        Console.WriteLine(str);
      }

      AnsiColor.ColorTestscreen();
    }
  }
}
