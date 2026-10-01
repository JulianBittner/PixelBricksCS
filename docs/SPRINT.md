# Sprint 6 – User input and main menu

**Goal:** React to player input and navigate from a main menu to a clean program exit.

---

## Tasks

### UserInput: non-blocking key polling
Reads keyboard input once per frame without stopping the game loop.
**Done when:**
- [x] Poll() returns the pressed key without blocking the loop
- [x] The console input buffer is drained each frame, so held keys don't lag behind
- [x] GameLoop passes the polled key to the active state via Update

### Player: key bindings
Translates raw keys into game actions, so states work with actions instead of keys.
**Done when:**
- [x] Presses a key → action mapping
- [x] Keys without a binding are ignored
- [x] The active state decides what each action does

### MenuScreen: main menu
The first interactive screen after the splash screen.
**Done when:**
- [x] The splash screen hands off to the menu instead of the demo state
- [x] Shows a Play and an Credits button with an Exit button below it
- [x] The selection moves between the buttons with the arrow keys and is highlighted
- [x] Confirming Play plays the error sound (game not available yet)
- [x] Confirming Exit switches to the exit screen
- [x] Plays music in a loop
- [x] Music stops, if Menu leavs to another context-state

### ExitScreen: clean shutdown
Shown when leaving the program, before the loop ends.
**Done when:**
- [x] Shows a short goodbye screen
- [x] Requests shutdown after a brief delay
- [x] The console is left in a clean state after the program ends

---

## Definition of Done (Sprint)
- [x] Running the program plays the splash screen, opens the menu, plays the error sound on Play, and exits cleanly via the Exit button and exit screen.