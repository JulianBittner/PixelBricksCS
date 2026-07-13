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
- [ ] Holds a 2D grid of cells (character + color)
- [ ] A single cell can be set (character + color)
- [ ] Clear() resets the whole buffer to blank

### GameConsole.Present: flicker-free output
Send the buffer to the console in one go.
**Done when:**
- [ ] Full buffer is written with a single Console.Write (no per-cell writing)
- [ ] Uses SetCursorPosition(0,0) + overwrite instead of Console.Clear()
- [ ] Colors appear via embedded ANSI codes
- [ ] Test: manually set a few cells, Present, verify no flicker

---

## Definition of Done (Sprint)
- [ ] A test pattern (e.g. a moving █) runs smoothly and flicker-free in a loop, proving the full chain: write buffer → present → repeat.
