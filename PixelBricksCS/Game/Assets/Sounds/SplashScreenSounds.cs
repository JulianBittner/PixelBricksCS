using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using PixelBricksCS.Engine.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Assets.Sounds
{
  internal static class SplashScreenSounds
  {
    public static ISampleProvider CreateSplashScreenPling(double volume) {
      // Tone 1: short
      SignalGenerator gen1 = new(44100, 1) {
        Gain = volume,
        Frequency = Notes.A5,
        Type = SignalGeneratorType.Triangle
      };
      OffsetSampleProvider note1 = new(gen1) {
        Take = TimeSpan.FromMilliseconds(90)
      };

      // Tone 2: octave higher, fades out
      SignalGenerator gen2 = new(44100, 1) {
        Gain = volume,
        Frequency = Notes.E6,
        Type = SignalGeneratorType.Triangle
      };
      OffsetSampleProvider note2Cut = new(gen2) {
        Take = TimeSpan.FromMilliseconds(450)
      };

      FadeInOutSampleProvider note2 = new(note2Cut);
      note2.BeginFadeOut(450);

      // Assamble
      ConcatenatingSampleProvider pling = new(new ISampleProvider[] { note1, note2 });

      return pling;
    }
  }
}
