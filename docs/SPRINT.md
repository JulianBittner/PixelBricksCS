# Sprint 2 – Add Renderer, refactor composers

**Goal:** Composers write into a shared FrameBuffer at a given position, managed by the Renderer.

---

## Tasks

### Update rendering pipeline diagram
The existing diagram still shows the old flow (Region → Rendering → FrameBuffer). Update it to reflect the new structure where the Renderer owns the FrameBuffer and drives stateless composers with positions.
**Done when:**
- [x] Diagram in docs/diagrams reflects the new Renderer/composer flow
- [x] Exported PNG/SVG is regenerated and committed alongside the .drawio source

### Composers become stateless: receive target and position per call
Composers no longer hold their own target. Instead, Compose(FrameBuffer, GridPosition) receives both on every invocation, so the same composer instance can be used for any target at any position.
**Done when:**
- [x] IComposer.Compose signature takes FrameBuffer and GridPosition
- [x] TileMapComposer no longer holds a target in its state
- [x] Composers write each cell at (position.Y + y, position.X + x)

### Renderer owns the FrameBuffer and drives composers
The Renderer holds the target FrameBuffer and a list of composers with their positions. On each render, it invokes every composer against the shared buffer in order.
**Done when:**
- [x] Renderer owns the FrameBuffer instance
- [x] Renderer holds a list of (composer, position) entries
- [x] On render, each composer is invoked with the shared FrameBuffer and its position, in list order
- [x] Later entries can overwrite earlier ones (draw order = list order)

---

## Definition of Done (Sprint)
- [x] A demo places two independent composers (e.g. a small board and a title) at different positions in the same FrameBuffer via the Renderer, and both appear correctly.