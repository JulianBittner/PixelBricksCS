# Sprint 5 – Animated splash screen

**Goal:** Show an animated block-letter title screen on startup, then hand off to the demo state.

---

## Tasks

### SplashScreen: animated title intro
Plays once on startup, animating the game title, then switches to the demo state.
**Done when:**
- [x] Letters drop in from above the screen, each starting slightly after the previous one (staggered, overlapping)
- [x] Each letter overshoots its resting position slightly, then snaps back up into place
- [x] Each letter has its own color
- [x] The full animation runs for roughly 2 seconds
- [x] After the animation finishes, the screen holds for about one second, then switches to the demo state

### GameMetadata: central game title and colors
Holds the game title string and its per-letter colors, so the splash screen and later screens share one source.
**Done when:**
- [x] Provides the game title as text
- [x] Provides the colors used for the title lettering

---

## Definition of Done (Sprint)
- [x] Running the program plays the title animation to completion, holds briefly, then transitions into the demo state.