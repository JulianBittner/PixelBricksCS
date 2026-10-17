using PixelBricksCS.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay.GameMechanics
{
  internal readonly record struct ImpactResult(
    HashSet<GridPosition> AffectedPixels,
    int Contacts,
    int Range)
  { }
}