using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Composing
{
  /// <summary>
  /// A lookup table mapping tile IDs to their <see cref="Tile"/> representation.
  /// The enum <typeparamref name="T"/> defines the set of valid tile IDs and must
  /// match the <see cref="ITileMap{T}"/> used alongside this set.
  /// </summary>
  /// <typeparam name="T">An enum defining the set of valid tile IDs.</typeparam>
  internal interface ITileSet<T> where T : Enum
  {
    public int TileCount { get; }
    public Tile this[T tileID] { get; }
  }
}
