using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Audio
{
  internal class AudioPlayer : IAudioHandle, IDisposable
  {
    private const int SampleRate = 44100;
    private const int Channel1 = 1;

    private readonly WaveOutEvent _output = new();
    private readonly MixingSampleProvider _mixer = 
      new(WaveFormat.CreateIeeeFloatWaveFormat(SampleRate, Channel1)) { ReadFully = true };

    public void Init() {
      _output.Init(_mixer);
    }
    public void Start() {
      _output.Play();
    }    
    public void Stop() {
      _output.Stop();
    }
    public void PlaySound(ISampleProvider sample) {
      _mixer.AddMixerInput(sample);
    }

    public void Dispose() {
      _output.Dispose();
    }
  }
}
