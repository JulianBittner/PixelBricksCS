using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using PixelBricksCS.Engine.StateMachine;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Audio
{
  internal class AudioPlayer : IAudioHandle, IDisposable
  {
    private const int SampleRate = 44100;
    private const int Channel1 = 1;

    private readonly WaveOutEvent _soundOutput = new();
    private readonly MixingSampleProvider _soundMixer = 
      new(WaveFormat.CreateIeeeFloatWaveFormat(SampleRate, Channel1)) { ReadFully = true };

    private readonly WaveOutEvent _musicOutput = new();
    private readonly MixingSampleProvider _musicMixer =
      new(WaveFormat.CreateIeeeFloatWaveFormat(SampleRate, Channel1)) { ReadFully = true };
    private IMusicTrack? _currentMusicTrack = null;
    private CountdownTimer _musicTimer = new(Seconds: 0.0);

    public void Init() {
      _soundOutput.DesiredLatency = 70;
      _soundOutput.Init(_soundMixer);
      _musicOutput.DesiredLatency = 200;
      _musicOutput.Init(_musicMixer);
    }
    public void Open() {
      _soundOutput.Play();
      _musicOutput.Play();
    }

    public void Close() {
      _soundOutput.Stop();
      _musicOutput.Stop();
    }

    void IAudioHandle.PlaySound(ISampleProvider sampleTrack) {
      _soundMixer.AddMixerInput(sampleTrack);
    }

    void IAudioHandle.PlayMusicLoop(IMusicTrack musicTrack) {
      _currentMusicTrack = musicTrack;
      _musicTimer.SetDurationSeconds(_currentMusicTrack.DurationSeconds);
      _musicMixer.AddMixerInput(_currentMusicTrack.CreateTrack());
    }

    void IAudioHandle.StopMusicLoop() {
      _musicMixer.RemoveAllMixerInputs();
      _currentMusicTrack = null;
    }

    public void UpdateMusicLoop(double deltaTime) {
      if (_currentMusicTrack == null) return;
      if (_musicTimer.TimeUp(deltaTime)) {
        _musicTimer.Reset();
        _musicMixer.AddMixerInput(_currentMusicTrack.CreateTrack());
      }
    }

    public void Dispose() {
      _soundOutput.Dispose();
      _musicOutput.Dispose();
    }

  }
}
