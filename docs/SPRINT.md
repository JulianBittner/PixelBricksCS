# Sprint 3 – Block letter composing and animation

**Goal:** Compose arbitrary strings from a block-letter font and animate them over time.

---

## Tasks

### BlockLetterComposer: block-letter text to region
Composes a region from a plain string by looking up each character in a
block-letter font and placing the letters side by side.
**Done when:**
- [x] CharSprite validates that all lines have equal length and fails loudly otherwise
- [x] CharSprite Composers places a CharSprite into the FrameBuffer at a given position, translating characters into cells
- [x] Given a string, each character is looked up in a letter set (e.g. BlockLetters)
- [x] Letters are placed left-to-right into the region, advancing by each letter's width
- [x] Characters missing from the font fail loudly or fall back to a placeholder glyph
- [x] A demo composes a word (not just a single pre-baked title) and renders correctly

---

## Definition of Done (Sprint)
- [x] The demo renders an arbitrary word on screen, composed letter by letter from the block-letter font, correctly positioned and colored.