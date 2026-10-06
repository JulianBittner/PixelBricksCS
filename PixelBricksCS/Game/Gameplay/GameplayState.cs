using PixelBricksCS.Engine.Audio;
using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Engine.StateMachine;
using PixelBricksCS.Game.Assets.Sounds;
using PixelBricksCS.Game.Assets.Sprites;
using PixelBricksCS.Game.Gameplay.Bricks;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Gameplay
{
  internal class GameplayState : IEngineState<GameStateID>
  {
    private FrameBuffer _frameBuffer = new();
    private Renderer _renderer;

    private IContextHandle<GameStateID> _contextHandle = null!;
    private IAudioHandle _audioHandle = null!;

    private GameBoard _board = new();
    private Brick _currentBrick = new(BrickID.I);

    public GameplayState() {
      _renderer = new(_frameBuffer);
    }

    GameStateID IEngineState<GameStateID>.StateID => GameStateID.Gameplay;

    FrameBuffer IEngineState<GameStateID>.TargetBuffer => _frameBuffer;

    public void Init() {
      int screenMid = (EngineConfig.GameConsoleSize.Width / 2) - (_board.Width);
      int belowTitle = 7;
      GridPosition boardPosition = new(belowTitle, screenMid);

      TileMapComposer<BrickID> tileMapComposer = new(_board, new BrickTileSet());
      _renderer.AddDynamicComposer(tileMapComposer, boardPosition);

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
      _board.Reset();
    }

    void IEngineState<GameStateID>.Render() {
      _renderer.RenderDynamicContent();
    }

    void IEngineState<GameStateID>.Update(double deltaTime, ConsoleKey UserInputKey) {
      ValueTracer.TraceValue("Delta Time: ", deltaTime.ToString());
    }
  }
}
