using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Composing
{
  internal class CharSprite
  {
    private readonly string[] _sprite;
    private readonly int _height;
    private readonly int _width;

    public CharSprite(string[] sprite) {
      for (int i = 1; i < sprite.Length; i++) {
        if (sprite[0].Length != sprite[i].Length)
          throw new ArgumentException("Sprites must use a uniform block size. All lines must have the same length.");
      }
      _height = sprite.Length;
      _width  = sprite[0].Length;
      _sprite = sprite;
    }

    public int Height => _height;
    public int Width => _width;
    // Get the sprite by line
    public string this[int y] => _sprite[y];
  }
}
