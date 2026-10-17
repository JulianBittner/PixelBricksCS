# Sprint 8 – Brick controls

**Goal:** Complete the brick controls with rotation, collision, wall kicks and hard drop.

---

## Tasks

### Rotation
The player can rotate the brick.
**Done when:**
- [x] The brick rotates clockwise
- [x] (Optional) The brick rotates counterclockwise

### Collision
The brick respects the boundaries of the board.
**Done when:**
- [x] The brick cannot move through the board walls

### Wall kicks
Rotating near walls or blocks shifts the brick if possible.
**Done when:**
- [x] A rotation near a wall or block shifts the brick so the rotation fits, if possible

### Impact and blast
Terms and rules: see `docs/RULES.md`.

**Done when:**
- [x] The launch action fires the brick straight up; it impacts instantly and locks
- [x] A blast is triggered when the brick has at least three contact points
- [x] A blast removes all ceiling pixels within its blast radius
- [x] A blast removing six or more pixels at radius 1 becomes a big blast (radius 2)
- [x] A blast removing eight or more pixels at radius 1 becomes a mega blast (radius 3)
- [x] If no blast is triggered, the brick remains at its impact position

---

## Definition of Done (Sprint)
- [x] The brick can be rotated, collides with walls and ceiling pixels, is kicked away from walls when rotating, and can be hard dropped.