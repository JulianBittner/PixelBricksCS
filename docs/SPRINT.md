# Sprint 5 – Animated splash screen and audio

**Goal:** Show an animated block-letter title screen with sound on startup, then hand off to the demo state.

---

## Tasks

### SplashScreen: animated title intro
Plays once on startup, animating the game title, then switches to the demo state.
**Done when:**
- [x] Letters drop in from above the screen, each starting slightly after the previous one (staggered, overlapping)
- [x] Each letter overshoots its resting position slightly, then snaps back up into place
- [x] Each letter has its own color
- [x] The full animation runs for roughly 2 seconds
- [x] A startup pling plays during the animation without blocking it
- [x] After the animation finishes, the screen holds for about one second, then switches to the demo state

### GameMetadata: central game title and colors
Holds the game title string and its per-letter colors, so the splash screen and later screens share one source.
**Done when:**
- [x] Provides the game title as text
- [x] Provides the colors used for the title lettering

### AudioPlayer: mixer-based audio output
A single global audio output, so sounds can be triggered at any time without re-initializing playback.
**Done when:**
- [x] One WaveOutEvent keeps running with a MixingSampleProvider that outputs silence when idle
- [x] Sounds are started fire-and-forget and never block the game loop
- [x] Multiple sounds can play at the same time
- [x] States access audio through IAudioHandle, integrated via IEngineState and GameLoop

### Procedural sounds and music
Sounds and tracks are generated from note data instead of audio files.
**Done when:**
- [x] Notes (C2–B6) and NoteDurations define pitches and lengths
- [x] MusicComposerUtils builds multi-voice tracks (melody, bass, harmony)
- [x] StockSoundsFactory and StockMusicFactory ship generic sounds and tracks with the engine
- [x] GameSoundsFactory and GameMusicFactory provide the game-specific sounds and tracks

---

## Definition of Done (Sprint)
- [x] Running the program plays the title animation with its startup sound, holds briefly, then transitions into the demo state.