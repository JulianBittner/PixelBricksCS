using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Platform;
using System.Runtime.InteropServices;
using System.Text;

namespace PixelBricksCS.Engine.Rendering
{
  static class GameConsole
  {
    public static void InitConsole() {
      int width  = EngineConfig.GameConsoleSize.Width;
      int height = EngineConfig.GameConsoleSize.Height;

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

    public static void Present(FrameBuffer frameBuffer) {
      Console.SetCursorPosition(0, 0);
      Console.WriteLine(FrameEncoding(frameBuffer));
    }

    /// <summary>
    /// Resets the cursor to prevent the last frame from scrolling up after the program exit screen
    /// </summary>
    public static void ResetCursorPosition() { 
      Console.SetCursorPosition(0, (EngineConfig.GameConsoleSize.Height/2));
    }

    public static string FrameEncoding(FrameBuffer frameBuffer) {
      StringBuilder encodedFrame = new StringBuilder();
      CellColor previouseCellColor = CellColor.Default;

      for (int y = 0; y < frameBuffer.Height; y++) {
        for (int x = 0; x < frameBuffer.Width; x++) {
          Cell currentCell = frameBuffer[y, x];
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
