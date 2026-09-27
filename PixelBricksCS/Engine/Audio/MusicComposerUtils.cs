using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Audio
{
  internal static class MusicComposerUtils
  {
    public const int SampleRate = 44100;
    public const int Channel1 = 1;

    public static ISampleProvider CreateMixer(
      (double Freq, int Ms)[] melody,
      (double Freq, int Ms)[] bass,
      (double Freq, int Ms)[] harmony,
      double gain) {
      // STEP 1: Assamble all 3 voices
      ISampleProvider melodyVoice = BuildVoice(melody, SignalGeneratorType.Triangle, gain);
      ISampleProvider bassVoice = BuildVoice(bass, SignalGeneratorType.Triangle, gain);
      ISampleProvider harmonyVoice = BuildVoice(harmony, SignalGeneratorType.Triangle, (gain * 0.6));

      // STEP 2: Create a mixer and route all voices into it.
      MixingSampleProvider mixer = new(WaveFormat.CreateIeeeFloatWaveFormat(SampleRate, Channel1));
      mixer.AddMixerInput(melodyVoice);
      mixer.AddMixerInput(bassVoice);
      mixer.AddMixerInput(harmonyVoice);

      return mixer;
    }

    private static ISampleProvider BuildVoice(
      (double Freq, int Ms)[] notes,
      SignalGeneratorType type, double gain) {
      ISampleProvider[] providers = new ISampleProvider[notes.Length];

      for (int i = 0; i < notes.Length; i++) {
        SignalGenerator generator = new(SampleRate, Channel1);
        generator.Gain = gain;
        generator.Frequency = notes[i].Freq;
        generator.Type = type;

        OffsetSampleProvider tone = new(generator);
        tone.Take = TimeSpan.FromMilliseconds(notes[i].Ms);

        FadeInOutSampleProvider faded = new(tone);
        faded.BeginFadeOut(notes[i].Ms);

        providers[i] = faded;
      }

      return new ConcatenatingSampleProvider(providers);
    }
  }
}
