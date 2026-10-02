using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using PixelBricksCS.Engine.Audio;
using PixelBricksCS.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Assets.Sounds
{ 
  internal static class ExitScreenSound
  {
    private const int SampleRate = MusicComposerUtils.SampleRate;
    private const int Channel1 = 1;

    // Descending three-tone farewell – mirror image of the startup pling
    public static ISampleProvider CreateFarewell(double volume = EngineConfig.MenuSoundVolume) {
      SignalGenerator gen1 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.C5,
        Type = SignalGeneratorType.Square
      };
      OffsetSampleProvider note1 = new(gen1) {
        Take = TimeSpan.FromMilliseconds(90)
      };

      SignalGenerator gen2 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.G4,
        Type = SignalGeneratorType.Square
      };
      OffsetSampleProvider note2 = new(gen2) {
        Take = TimeSpan.FromMilliseconds(90)
      };

      SignalGenerator gen3 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.C4,
        Type = SignalGeneratorType.Square
      };
      OffsetSampleProvider note3Cut = new(gen3) {
        Take = TimeSpan.FromMilliseconds(400)
      };

      FadeInOutSampleProvider note3 = new(note3Cut);
      note3.BeginFadeOut(400);

      ConcatenatingSampleProvider sound = new(new ISampleProvider[] { note1, note2, note3 });

      return sound;
    }
  }  
}
