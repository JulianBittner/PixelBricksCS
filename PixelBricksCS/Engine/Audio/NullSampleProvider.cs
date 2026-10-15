using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace PixelBricksCS.Engine.Audio
{
  internal class NullSampleProvider : ISampleProvider
  {
    public static readonly NullSampleProvider Instance = new();

    public WaveFormat WaveFormat { get; } =
      WaveFormat.CreateIeeeFloatWaveFormat(MusicComposerUtils.SampleRate, 1);

    public int Read(float[] buffer, int offset, int count) => 0;
  }
}
