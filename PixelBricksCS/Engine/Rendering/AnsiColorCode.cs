using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Rendering
{
  internal static class AnsiColorCode
  {
    // Reset to default color of Terminal
    public const string Reset = "\u001b[0m";

    // Normal (30–37)
    public const string Black   = "\u001b[30m";
    public const string Red     = "\u001b[31m";
    public const string Green   = "\u001b[32m";
    public const string Yellow  = "\u001b[33m";
    public const string Blue    = "\u001b[34m";
    public const string Magenta = "\u001b[35m";
    public const string Cyan    = "\u001b[36m";
    public const string White   = "\u001b[37m";

    // Bright (90–97)
    public const string BrightBlack   = "\u001b[90m";
    public const string BrightRed     = "\u001b[91m";
    public const string BrightGreen   = "\u001b[92m";
    public const string BrightYellow  = "\u001b[93m";
    public const string BrightBlue    = "\u001b[94m";
    public const string BrightMagenta = "\u001b[95m";
    public const string BrightCyan    = "\u001b[96m";
    public const string BrightWhite   = "\u001b[97m";

    public static string Decode(CellColor cellColor) => cellColor switch {
      CellColor.Default => Reset,
      CellColor.Black => Black,
      CellColor.Red => Red,
      CellColor.Green => Green,
      CellColor.Yellow => Yellow,
      CellColor.Blue => Blue,
      CellColor.Magenta => Magenta,
      CellColor.Cyan => Cyan,
      CellColor.White => White,
      CellColor.Gray => BrightBlack,
      CellColor.BrightRed => BrightRed,
      CellColor.BrightGreen => BrightGreen,
      CellColor.BrightYellow => BrightYellow,
      CellColor.BrightBlue => BrightBlue,
      CellColor.BrightMagenta => BrightMagenta,
      CellColor.BrightCyan => BrightCyan,
      CellColor.BrightWhite => BrightWhite,
      _ => throw new NotImplementedException("Undefined AnsiColor: can't decode!"),
    };

    public static void ColorTestscreen()
    {
      Console.Write(Reset);

      Console.WriteLine($"░▒▓█ Default Color");
      Console.WriteLine($"{Black}░▒▓█ Black");
      Console.WriteLine($"{Red}░▒▓█ Red");
      Console.WriteLine($"{Green}░▒▓█ Green");
      Console.WriteLine($"{Yellow}░▒▓█ Yellow");
      Console.WriteLine($"{Blue}░▒▓█ Blue");
      Console.WriteLine($"{Magenta}░▒▓█ Magenta");
      Console.WriteLine($"{Cyan}░▒▓█ Cyan");
      Console.WriteLine($"{White}░▒▓█ White");

      Console.WriteLine($"{BrightBlack}░▒▓█ BrightBlack");
      Console.WriteLine($"{BrightRed}░▒▓█ BrightRed");
      Console.WriteLine($"{BrightGreen}░▒▓█ BrightGreen");
      Console.WriteLine($"{BrightYellow}░▒▓█ BrightYellow");
      Console.WriteLine($"{BrightBlue}░▒▓█ BrightBlue");
      Console.WriteLine($"{BrightMagenta}░▒▓█ BrightMagenta");
      Console.WriteLine($"{BrightCyan}░▒▓█ BrightCyan");
      Console.WriteLine($"{BrightWhite}░▒▓█ BrightWhite");

      Console.Write(Reset);
    }
  }
}
