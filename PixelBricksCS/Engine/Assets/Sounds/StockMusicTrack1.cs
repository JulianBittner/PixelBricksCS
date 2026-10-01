using NAudio.Wave;
using PixelBricksCS.Engine.Audio;
using PixelBricksCS.Engine.Core;
using N = PixelBricksCS.Engine.Audio.Notes;
using D = PixelBricksCS.Engine.Audio.NoteDurations;

namespace PixelBricksCS.Engine.Assets.Sounds
{
  internal class StockMusicTrack1 : IMusicTrack
  {
    double IMusicTrack.DurationSeconds => _durationSeconds;
    ISampleProvider IMusicTrack.CreateTrack(double volume) {
      return MusicComposerUtils.CreateMixer(_melody, _bass, _harmony, volume);
    }

    private static readonly (double Freq, int Ms)[] _melody = {
      // Phrase 1 – gentle, easy-going melody
      (N.C5, D.H), (N.E5, D.Q), (N.G5, D.Q),
      (N.A5, D.H), (N.G5, D.H),
      (N.E5, D.H), (N.C5, D.Q), (N.D5, D.Q),
      (N.C5, D.W),

      // Phrase 2 – slight lift
      (N.D5, D.H), (N.F5, D.Q), (N.A5, D.Q),
      (N.G5, D.H), (N.E5, D.H),
      (N.F5, D.H), (N.D5, D.Q), (N.E5, D.Q),
      (N.C5, D.W),

      // Phrase 3 – calm answer
      (N.E5, D.H), (N.G5, D.Q), (N.C6, D.Q),
      (N.A5, D.H), (N.G5, D.H),
      (N.F5, D.H), (N.E5, D.Q), (N.D5, D.Q),
      (N.C5, D.W),

      // Phrase 4 – resolve back to the top
      (N.G5, D.H), (N.E5, D.H),
      (N.D5, D.H), (N.C5, D.H),
      (N.E5, D.Q), (N.D5, D.Q), (N.C5, D.Q), (N.G4, D.Q),
      (N.C5, D.W),
    };

    private static readonly (double Freq, int Ms)[] _bass = {
      // Phrase 1 – simple root movement
      (N.C3, D.W),
      (N.A2, D.W),
      (N.F2, D.W),
      (N.G2, D.W),

      // Phrase 2
      (N.F2, D.W),
      (N.G2, D.W),
      (N.A2, D.W),
      (N.C3, D.W),

      // Phrase 3
      (N.C3, D.W),
      (N.A2, D.W),
      (N.F2, D.W),
      (N.G2, D.W),

      // Phrase 4
      (N.E2, D.W),
      (N.F2, D.W),
      (N.G2, D.W),
      (N.C3, D.W),
    };

    private static readonly (double Freq, int Ms)[] _harmony = {
      // Phrase 1 – soft off-beat chords
      (N.E4, D.H), (N.G4, D.H),
      (N.C4, D.H), (N.E4, D.H),
      (N.A3, D.H), (N.C4, D.H),
      (N.B3, D.H), (N.D4, D.H),

      // Phrase 2
      (N.A3, D.H), (N.C4, D.H),
      (N.B3, D.H), (N.D4, D.H),
      (N.C4, D.H), (N.E4, D.H),
      (N.E4, D.H), (N.G4, D.H),

      // Phrase 3
      (N.E4, D.H), (N.G4, D.H),
      (N.C4, D.H), (N.E4, D.H),
      (N.A3, D.H), (N.C4, D.H),
      (N.B3, D.H), (N.D4, D.H),

      // Phrase 4
      (N.G3, D.H), (N.C4, D.H),
      (N.A3, D.H), (N.C4, D.H),
      (N.B3, D.H), (N.D4, D.H),
      (N.E4, D.H), (N.G4, D.H),
    };

    public static readonly double _durationSeconds = MusicComposerUtils.GetDurationSeconds(_melody);
  }
}