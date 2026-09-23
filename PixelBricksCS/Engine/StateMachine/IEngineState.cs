using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.StateMachine
{
  internal interface IEngineState<T> where T : Enum
  {
    public T StateID { get; }
    public FrameBuffer TargetBuffer { get; }
    public void Enter(IContextHandle<T> contextHandle);
    public void Update(double deltaTime);
    public void Render();
    public void Exit();
  }
}
