using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

namespace PixelBricksCS.Engine.Platform;

/// <summary>
/// Enables ANSI escape sequence processing ("virtual terminal mode")
/// in the Windows console, so color codes embedded in output strings
/// are interpreted instead of printed literally.
///
/// This is standard Win32 interop boilerplate based on the documented
/// Windows Console API (ENABLE_VIRTUAL_TERMINAL_PROCESSING). The DllImport
/// signatures and flag values are dictated by the API itself.
/// Reference: https://learn.microsoft.com/en-us/windows/console/console-virtual-terminal-sequences
///
/// No-op consideration: modern Windows Terminal enables this by default;
/// this call ensures it also works in the legacy conhost console.
/// On non-Windows platforms this must not be called (kernel32 does not exist).
/// </summary>
internal static class VirtualTerminal
{
  private const int STD_OUTPUT_HANDLE = -11;
  private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

  [DllImport("kernel32.dll", SetLastError = true)]
  private static extern IntPtr GetStdHandle(int nStdHandle);

  [DllImport("kernel32.dll", SetLastError = true)]
  private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

  [DllImport("kernel32.dll", SetLastError = true)]
  private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

  /// <summary>
  /// Switches the console output mode to interpret ANSI/VT escape sequences.
  /// Call once during console setup, before any colored output.
  /// </summary>
  public static void Enable()
  {
    IntPtr handle = GetStdHandle(STD_OUTPUT_HANDLE);
    GetConsoleMode(handle, out uint mode);
    mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;
    SetConsoleMode(handle, mode);
  }
}