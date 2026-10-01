using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using PixelBricksCS.Engine.Audio;
using PixelBricksCS.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Assets.Sounds
{
  internal static class StockMenuSounds
  {
    private const int SampleRate = MusicComposerUtils.SampleRate;
    private const int Channel1 = 1;
    private const double Mute = 0.0;

    // Short rising blip – e.g. for moving the menu cursor
    public static ISampleProvider CreateCursorBlip(double volume = EngineConfig.MenuSoundVolume) {
      SignalGenerator gen1 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.E5,
        Type = SignalGeneratorType.Square
      };
      OffsetSampleProvider note1 = new(gen1) {
        Take = TimeSpan.FromMilliseconds(20)
      };

      SignalGenerator gen2 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.A5,
        Type = SignalGeneratorType.Square
      };
      OffsetSampleProvider note2Cut = new(gen2) {
        Take = TimeSpan.FromMilliseconds(40)
      };

      FadeInOutSampleProvider note2 = new(note2Cut);
      note2.BeginFadeOut(40);

      ConcatenatingSampleProvider blip = new(new ISampleProvider[] { note1, note2 });

      return blip;
    }

    // Short single tick – e.g. for typing or scrolling
    public static ISampleProvider CreateTickBlip(double volume = EngineConfig.MenuSoundVolume) {
      SignalGenerator gen = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.C6,
        Type = SignalGeneratorType.Square
      };
      OffsetSampleProvider cut = new(gen) {
        Take = TimeSpan.FromMilliseconds(25)
      };

      FadeInOutSampleProvider blip = new(cut);
      blip.BeginFadeOut(25);

      return blip;
    }

    // Falling – e.g. for back or cancel
    public static ISampleProvider CreateCancleBlip(double volume = EngineConfig.MenuSoundVolume) {
      SignalGenerator gen1 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.A5,
        Type = SignalGeneratorType.Square
      };
      OffsetSampleProvider note1 = new(gen1) {
        Take = TimeSpan.FromMilliseconds(30)
      };

      SignalGenerator gen2 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.D5,
        Type = SignalGeneratorType.Square
      };
      OffsetSampleProvider note2Cut = new(gen2) {
        Take = TimeSpan.FromMilliseconds(60)
      };

      FadeInOutSampleProvider note2 = new(note2Cut);
      note2.BeginFadeOut(60);

      ConcatenatingSampleProvider blip = new(new ISampleProvider[] { note1, note2 });

      return blip;
    }

    // Three rising tones – e.g. for confirm
    public static ISampleProvider CreateConfirmationBlip(double volume = EngineConfig.MenuSoundVolume) {
      SignalGenerator gen1 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.E5,
        Type = SignalGeneratorType.Square
      };
      OffsetSampleProvider note1 = new(gen1) {
        Take = TimeSpan.FromMilliseconds(30)
      };

      SignalGenerator gen2 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.G5,
        Type = SignalGeneratorType.Square
      };
      OffsetSampleProvider note2 = new(gen2) {
        Take = TimeSpan.FromMilliseconds(30)
      };

      SignalGenerator gen3 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.C6,
        Type = SignalGeneratorType.Square
      };
      OffsetSampleProvider note3Cut = new(gen3) {
        Take = TimeSpan.FromMilliseconds(80)
      };

      FadeInOutSampleProvider note3 = new(note3Cut);
      note3.BeginFadeOut(80);

      ConcatenatingSampleProvider blip = new(new ISampleProvider[] { note1, note2, note3 });

      return blip;
    }

    // Low double buzz – e.g. for error or "not allowed"
    public static ISampleProvider CreateDenialBlip(double volume = EngineConfig.MenuSoundVolume) {
      SignalGenerator gen1 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.G3,
        Type = SignalGeneratorType.Square
      };
      OffsetSampleProvider note1 = new(gen1) {
        Take = TimeSpan.FromMilliseconds(60)
      };

      SignalGenerator pause = new(SampleRate, Channel1) {
        Gain = Mute
      };
      OffsetSampleProvider gap = new(pause) {
        Take = TimeSpan.FromMilliseconds(30)
      };

      SignalGenerator gen2 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.G3,
        Type = SignalGeneratorType.Square
      };
      OffsetSampleProvider note2Cut = new(gen2) {
        Take = TimeSpan.FromMilliseconds(90)
      };

      FadeInOutSampleProvider note2 = new(note2Cut);
      note2.BeginFadeOut(90);

      ConcatenatingSampleProvider blip = new(new ISampleProvider[] { note1, gap, note2 });

      return blip;
    }
  }
}