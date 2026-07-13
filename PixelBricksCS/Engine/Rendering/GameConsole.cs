using PixelBricksCS.Engine.Platform;
using System.Runtime.InteropServices;
using System.Text;

namespace PixelBricksCS.Engine.Rendering
{
  static class GameConsole
  {
    public static void InitConsole(int width, int height)
    {
      if (OperatingSystem.IsWindows())
      {
        // Switches the console output mode to interpret ANSI/VT escape sequences
        VirtualTerminal.Enable();
        // Reset buffer size to avoid errors when resizing the window
        Console.SetWindowSize(1, 1);
        // +1 to inhibit the console from scrolling
        Console.SetBufferSize(width, height + 1);
        Console.SetWindowSize(width, height + 1);
      }
      Console.CursorVisible = false;
    }
  }
}
