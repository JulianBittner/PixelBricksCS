using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Engine.StateMachine;
using PixelBricksCS.Sandbox;

class Program
{
  static void Main()
  {
    GameConsole.InitConsole();

    GameLoop<DemoStateID> pixelBricks = new(initialState: DemoStateID.Demo);

    RenderingDemo renderingDemoState = new();
    renderingDemoState.Init();
    pixelBricks.RegisterEngineState(renderingDemoState);

    pixelBricks.Run();
  }
}