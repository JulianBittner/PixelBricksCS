using NAudio.Wave;
using PixelBricksCS.Engine.Assets.Sounds;
using PixelBricksCS.Engine.Audio;
using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Engine.StateMachine;
using PixelBricksCS.Game.Assets.Sounds;
using PixelBricksCS.Game.Assets.Sprites;
using PixelBricksCS.Game.Gameplay.Actions;
using PixelBricksCS.Game.Gameplay.Bricks;
using PixelBricksCS.Game.Gameplay.Composers;
using PixelBricksCS.Game.Gameplay.GameMechanics;
using PixelBricksCS.Game.Gameplay.Scores;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay
{
  internal class GameplayState : IEngineState<GameStateID>
  {
    private delegate GamePhase GamePhase(double deltaTime, ConsoleKey playerInputKey);
    private GamePhase _currentPhase = null!;

    private IContextHandle<GameStateID> _contextHandle = null!;
    private IAudioHandle _audioHandle = null!;

    private FrameBuffer _frameBuffer = new();
    private Renderer _renderer = null!;
    private BrickComposer _brickComposer = null!;
    private BlockTextComposer _gameOverComposer;
    private BlockComposer _promptComposer;

    private ActionController _actionController;
    private WorldController _worldController;
    
    private GameBoard _gameBoard = new();
    private ScoreBoard _scoreBoard = new();
    
    private Brick _currentBrick;
    private GhostBrick _ghostBrick;


    public GameplayState() {
      _gameOverComposer = new("GAME OVER", CellColor.Red);
      _promptComposer = new(new CharSprite(["[Press enter to leave]"]), CellColor.Red);

      _currentBrick = Brick.GetRandomBrick();
      _ghostBrick = new(_gameBoard, Brick.GetRandomBrick());
      _actionController = new ActionController(_gameBoard, _ghostBrick);
      _worldController = new WorldController(_gameBoard, _ghostBrick);
    }

    GameStateID IEngineState<GameStateID>.StateID => GameStateID.Gameplay;
    FrameBuffer IEngineState<GameStateID>.TargetBuffer => _frameBuffer;

    public void Init() {
      ResetRenderer();
    }

    private void ResetRenderer() {
      int screenMid = (EngineConfig.GameConsoleSize.Width / 2) - (_gameBoard.Width);
      int belowTitle = 7;
      GridPosition boardPosition = new(belowTitle, screenMid);

      _frameBuffer.Clear();
      _renderer = new(_frameBuffer);

      TileMapComposer<BrickID> tileMapComposer = new(_gameBoard, new BrickTileSet());
      _renderer.AddDynamicComposer(tileMapComposer, boardPosition);
      
      _renderer.AddDynamicComposer(
        new GhostComposer(_ghostBrick),
        boardPosition);

      _brickComposer = new(_currentBrick, new BrickTileSet());
      _renderer.AddDynamicComposer(
        _brickComposer, 
        boardPosition);

      _renderer.AddStaticComposer(
        new BlockComposer(GameBoardFrame.Sprite, CellColor.Default), 
        boardPosition.WithOffset(-1,-1));

      _renderer.AddStaticComposer(
        new BlockTextComposer("PIXELBRICKS", CellColor.Cyan), 
        GridPosition.Zero);
      _renderer.RenderStaticContent();
    }

    void IEngineState<GameStateID>.Enter(IContextHandle<GameStateID> contextHandle, IAudioHandle audioHandle) {
      _contextHandle = contextHandle;
      _audioHandle = audioHandle;

      ResetRenderer();
      _gameBoard.Reset();
      _currentBrick = Brick.GetRandomBrick();
      _brickComposer.ReplaceBrick(_currentBrick);
      _ghostBrick.UpdateGhostBrick(_currentBrick);
      _currentPhase = Aim;

      _audioHandle.PlayMusicLoop(new GameMusicTrack1());
    }

    void IEngineState<GameStateID>.Exit() {
      _audioHandle.StopMusicLoop();
      _gameBoard.Reset();
    }

    void IEngineState<GameStateID>.Render() {
      _renderer.RenderDynamicContent();
    }

    void IEngineState<GameStateID>.Update(double deltaTime, ConsoleKey playerInputKey) {
      _currentPhase = _currentPhase(deltaTime, playerInputKey);
    }

    private GamePhase Aim(double deltaTime, ConsoleKey playerInputKey) {
      bool isGameOver = _worldController.DescentCeiling(deltaTime, _currentBrick);
      if (isGameOver) {
        _audioHandle.StopMusicLoop();
        _audioHandle.PlaySound(GameOverSound.Create());

        GridPosition gameOverPosition = new(32, 5);
        _renderer.AddDynamicComposer(_gameOverComposer, gameOverPosition);
        _renderer.AddDynamicComposer(_promptComposer,   gameOverPosition.WithOffset(7,26));

        return GameOver;
      }

      GameAction action = GameInputMapper.ToAction(playerInputKey);
      if (action == GameAction.None) 
        return Aim;

      ActionResult actionResult = _actionController.Apply(_currentBrick, action);
      if (actionResult != ActionResult.Launched) {
        _audioHandle.PlaySound(GetActionSound(actionResult));
        return Aim;
      }

      ImpactResult impactResult = GameMechanicUtils.ImpactAnalysis(_gameBoard, _currentBrick);
      _audioHandle.PlaySound(GetImpactSound(impactResult));
      _audioHandle.PlaySound(GameSounds.CreateLaunch());

      if (impactResult.Contacts < 3) {
        _gameBoard.MergeBrick(_currentBrick);
      } else {
        impactResult = GameMechanicUtils.DeterminBlastArea(_gameBoard, impactResult);
        _gameBoard.ApplyBlast(impactResult);
      }
      // TODO: Not Implemented yet
      //_scoreBoard.Record(impactResult);

      return Animate(deltaTime, playerInputKey);
    }

    private GamePhase Animate(double deltaTime, ConsoleKey playerInputKey) {
      if (false) {
        // TODO
        return Animate;
      }
      // Change to next State; Execute already this frame
      return SpawnBrick(deltaTime, playerInputKey);
    }

    private GamePhase SpawnBrick(double deltaTime, ConsoleKey playerInputKey) {
      _currentBrick = Brick.GetRandomBrick();
      _brickComposer.ReplaceBrick(_currentBrick);
      _ghostBrick.UpdateGhostBrick(_currentBrick);
      return Aim;
    }

    private GamePhase GameOver(double deltaTime, ConsoleKey playerInputKey) {
      if (playerInputKey == ConsoleKey.Enter) {
        _audioHandle.PlaySound(StockMenuSounds.CreateConfirmationBlip());
        _contextHandle.RequestStateChange(GameStateID.Menu);
      }
      return GameOver;
    }

    private ISampleProvider GetImpactSound(ImpactResult impactResult) 
      => impactResult.Range switch {
      3 => RumbleSound.CreateRumble2Seconds(),
      2 => RumbleSound.CreateRumble1Seconds(),
      1 => RumbleSound.CreateRumble05Seconds(),
      0 => GameSounds.CreateLand(),
      _ => NullSampleProvider.Instance
    };

    private ISampleProvider GetActionSound(ActionResult actionResult) 
      => actionResult switch {
      ActionResult.Moved => GameSounds.CreateMove(),
      ActionResult.Rotated => GameSounds.CreateRotate(),
      ActionResult.Blocked => StockMenuSounds.CreateDenialBlip(),
      _ => NullSampleProvider.Instance
    };
  }
}
