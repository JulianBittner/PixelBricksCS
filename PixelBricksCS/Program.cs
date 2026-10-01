using PixelBricksCS.Engine.Audio;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Engine.StateMachine;
using PixelBricksCS.Game;
using PixelBricksCS.Game.Menu;
using PixelBricksCS.Game.SplashScreen;

class Program
{
  static void Main()
  {
    GameLoop<GameStateID> pixelBricks = new(initialState: GameStateID.SplashScreen);

    SplashScreen splashScreen = new(GameMetadata.GameTitle, GameMetadata.GameTitleColors);
    pixelBricks.RegisterEngineState(splashScreen);

    MenuScreen menuScreen = new();
    menuScreen.Init();
    pixelBricks.RegisterEngineState(menuScreen);

    ExitScreen exitScreen = new();
    exitScreen.Init();
    pixelBricks.RegisterEngineState(exitScreen);

    pixelBricks.Run();
  }
}