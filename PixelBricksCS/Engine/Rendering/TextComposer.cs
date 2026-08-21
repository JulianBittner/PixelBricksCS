using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Rendering
{
  internal static class TextComposer
  {
    public static Region ComposeStringArr(string[] text, CellColor color = CellColor.Default) {
      Region textRegion = new(text.Length, GetLenOfLongestString(text));
      for (int y = 0; y < text.Length; y++) {
        for (int x = 0; x < text[y].Length; x++) {
          textRegion[y,x] = new(text[y][x], color);
        }
      }
      return textRegion;
    }

    private static int GetLenOfLongestString(string[] text) {
      int len = 0;
      foreach(string s in text) {
        if (len < s.Length) {
          len = s.Length;
        }
      }
      return len;
    }
  }
}
