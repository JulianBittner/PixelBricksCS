using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.StateMachine
{
  internal interface IContextHandle<T> where T : Enum
  {
    public void RequestStateChange(T engineState);
    public void RequestShutdown();
  }
}
