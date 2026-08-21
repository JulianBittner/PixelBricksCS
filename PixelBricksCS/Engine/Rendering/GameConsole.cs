using PixelBricksCS.Engine.Platform;
using System.Runtime.InteropServices;
using System.Text;

namespace PixelBricksCS.Engine.Rendering
{
  static class GameConsole
  {
    public static void InitConsole(int width, int height) {
      if (OperatingSystem.IsWindows()) {
        // Switches the console output mode to interpret ANSI/VT escape sequences
        VirtualTerminal.Enable();
        // Reset buffer size to avoid errors when resizing the window
        Console.SetWindowSize(1, 1);
        // +2 to inhibit the console from scrolling
        Console.SetBufferSize(width, height + 2);
        Console.SetWindowSize(width, height + 2);
      }
      Console.CursorVisible = false;
    }

    public static void Present(FrameBuffer fb) {
      Console.SetCursorPosition(0, 0);
      Console.WriteLine(FrameEncoding(fb));
    }

    public static string FrameEncoding(FrameBuffer fb) {
      StringBuilder encodedFrame = new StringBuilder();
      CellColor previouseCellColor = CellColor.Default;

      for (int y = 0; y < fb.Height; y++) {
        for (int x = 0; x < fb.Width; x++) {
          Cell currentCell = fb[y, x];
          if (previouseCellColor != currentCell.Color) {
            encodedFrame.Append(AnsiColorCode.Decode(currentCell.Color));
            previouseCellColor = currentCell.Color;
          }
          encodedFrame.Append(currentCell.Character);
        }
        encodedFrame.Append('\n');
      }

      return encodedFrame.ToString();
    }
  }
}
