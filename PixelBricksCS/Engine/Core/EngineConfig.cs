using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Core
{
  internal static class EngineConfig
  {
    // Grafics
    public static readonly GridSize GameConsoleSize = new(40, 80);
    public const int FramesPerSecond = 60;

    // Debugging
    public const bool DiagnosticsOverlayEnabled = true;
    public const int  DebugOverlayRaw = 30;
  }
}
