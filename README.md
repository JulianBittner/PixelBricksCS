# PixelBricksCS

A falling-block puzzle game for the console, written in C# (.NET).

## About

PixelBricks is a learning project. The goal is to learn C# itself, and to understand and implement the core concepts of game programming from scratch — a custom console rendering pipeline, a composing system, a state machine, a frame-timed game loop, user input handling, and procedurally generated sound and music.

The only external dependency is [NAudio](https://github.com/naudio/NAudio), used solely to send audio to the sound card. Everything above that layer — sound effects, music, mixing — is generated in code from note data.

## Tech Stack

- C#
- .NET
- Output: Console (ANSI colors via virtual terminal, no external graphics framework)
- Audio: NAudio (output only; all sounds and music are generated procedurally)

## Architecture

The rendering pipeline turns game data into a visible frame in distinct stages:

```
Game data → Composing → FrameBuffer → Encoding → Console
```

- **Composing** — composers translate tile maps and text into cells, writing them into a shared frame buffer at a given position, driven by a renderer.
- **FrameBuffer** — a 2D grid of cells (character + color) holding a frame before output.
- **Encoding & Present** — the buffer is encoded to a single ANSI string and written to the console in one flicker-free pass.

The audio pipeline turns note data into sound:

```
Note data → Voices → Mixer → AudioPlayer → Sound card
```

- **Sounds & music tracks** — sound effects and multi-voice tracks (melody, bass, harmony) are built from notes and durations. Music tracks create a fresh stream on each restart, so they can loop.
- **AudioPlayer** — runs two persistent outputs: a low-latency channel for sound effects and a larger-buffered channel for crackle-free music. Both are triggered fire-and-forget without blocking the game loop.

The input pipeline turns key presses into game actions:

```
Keyboard → UserInput → ConsoleKey → Input mapper → Action → State logic
```

- **UserInput** — polls the keyboard once per frame without blocking the loop.
- **Input mappers** — the engine only delivers raw keys; game-specific mappers translate them into actions, keeping the engine free of game controls.

The **game loop** drives interchangeable states (via a state machine) frame by frame, using a frame timer to cap the frame rate and provide delta time. It polls the input and passes it to the active state.

## Project Structure

```
Engine/    Reusable engine tech (rendering, composing, audio, input, state machine)
Game/      Game-specific content (screens, assets, game data)
Sandbox/   Demos and experiments
docs/      Project planning and diagrams
```

## Running

```
dotnet run
```

Requires Windows (audio output uses WinMM).

## Status

Actively in development. See `docs/BACKLOG.md` for the current feature set and roadmap, and `docs/SPRINT.md` for the current sprint.

## Note

This is a private, non-commercial learning project.