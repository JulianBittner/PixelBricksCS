# Gameplay Rules

## Glossary

| Term | Meaning |
|---|---|
| **Board** | The playing field, a grid of 14 × 24 cells. |
| **Board top** | The upper border of the board. New rows of pixels appear here. |
| **Pixel** | A single occupied square – either part of a brick (brick pixel) or of the ceiling (ceiling pixel). |
| **Ceiling** | The mass of pixels hanging from the board top and growing downwards. |
| **Ceiling edge** | The lower boundary of the ceiling – where launched bricks hit. |
| **Brick** | The player's piece, one of seven shapes (I, O, T, L, J, S, Z). |
| **Ghost** | A preview of the brick at the position where it would hit the ceiling. |
| **Wall kick** | Shifting a rotated brick sideways to a nearby free position when the rotation would collide. If no nearby position fits, the rotation is rejected. |
| **Launch** | Firing the brick straight up towards the ceiling. |
| **Impact** | The moment the launched brick hits the ceiling edge. |
| **Contact** | An edge where a brick pixel touches a ceiling pixel. Corner contacts don't count. |
| **Blast** | Removing ceiling pixels after an impact. |
| **Blast radius** | How far a blast reaches, counted in pixel steps from the brick. Radius 1 removes only the ceiling pixels in contact with the brick. Each additional radius also removes the ceiling pixels sharing an edge with those removed in the previous step. |
| **Big blast** | A blast with a blast radius of 2, triggered by six or more contacts. |
| **Mega blast** | A blast with a blast radius of 3, triggered by eight or more contacts. Its points are doubled. |
| **Descent** | A new row spawning at the board top, pushing the ceiling one row down. |
| **Merge** | When no blast is triggered, the brick merges into the ceiling: its pixels become ceiling pixels. |
| **Level** | The current stage of the game. Higher levels shorten the descent interval. |
| **Game over** | The end of the game, reached when a descent pushes the ceiling into the brick or a ceiling pixel reaches the bottom row of the board. |

## Rules

### Brick controls
- The brick is fixed vertically at the bottom of the board and can only move left and right.
- The brick can be rotated. If a rotation collides, the brick is shifted to nearby positions (wall kick); if none of them fits, the rotation is rejected.
- The brick cannot move through the board walls or ceiling pixels.
- The ghost always shows where the brick would hit the ceiling.

### Launch and impact
- The launch action fires the brick straight up. It impacts instantly and locks.

### Blast
- A blast is triggered when the brick has at least three contacts. It has a blast radius of 1.
- With six or more contacts, it becomes a **big blast** with a blast radius of 2.
- With eight or more contacts, it becomes a **mega blast** with a blast radius of 3.
- If no blast is triggered, the brick merges into the ceiling.

### Ceiling
- At a regular interval, a descent happens: a new row spawns at the board top and pushes the ceiling one row down.
- The descent interval depends on the current level and gets shorter as the game progresses.

### Score
- Every blasted pixel scores one point.
- A mega blast doubles its points.

### Game over
- If a descent pushes the ceiling into the brick, the game is over.
- If a ceiling pixel reaches the bottom row of the board, the game is over.

## Open questions
- How does the level increase – by score, by blasted pixels, or by time?