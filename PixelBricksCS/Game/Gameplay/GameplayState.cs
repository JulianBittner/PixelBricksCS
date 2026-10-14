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
    GamePhase _currentPhase;

    private IContextHandle<GameStateID> _contextHandle = null!;
    private IAudioHandle _audioHandle = null!;

    private FrameBuffer _frameBuffer = new();
    private Renderer _renderer;

    private ActionController _actionController;
    private WorldController _worldController;
    
    private GameBoard _gameBoard = new();
    private ScoreBoard _scoreBoard = new();
    
    private Brick _currentBrick;
    private GhostBrick _ghostBrick;


    public GameplayState() {
      _renderer = new(_frameBuffer);

      _currentBrick = new(BrickID.I);
      _ghostBrick = new(_gameBoard, _currentBrick);

      _actionController = new ActionController(_gameBoard, _ghostBrick);
      _worldController = new WorldController(_gameBoard);

      _currentPhase = Aim;
    }

    GameStateID IEngineState<GameStateID>.StateID => GameStateID.Gameplay;
    FrameBuffer IEngineState<GameStateID>.TargetBuffer => _frameBuffer;

    public void Init() {
      int screenMid = (EngineConfig.GameConsoleSize.Width / 2) - (_gameBoard.Width);
      int belowTitle = 7;
      GridPosition boardPosition = new(belowTitle, screenMid);

      TileMapComposer<BrickID> tileMapComposer = new(_gameBoard, new BrickTileSet());
      _renderer.AddDynamicComposer(tileMapComposer, boardPosition);
      
      _renderer.AddDynamicComposer(
        new GhostComposer(_ghostBrick),
        boardPosition);

      _renderer.AddDynamicComposer(
        new BrickComposer(_currentBrick, new BrickTileSet()), 
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
      // # Decent
      bool isGameOver = _worldController.DescentCeiling(deltaTime, _currentBrick);
      if (isGameOver) throw new NotImplementedException("GameOver Screen not yet implemented");

      // # Aim
      GameAction action = GameInputMapper.ToAction(playerInputKey);
      if (action == GameAction.None) 
        return Aim;

      ActionResult actionResult = _actionController.Apply(_currentBrick, action);

      if (actionResult != ActionResult.Locked) {
        PlayActionSound(actionResult);
        return Aim;
      }

      // # Launch
      ImpactResult impactResult;

      // Impact analysis
      HashSet<GridPosition> contactPixels 
        = GameMechanicUtils.FindContactPixels(_gameBoard, _currentBrick);

      if (contactPixels.Count < 3) {
        // Merge
        _gameBoard.MergeBrick(_currentBrick);
        impactResult = new(new List<GridPosition>(), contactPixels.Count, Range: 0);
      }
      else {
        // Blast
        impactResult = GameMechanicUtils.DeterminBlastArea(
          _gameBoard, 
          _currentBrick,
          contactPixels);

        _gameBoard.ApplyBlast(impactResult);
      }

      _scoreBoard.Record(impactResult);
      
      return Animate(deltaTime, playerInputKey);
    }

    private GamePhase Animate(double deltaTime, ConsoleKey playerInputKey) {
      if (false) {
        // TODO
        return Animate;
      }

      // Change to next State; Execute already this frame
      return BrickGeneration(deltaTime, playerInputKey);
    }

    private GamePhase BrickGeneration(double deltaTime, ConsoleKey playerInputKey) {
      Random random = new Random();
      _currentBrick = new((BrickID)random.Next(1, 7));
      return Aim;
    }

    private void PlayActionSound(ActionResult result) {
      switch (result) {
        case ActionResult.Moved:
          _audioHandle.PlaySound(GameSounds.CreateMove());
          break;
        case ActionResult.Rotated:
          _audioHandle.PlaySound(GameSounds.CreateRotate());
          break;
        case ActionResult.Blocked:
          _audioHandle.PlaySound(StockMenuSounds.CreateDenialBlip());
          break;
        case ActionResult.Locked:
          _audioHandle.PlaySound(StockMenuSounds.CreateDenialBlip());
          break;
        default:
          break;
      }
    }
  }
}
