using NAudio.Wave;
using PixelBricksCS.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Assets.Sounds
{
  internal class RumbleSound : ISampleProvider
  {
    private readonly Random _random = new();
    private readonly int _totalSamples;
    private readonly float _volume;
    private int _position;
    private int _holdCounter;
    private float _currentValue;

    private const int SampleRate = 44100;

    public WaveFormat WaveFormat { get; }

    public RumbleSound(int sampleRate, double seconds, double volume) {
      WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, 1);
      _totalSamples = (int)(sampleRate * seconds);
      _volume = (float)volume;
    }

    public int Read(float[] buffer, int offset, int count) {
      int written = 0;

      while (written < count && _position < _totalSamples) {
        double progress = (double)_position / _totalSamples;

        // Hold each noise value longer over time – the rumble gets deeper
        if (_holdCounter <= 0) {
          _currentValue = _random.Next(2) == 0 ? -1f : 1f;
          _holdCounter = 8 + (int)(progress * 200);
        }
        _holdCounter--;

        // Fade out with a curve, so the start hits hard
        float envelope = (float)((1.0 - progress) * (1.0 - progress));
        buffer[offset + written] = _currentValue * envelope * _volume;

        written++;
        _position++;
      }

      return written;
    }

    public static RumbleSound CreateRumble2Seconds() {
      return new RumbleSound(SampleRate, seconds:2, EngineConfig.GameSoundVolume);
    }
    public static RumbleSound CreateRumble1Seconds() {
      return new RumbleSound(SampleRate, seconds:1, EngineConfig.GameSoundVolume);
    }
    public static RumbleSound CreateRumble05Seconds() {
      return new RumbleSound(SampleRate, seconds:0.5, EngineConfig.GameSoundVolume);
    }
  }
}
