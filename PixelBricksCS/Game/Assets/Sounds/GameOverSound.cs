using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using PixelBricksCS.Engine.Audio;
using PixelBricksCS.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace PixelBricksCS.Game.Assets.Sounds
{
  internal class GameOverSound
  {
    private const int SampleRate = 44100;
    private const int Channel1 = 1;
    private const double Mute = 0.0;

    // Descending GameBoy-style jingle – e.g. for game over
    // Soft descending jingle – e.g. for game over
    public static ISampleProvider Create(double volume = EngineConfig.MenuSoundVolume) {
      double softVolume = volume * 0.5;

      ConcatenatingSampleProvider jingle = new(new ISampleProvider[] {
        CreateTone(Notes.C5, 220, SignalGeneratorType.Square, softVolume, fadeOut: true),
        CreateRest(20),
        CreateTone(Notes.G4, 220, SignalGeneratorType.Square, softVolume, fadeOut: true),
        CreateRest(20),
        CreateTone(Notes.E4, 220, SignalGeneratorType.Square, softVolume, fadeOut: true),
        CreateRest(20),
        CreateTone(Notes.C4, 700, SignalGeneratorType.Square, softVolume, fadeOut: true)
      });

      return jingle;
    }

    private static ISampleProvider CreateTone(
      double freq, int ms, SignalGeneratorType type, double gain, bool fadeOut = false) {
      SignalGenerator gen = new(SampleRate, Channel1) {
        Gain = gain,
        Frequency = freq,
        Type = type
      };
      OffsetSampleProvider cut = new(gen) {
        Take = TimeSpan.FromMilliseconds(ms)
      };

      if (!fadeOut)
        return cut;

      FadeInOutSampleProvider faded = new(cut);
      faded.BeginFadeOut(ms);
      return faded;
    }

    private static ISampleProvider CreateRest(int ms) {
      SignalGenerator pause = new(SampleRate, Channel1) {
        Gain = Mute
      };
      return new OffsetSampleProvider(pause) {
        Take = TimeSpan.FromMilliseconds(ms)
      };
    }
  }
}
