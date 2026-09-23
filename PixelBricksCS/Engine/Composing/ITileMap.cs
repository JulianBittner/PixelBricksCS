using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Composing
{
  /// <summary>
  /// A 2D grid of tile IDs describing the layout of a game board. The enum
  /// <typeparamref name="T"/> defines the set of valid tile IDs and must match
  /// the <see cref="ITileSet{T}"/> used alongside this map.
  /// </summary>
  /// <typeparam name="T">An enum defining the set of valid tile IDs.</typeparam>
  internal interface ITileMap<T> where T  : Enum
  {
    public int Height { get; }
    public int Width { get; }
    public T this[int y, int x] { get; }
  }
}