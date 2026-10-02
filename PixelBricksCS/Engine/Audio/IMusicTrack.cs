using NAudio.Wave;
using PixelBricksCS.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Audio
{
  internal interface IMusicTrack
  {
    public double DurationSeconds { get; }
    ISampleProvider CreateTrack(double volume = EngineConfig.MusikVolume);
  }
}
