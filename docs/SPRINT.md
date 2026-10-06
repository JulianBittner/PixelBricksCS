# Sprint 7 – Board and first brick

**Goal:** Show the game board with a single brick that the player can move left and right.

---

## Tasks

### GameBoard: grid of cells
Holds the playing field and knows which cells are occupied.
**Done when:**
- [x] Holds a 14×20 grid of BrickIDs, indexed [y, x]
- [x] Empty cells are BrickID.None, occupied cells hold the ID of the brick that locked there

### Brick: data model of the active brick
Represents the falling brick as data, separate from how it is drawn.
**Done when:**
- [x] Holds its BrickID, rotation and position on the board
- [x] Provides its current body from BrickBodies based on ID and rotation
- [x] Its color is derived from the BrickID via the tile set, not stored in the brick

### BrickBodies: shape definitions
Defines the occupied cells of every brick in every rotation.
**Done when:**
- [x] Contains all seven bricks (I, O, T, S, Z, J, L)
- [x] Each brick has four rotation states following the Rotation enum

### Brick composing: drawing the active brick
Draws the current brick on top of the board.
**Done when:**
- [x] The board is drawn through BrickTileSet
- [x] The active brick is drawn at its position on the board, in its own color
- [x] Empty cells of the brick body don't overwrite the board underneath

### Horizontal movement
The player can move the active brick sideways.
**Done when:**
- [x] A gameplay input mapper translates keys into gameplay actions
- [x] Left and right move the brick by one column

---

## Definition of Done (Sprint)
- [x] Choosing Play in the menu shows the board with a brick that can be moved left and right.