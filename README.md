# PixelBricksCS

A falling-block puzzle game for the console, written in C# (.NET).

## About

PixelBricks is a learning project built entirely without external libraries or third-party code. The goal is to learn C# itself, and to understand and implement the core concepts of game programming from scratch — a custom console rendering pipeline, a composing system, a state machine, and a frame-timed game loop.

## Tech Stack

- C#
- .NET
- Output: Console (ANSI colors via virtual terminal, no external graphics framework)

## Architecture

The rendering pipeline turns game data into a visible frame in distinct stages:

```
Game data → Composing → FrameBuffer → Encoding → Console
```

- **Composing** — composers translate tile maps and text into cells, writing them into a shared frame buffer at a given position, driven by a renderer.
- **FrameBuffer** — a 2D grid of cells (character + color) holding a frame before output.
- **Encoding & Present** — the buffer is encoded to a single ANSI string and written to the console in one flicker-free pass.

The **game loop** drives interchangeable states (via a state machine) frame by frame, using a frame timer to cap the frame rate and provide delta time.

## Project Structure

```
Engine/           Reusable engine tech
├── Rendering/    Frame buffer, cells, console output
├── Composing/    Composers, tiles, sprites
├── Core/         Shared value types
├── StateMachine/ Game loop, states, timers
├── Diagnostics/  Debug overlay and logging
├── Platform/     OS-specific setup (ANSI terminal)
└── Assets/       Engine-level static content (fonts)

Game/             Game-specific content
├── SplashScreen/ Animated title intro
├── Assets/       Tile sets
├── GameMetadata  Title text and colors
└── MinoID        Shared tile identifiers

Sandbox/          Demos and experiments
docs/             Project planning (backlog, sprints) and diagrams
```

## Running

```
dotnet run
```

## Status

Actively in development. See `docs/BACKLOG.md` for the current feature set and roadmap, and `docs/SPRINT.md` for the current sprint.

## Note

This is a private, non-commercial learning project.
