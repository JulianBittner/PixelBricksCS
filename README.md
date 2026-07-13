# PixelBricksCS

A falling-block puzzle game for the console, written in C# (.NET).

## About

PixelBricks is a learning project built entirely without external libraries or third-party code. The goal is to learn C# itself, and to understand and implement the core concepts of game programming from scratch — a custom console rendering pipeline, a game loop, input handling.

## Tech Stack

- C#
- .NET
- Output: Console (no external graphics framework)

## Project Structure

```
Engine/       Reusable engine tech (rendering, input, game loop)
Game/         Game-specific logic (board, pieces, states)
Assets/       Static content (shapes, colors, logo)
docs/         Project planning (backlog, sprints)
```

## Running

```
dotnet run
```

## Status

Actively in development. See `docs/BACKLOG.md` for the current feature set and roadmap.

## Note

This is a private, non-commercial learning project.
