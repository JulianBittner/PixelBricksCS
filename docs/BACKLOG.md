# PixelBricks – Backlog

Rough overview of all planned features. Serves as a roadmap. Details are worked out shortly before implementation in the respective `SPRINT.md`.

## 1. Foundation (Engine)
- [x] GameConsole: console setup (window size, cursor hidden, Unicode output, colors)
- [x] FrameBuffer: 2D cell buffer (character + color), set/clear operations
- [x] GameConsole.Present: flicker-free output of the full buffer to the console
- [x] Composers: TileMapComposer and TextComposer translate game data into cell data and write it to a region
- [x] Renderer: consolidates all composers and runs them in order to render a FrameBuffer
- [x] Game loop: fixed update rate, delta time, input polling, render call
- [x] State interface (IGameState: HandleInput, Update, Render) + state switching
- [x] Game Sound: A sounds system plays sound and jingles  
- [x] ConsoleInput: non-blocking key polling
- [x] Player: holds key bindings (key → action); active state decides what each action does

## 2. Core Gameplay
- [x] Board: grid data structure (14×24), occupied/free cells
- [x] Bricks: grid data model (cells, position, color)
- [x] Bricks shape definitions (7 pieces: I, O, T, S, Z, J, L)
- [x] Brick composer (composes the current Brick to the field)

## 3. Player Controls (in-game)
- [x] Sideways movement (left/right)
- [ ] Rotation (clockwise; counterclockwise optional)
- [ ] Collision: the brick cannot move through the board walls
- [ ] Wall kicks (rotation near walls/blocks shifts the piece if possible)
- [ ] Hard drop (instant drop and lock)

## 4. Game Rules
- [ ] Every x seconds, a new row spawns at the top of the ceiling and pushes it one row down
- [ ] The descent speed increases with the collected points
- [ ] The brick is fixed vertically at the bottom of the board and can only move left and right
- [ ] Pressing Space launches the brick straight up; it lands at the ceiling and blasts all pixels it touches
- [ ] Every blasted pixel scores one point 

## 5. HUD (in-game UI)
- [ ] Score display
- [ ] Level display
- [ ] Cleared-lines counter
- [ ] Next-piece preview
- [ ] Layout: playing field + side panel arrangement in the buffer

## 6. Menu & App Flow
- [x] Title/splash screen: block-letter logo with drop-in animation on startup
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
