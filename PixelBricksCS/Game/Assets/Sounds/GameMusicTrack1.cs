using NAudio.Wave;
using PixelBricksCS.Engine.Audio;
using PixelBricksCS.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;
using D = PixelBricksCS.Engine.Audio.NoteDurations;
using N = PixelBricksCS.Engine.Audio.Notes;

namespace PixelBricksCS.Game.Assets.Sounds
{
  internal class GameMusicTrack1 : IMusicTrack
  {
    double IMusicTrack.DurationSeconds => _durationSeconds;

    ISampleProvider IMusicTrack.CreateTrack(double volume) {
      return MusicComposerUtils.CreateMixer(_melody, _bass, _harmony, volume);
    }

    private static readonly (double Freq, int Ms)[] _melody = {
      // Phrase 1 – main riff: quick repeated notes, then a held note
      (N.E5, D.E), (N.E5, D.E), (N.A5, D.Q), (N.G5, D.E), (N.E5, D.E), (N.D5, D.Q),
      (N.E5, D.H), (N.C5, D.Q), (N.D5, D.Q),
      (N.E5, D.E), (N.E5, D.E), (N.A5, D.Q), (N.B5, D.E), (N.A5, D.E), (N.G5, D.Q),
      (N.A5, D.HD), (N.G5, D.Q),

      // Phrase 2 – riff variation, climbing higher
      (N.C6, D.E), (N.B5, D.E), (N.A5, D.Q), (N.G5, D.E), (N.E5, D.E), (N.G5, D.Q),
      (N.A5, D.H), (N.E5, D.Q), (N.G5, D.Q),
      (N.F5, D.E), (N.F5, D.E), (N.E5, D.Q), (N.D5, D.E), (N.C5, D.E), (N.D5, D.Q),
      (N.E5, D.W),

      // Phrase 3 – bridge: longer notes, building up
      (N.F5, D.QD), (N.E5, D.E), (N.D5, D.H),
      (N.C5, D.QD), (N.D5, D.E), (N.E5, D.H),
      (N.F5, D.Q), (N.G5, D.Q), (N.A5, D.Q), (N.B5, D.Q),
      (N.C6, D.H), (N.B5, D.Q), (N.G5, D.Q),

      // Phrase 4 – riff returns and resolves to A
      (N.E5, D.E), (N.E5, D.E), (N.A5, D.Q), (N.G5, D.E), (N.E5, D.E), (N.D5, D.Q),
      (N.E5, D.H), (N.C5, D.Q), (N.D5, D.Q),
      (N.C5, D.E), (N.D5, D.E), (N.E5, D.Q), (N.D5, D.E), (N.C5, D.E), (N.B4, D.Q),
      (N.A4, D.W),
    };

    private static readonly (double Freq, int Ms)[] _bass = {
      // Phrase 1 – pumping octave eighths (Am | F | Am | G)
      (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E),
      (N.F2, D.E), (N.F3, D.E), (N.F2, D.E), (N.F3, D.E), (N.F2, D.E), (N.F3, D.E), (N.F2, D.E), (N.F3, D.E),
      (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E),
      (N.G2, D.E), (N.G3, D.E), (N.G2, D.E), (N.G3, D.E), (N.G2, D.E), (N.G3, D.E), (N.G2, D.E), (N.G3, D.E),

      // Phrase 2 – (C | Am | Dm | E)
      (N.C3, D.E), (N.C4, D.E), (N.C3, D.E), (N.C4, D.E), (N.C3, D.E), (N.C4, D.E), (N.C3, D.E), (N.C4, D.E),
      (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E),
      (N.D3, D.E), (N.D4, D.E), (N.D3, D.E), (N.D4, D.E), (N.D3, D.E), (N.D4, D.E), (N.D3, D.E), (N.D4, D.E),
      (N.E2, D.E), (N.E3, D.E), (N.E2, D.E), (N.E3, D.E), (N.E2, D.E), (N.E3, D.E), (N.E2, D.E), (N.E3, D.E),

      // Phrase 3 – (Dm | Am | F | G)
      (N.D3, D.E), (N.D4, D.E), (N.D3, D.E), (N.D4, D.E), (N.D3, D.E), (N.D4, D.E), (N.D3, D.E), (N.D4, D.E),
      (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E),
      (N.F2, D.E), (N.F3, D.E), (N.F2, D.E), (N.F3, D.E), (N.F2, D.E), (N.F3, D.E), (N.F2, D.E), (N.F3, D.E),
      (N.G2, D.E), (N.G3, D.E), (N.G2, D.E), (N.G3, D.E), (N.G2, D.E), (N.G3, D.E), (N.G2, D.E), (N.G3, D.E),

      // Phrase 4 – (Am | F | E | Am)
      (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E), (N.A2, D.E), (N.A3, D.E),
      (N.F2, D.E), (N.F3, D.E), (N.F2, D.E), (N.F3, D.E), (N.F2, D.E), (N.F3, D.E), (N.F2, D.E), (N.F3, D.E),
      (N.E2, D.E), (N.E3, D.E), (N.E2, D.E), (N.E3, D.E), (N.E2, D.E), (N.E3, D.E), (N.E2, D.E), (N.E3, D.E),
      (N.A2, D.W),
    };

    private static readonly (double Freq, int Ms)[] _harmony = {
      // Phrase 1 – arpeggiated chords in quarters (Am | F | Am | G)
      (N.A3, D.Q), (N.C4, D.Q), (N.E4, D.Q), (N.C4, D.Q),
      (N.F3, D.Q), (N.A3, D.Q), (N.C4, D.Q), (N.A3, D.Q),
      (N.A3, D.Q), (N.C4, D.Q), (N.E4, D.Q), (N.C4, D.Q),
      (N.G3, D.Q), (N.B3, D.Q), (N.D4, D.Q), (N.B3, D.Q),

      // Phrase 2 – (C | Am | Dm | E)
      (N.C4, D.Q), (N.E4, D.Q), (N.G4, D.Q), (N.E4, D.Q),
      (N.A3, D.Q), (N.C4, D.Q), (N.E4, D.Q), (N.C4, D.Q),
      (N.D4, D.Q), (N.F4, D.Q), (N.A4, D.Q), (N.F4, D.Q),
      (N.E3, D.Q), (N.B3, D.Q), (N.E4, D.Q), (N.B3, D.Q),

      // Phrase 3 – (Dm | Am | F | G)
      (N.D4, D.Q), (N.F4, D.Q), (N.A4, D.Q), (N.F4, D.Q),
      (N.A3, D.Q), (N.C4, D.Q), (N.E4, D.Q), (N.C4, D.Q),
      (N.F3, D.Q), (N.A3, D.Q), (N.C4, D.Q), (N.A3, D.Q),
      (N.G3, D.Q), (N.B3, D.Q), (N.D4, D.Q), (N.B3, D.Q),

      // Phrase 4 – (Am | F | E | Am)
      (N.A3, D.Q), (N.C4, D.Q), (N.E4, D.Q), (N.C4, D.Q),
      (N.F3, D.Q), (N.A3, D.Q), (N.C4, D.Q), (N.A3, D.Q),
      (N.E3, D.Q), (N.B3, D.Q), (N.E4, D.Q), (N.B3, D.Q),
      (N.A3, D.W),
    };

    private static readonly double _durationSeconds = MusicComposerUtils.GetDurationSeconds(_melody);
  }
}
