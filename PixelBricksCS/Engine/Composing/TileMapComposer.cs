using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Sandbox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PixelBricksCS.Engine.Composing
{
  /// <summary>
  /// Composes a <see cref="Region"/> from an <see cref="ITileMap{T}"/> by looking up
  /// each tile in the corresponding <see cref="ITileSet{T}"/>. The enum <typeparamref name="T"/>
  /// defines the shared set of valid tile IDs and binds a specific map to a specific set —
  /// both must be implemented against the same <typeparamref name="T"/> for a given
  /// TileMapComposer instance to make sense. Each tile occupies two horizontally
  /// adjacent cells in the region, so the region must be at least twice as wide as the map.
  /// </summary>
  /// <typeparam name="T">
  /// An enum defining the set of valid tile IDs shared between the TileMap and the TileSet.
  /// </typeparam>
  internal class TileMapComposer<T> : IComposer where T : Enum
  {
    private ITileMap<T> _map;
    private ITileSet<T> _set;
    
    public TileMapComposer(ITileMap<T> map, ITileSet<T> set) {
      _map = map;
      _set = set;
    }
    void IComposer.Compose(FrameBuffer frameBuffer, GridPosition position) {
      for (int y = 0; y < _map.Height; y++) {
        for (int x = 0; x < _map.Width; x++) {
          T tileID = _map[y, x];
          frameBuffer[y + position.Y, ((x + position.X)*2)    ] = 
            new(_set[tileID].Symbol0, 
                _set[tileID].Color);
          frameBuffer[y + position.Y, ((x + position.X)*2) + 1] = 
            new(_set[tileID].Symbol1, 
                _set[tileID].Color);
        }
      }
    }
  }
}
