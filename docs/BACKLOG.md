# PixelBricks – Backlog

Rough overview of all planned features. Serves as a roadmap. Details are worked out shortly before implementation in the respective `SPRINT.md`.

## 1. Foundation (Engine)
- [x] GameConsole: console setup (window size, cursor hidden, Unicode output, colors)
- [ ] FrameBuffer: 2D cell buffer (character + color), set/clear operations
- [ ] GameConsole.Present: flicker-free output of the full buffer to the console
- [ ] Game loop: fixed update rate, delta time, input polling, render call
- [ ] ConsoleInput: non-blocking key polling
- [ ] Player: holds key bindings (key → action); active state decides what each action does
- [ ] State interface (IGameState: HandleInput, Update, Render) + state switching

## 2. Core Gameplay
- [ ] Board: grid data structure (10×20), occupied/free cells
- [ ] Board composer (composes the playing field region incl. border; renderer assembles composed regions)
- [ ] Tetromino: data model (cells, position, color)
- [ ] Tetromino shape definitions (all 7 pieces: I, O, T, S, Z, J, L)
- [ ] Spawning: new piece appears at top of the board
- [ ] Gravity: piece falls automatically at a fixed interval
- [ ] Collision detection (walls, floor, locked blocks)
- [ ] Locking: piece freezes into the board when it lands

## 3. Player Controls (in-game)
- [ ] Sideways movement (left/right)
- [ ] Rotation (clockwise; counterclockwise optional)
- [ ] Wall kicks (rotation near walls/blocks shifts the piece if possible)
- [ ] Soft drop (accelerated falling while key held)
- [ ] Hard drop (instant drop and lock)

## 4. Game Rules
- [ ] Detect full rows
- [ ] Clear full rows + shift rows above down
- [ ] Scoring (points per line clear; more for multi-line clears, e.g. Tetris = 4 lines)
- [ ] Level system (level increases after N cleared lines)
- [ ] Difficulty scaling (fall speed increases with level)
- [ ] Randomizer: 7-bag (each of the 7 pieces once per bag, shuffled)
- [ ] Game-over detection (new piece cannot spawn / stack reaches top)
- [ ] Lock delay (short grace period to move/rotate after touching down) — optional, classic feel works without

## 5. HUD (in-game UI)
- [ ] Score display
- [ ] Level display
- [ ] Cleared-lines counter
- [ ] Next-piece preview
- [ ] Layout: playing field + side panel arrangement in the buffer

## 6. Menu & App Flow
- [ ] Title/splash screen with logo (ASCII art)
- [ ] Menu layout and rendering (title, selectable items)
- [ ] Menu items: Start Game, Exit (Options later if needed)
- [ ] Selection logic (highlighted item, up/down navigation, confirm)
- [ ] App flow wiring: app starts into menu → menu starts game
- [ ] Pause state (freeze gameplay, show pause overlay, resume/quit)
- [ ] Game-over screen (final score, restart or back to menu)

## 7. Polish (optional, later)
- [ ] Ghost piece (landing position preview)
- [ ] Hold piece (stash current piece, swap once per drop)
- [ ] Color scheme per tetromino type (guideline colors)
- [ ] High score storage (persist to file)
- [ ] Line-clear animation (brief flash before rows collapse)
- [ ] Sound effects (console beep — if feasible and not annoying)
- [ ] Smooth difficulty curve tuning
