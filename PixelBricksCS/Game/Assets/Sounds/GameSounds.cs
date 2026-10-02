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
  internal static class GameSounds
  {
    private const int SampleRate = 44100;
    private const int Channel1 = 1;
    private const double Mute = 0.0;

    // Rising pitch sweep – e.g. for rotating a piece
    public static ISampleProvider CreateRotate(double volume = EngineConfig.MenuSoundVolume) {
      SignalGenerator gen = new(SampleRate, Channel1) {
        Gain = volume,
        Type = SignalGeneratorType.Sweep,
        Frequency = 600,
        FrequencyEnd = 1200,
        SweepLengthSecs = 0.05 };
      OffsetSampleProvider cut = new(gen) { Take = TimeSpan.FromMilliseconds(50) };
      FadeInOutSampleProvider sound = new(cut);
      sound.BeginFadeOut(50);

      return sound;
    }

    // Short noise burst – e.g. when a piece lands
    public static ISampleProvider CreateLand(double volume = EngineConfig.MenuSoundVolume) {
      SignalGenerator gen = new(SampleRate, Channel1) { 
        Gain = volume, 
        Type = SignalGeneratorType.White };
      OffsetSampleProvider cut = new(gen) { 
        Take = TimeSpan.FromMilliseconds(60) };
      FadeInOutSampleProvider sound = new(cut);
      sound.BeginFadeOut(60);

      return sound;
    }

    // Fast rising arpeggio – e.g. for a cleared line
    public static ISampleProvider CreateLineClear(double volume = EngineConfig.MenuSoundVolume) {
      SignalGenerator gen1 = new(SampleRate, Channel1) { 
        Gain = volume, 
        Frequency = Notes.C5, 
        Type = SignalGeneratorType.Square };
      OffsetSampleProvider note1 = new(gen1) { 
        Take = TimeSpan.FromMilliseconds(35) };

      SignalGenerator gen2 = new(SampleRate, Channel1) {
        Gain = volume, 
        Frequency = Notes.E5, 
        Type = SignalGeneratorType.Square };
      OffsetSampleProvider note2 = new(gen2) { 
        Take = TimeSpan.FromMilliseconds(35) };

      SignalGenerator gen3 = new(SampleRate, Channel1) { 
        Gain = volume, 
        Frequency = Notes.G5, 
        Type = SignalGeneratorType.Square };
      OffsetSampleProvider note3 = new(gen3) { 
        Take = TimeSpan.FromMilliseconds(35) };

      SignalGenerator gen4 = new(SampleRate, Channel1) { 
        Gain = volume, 
        Frequency = Notes.C6, 
        Type = SignalGeneratorType.Square };
      OffsetSampleProvider note4Cut = new(gen4) { 
        Take = TimeSpan.FromMilliseconds(120) };

      FadeInOutSampleProvider note4 = new(note4Cut);
      note4.BeginFadeOut(120);

      ConcatenatingSampleProvider sound = new(new ISampleProvider[] { note1, note2, note3, note4 });
      return sound;
    }

    // Short fanfare – e.g. for leveling up
    public static ISampleProvider CreateLevelUp(double volume = EngineConfig.MenuSoundVolume) {
      SignalGenerator gen1 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.G5,
        Type = SignalGeneratorType.Square };
      OffsetSampleProvider note1 = new(gen1) {
        Take = TimeSpan.FromMilliseconds(60)};

      SignalGenerator pause = new(SampleRate, Channel1) {
        Gain = Mute};
      OffsetSampleProvider gap = new(pause) {
        Take = TimeSpan.FromMilliseconds(20) };

      SignalGenerator gen2 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.G5,
        Type = SignalGeneratorType.Square };
      OffsetSampleProvider note2 = new(gen2) {
        Take = TimeSpan.FromMilliseconds(60) };

      SignalGenerator gen3 = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.C6,
        Type = SignalGeneratorType.Square };
      OffsetSampleProvider note3Cut = new(gen3) {
        Take = TimeSpan.FromMilliseconds(250) };

      FadeInOutSampleProvider note3 = new(note3Cut);
      note3.BeginFadeOut(250);

      ConcatenatingSampleProvider sound = new(new ISampleProvider[] { note1, gap, note2, note3 });
      return sound;
    }

    // Slow falling pitch sweep – e.g. for game over
    public static ISampleProvider CreateGameOver(double volume = EngineConfig.MenuSoundVolume) {
      SignalGenerator gen = new(SampleRate, Channel1) {
        Gain = volume,
        Type = SignalGeneratorType.Sweep,
        Frequency = Notes.A4,
        FrequencyEnd = Notes.A2,
        SweepLengthSecs = 0.9 };
      OffsetSampleProvider cut = new(gen) { 
        Take = TimeSpan.FromMilliseconds(900) };

      FadeInOutSampleProvider sound = new(cut);
      sound.BeginFadeOut(900);

      return sound;
    }

    // Short, dull click – move left/right
    public static ISampleProvider CreateMove(double volume = EngineConfig.MenuSoundVolume) {
      SignalGenerator gen = new(SampleRate, Channel1) {
        Gain = volume,
        Frequency = Notes.A3,
        Type = SignalGeneratorType.Triangle };
      OffsetSampleProvider cut = new(gen) {
        Take = TimeSpan.FromMilliseconds(20) };

      FadeInOutSampleProvider sound = new(cut);
      sound.BeginFadeOut(20);

      return sound;
    }
  }
}
