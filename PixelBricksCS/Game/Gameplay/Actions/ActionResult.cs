using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay.Actions
{
  internal enum ActionResult
  {
    None = 0,
    Moved,
    Rotated,
    Blocked,
    Launched,
    Merged,
    Blasted
  }
}
