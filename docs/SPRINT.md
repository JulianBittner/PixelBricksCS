## Sprint 4 – Game loop and state machine

**Goal:** A running engine core that drives interchangeable states frame by frame at a stable rate.

---

### GameLoop: central loop driving game states
The entry point for the game, holding all registered states and running the
active one frame by frame until shutdown.
**Done when:**
- [x] Holds registered states in a dictionary keyed by state ID
- [x] Starts with a given initial state, validated as registered before Run()
- [x] Each frame: updates and renders the active state, then presents it
- [x] Switches state when a change is requested (Exit old, Enter new)
- [x] Exits cleanly when shutdown is requested

### IEngineState: interchangeable engine states
A common contract for states like menu or game, each managing its own
rendering and logic.
**Done when:**
- [x] Defines Enter, Update, Render, Exit and a StateID
- [x] States build their own rendering pipeline and static content in a separate init step, not the constructor
- [x] The active state receives the loop as its context on Enter

### State switching: request-based transitions
States signal a desired switch; the loop performs it at a safe point in the frame.
**Done when:**
- [x] A state can request a transition via the context handle
- [x] The loop applies the switch after update/render, not mid-state
- [x] Shutdown can be requested the same way

### FrameTimer: frame-rate limiting and delta time
Caps the loop at a target frame rate and reports elapsed time per frame,
so game logic moves at constant speed regardless of frame rate.
**Done when:**
- [x] Constructed with a target frames-per-second value
- [x] Sleeps only for the remaining frame time after each frame
- [x] Overrunning frames don't cause negative sleep
- [x] Returns delta time per frame in seconds
- [x] GameLoop uses FrameTimer to pace itself and pass delta time to states

---

## Definition of Done (Sprint)
- [x] Running the program starts the loop, renders the active state at a stable frame rate, switches states on request, and exits cleanly.