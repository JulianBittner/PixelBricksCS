using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Engine.StateMachine;
using PixelBricksCS.Game;
using PixelBricksCS.Game.SplashScreen;
using PixelBricksCS.Sandbox;

class Program
{
  static void Main()
  {
    GameConsole.InitConsole();

    GameLoop<DemoStateID> pixelBricks = new(initialState: DemoStateID.SplashScreen);

    RenderingDemo renderingDemoState = new();
    renderingDemoState.Init();
    pixelBricks.RegisterEngineState(renderingDemoState);

    SplashScreen splashScreen = new(GameMetadata.GameTitle, GameMetadata.GameTitleColors);
    pixelBricks.RegisterEngineState(splashScreen);

    pixelBricks.Run();
  }
}