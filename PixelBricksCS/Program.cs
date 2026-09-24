using PixelBricksCS.Engine.Audio;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Engine.StateMachine;
using PixelBricksCS.Game;
using PixelBricksCS.Game.SplashScreen;
using PixelBricksCS.Sandbox;

class Program
{
  static void Main()
  {
    GameLoop<DemoStateID> pixelBricks = new(initialState: DemoStateID.SplashScreen);

    SplashScreen splashScreen = new(GameMetadata.GameTitle, GameMetadata.GameTitleColors);
    pixelBricks.RegisterEngineState(splashScreen);

    RenderingDemo renderingDemoState = new();
    renderingDemoState.Init();
    pixelBricks.RegisterEngineState(renderingDemoState);

    pixelBricks.Run();
  }
}