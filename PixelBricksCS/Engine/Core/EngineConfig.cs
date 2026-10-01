using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Core
{
  internal static class EngineConfig
  {
    // Grafics
    public static readonly GridSize GameConsoleSize = new(40, 82);
    public const int FramesPerSecond = 60;

    // Audio
    public const double MasterSoundVolume = 1.0;
    public const double MusikVolume       = 0.1 * MasterSoundVolume;
    public const double MenuSoundVolume   = 0.15 * MasterSoundVolume;
    public const double GameSoundVolume   = 0.2 * MasterSoundVolume;

    // Debugging
    public const bool DiagnosticsOverlayEnabled = true;
    public const int  DebugOverlayRaw = 30;
  }
}
