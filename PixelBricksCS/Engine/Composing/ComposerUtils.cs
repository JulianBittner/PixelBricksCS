using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Composing
{
  internal static class ComposerUtils
  {
    // Writes a CharSprite onto a FrameBuffer at the given grid position
    // and in a given color.
    public static void WriteSprite(
      FrameBuffer frameBuffer,
      GridPosition position,
      CharSprite sprite,
      CellColor color = CellColor.Default) {
      for (int y = 0; y < sprite.Height; y++) {
        for (int x = 0; x < sprite[y].Length; x++) {
          frameBuffer[y + position.Y, x + position.X] = new(sprite[y][x], color);
        }
      }
    }
    public static void ClearArea(
      FrameBuffer frameBuffer,
      GridPosition position,
      GridSize areaSize) {
      for (int y = 0; y < areaSize.Height; y++) {
        for (int x = 0; x < areaSize.Width; x++) {
          frameBuffer[y + position.Y, x + position.X] = Cell.Blank;
        }
      }
    }
  }
}
