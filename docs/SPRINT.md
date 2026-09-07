# Sprint 1 – Rendering Foundation

**Goal:** A visible, flicker-free rendering chain — I can put content into a buffer and see it on screen.

---

## Tasks

### GameConsole: console setup
Configure the console for game output.
**Done when:**
- [x] Window has a fixed size
- [x] Cursor is hidden
- [x] Unicode blocks (█) render correctly
- [x] Virtual terminal processing enabled (ANSI color codes are interpreted, not printed literally)

### FrameBuffer: 2D cell buffer
Data structure holding the frame before it's encoded and drawn.
**Done when:**
- [x] Holds a 2D grid of cells (character + color)
- [x] A single cell can be set (character + color)
- [x] Clear() resets the whole buffer to blank

### GameConsole.Present: flicker-free output
Send the buffer to the console in one go.
**Done when:**
- [x] Full buffer is written with a single Console.Write (no per-cell writing)
- [x] Uses SetCursorPosition(0,0) + overwrite instead of Console.Clear()
- [x] Colors appear via embedded ANSI codes
- [x] Test: manually set a few cells, Present, verify no flicker

### TileMapComposer: generic tile-based composing
Composes a region from a tile map and tile set, using a shared enum to enforce valid tile IDs.
**Done when:**
- [X] ITileMap<T> and ITileSet<T> are constrained to the same enum type, so mismatched map/set combinations fail at compile time
- [X] TileMapComposer writes each map entry as two adjacent cells with the tile's symbols and color
- [X] Out-of-range tile IDs are impossible (enforced by the enum) or fail loudly
- [X] A demo board renders visibly and correctly in the console

---

## Definition of Done (Sprint)
- [X] A test pattern (e.g. a moving █) runs smoothly and flicker-free in a loop, proving the full chain: write buffer → present → repeat.
