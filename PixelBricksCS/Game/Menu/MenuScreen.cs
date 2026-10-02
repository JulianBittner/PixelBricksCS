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
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Game.Menu
{
  internal class MenuScreen : IEngineState<GameStateID>
  {
    private enum MenuItem { Play = 0, Credits = 1, Exit = 2 }

    private readonly CharSprite[] _arrows = [
      MenuSprites.PlayArrow,
      MenuSprites.CreditsArrow,
      MenuSprites.ExitArrow];

    private FrameBuffer _frameBuffer = new();
    private Renderer _renderer;

    private IContextHandle<GameStateID> _contextHandle = null!;
    private IAudioHandle _audioHandle = null!;

    private BlockComposer _arrowComposer = null!;
    private int _selectedIndex = 0;

    public MenuScreen() {
      _renderer = new(_frameBuffer);
    }

    GameStateID IEngineState<GameStateID>.StateID => GameStateID.Menu;
    FrameBuffer IEngineState<GameStateID>.TargetBuffer => _frameBuffer;

    public void Init() {
      int itemBoxPositionY = 10;
      int itemBoxPositionX = (EngineConfig.GameConsoleSize.Width / 2) - (MenuSprites.ItemBox.Width / 2);

      _renderer.AddStaticComposer(
        new BlockTextComposer("START MENU", GameMetadata.TitleColor),
        GridPosition.Zero);
      
      GridPosition itemBoxPosition = new(itemBoxPositionY, itemBoxPositionX);
      _renderer.AddStaticComposer(
        new BlockComposer(MenuSprites.ItemBox, CellColor.Default), itemBoxPosition);

      // Overlay, to gray out unavailable items
      GridPosition GrayedItemPosition = new(itemBoxPositionY+1, itemBoxPositionX+8);
      _renderer.AddStaticComposer(
        new BlockComposer(MenuSprites.GrayedItems, CellColor.Gray), GrayedItemPosition);
      
      GridPosition arrowPosition = new(itemBoxPositionY +1, itemBoxPositionX + 6);

      _arrowComposer = new BlockComposer(_arrows[_selectedIndex], CellColor.Default);
      _renderer.AddDynamicComposer(_arrowComposer, arrowPosition);

      _renderer.RenderStaticContent();
    }

    void IEngineState<GameStateID>.Enter(IContextHandle<GameStateID> contextHandle, IAudioHandle audioHandle) {
      _contextHandle = contextHandle;
      _audioHandle = audioHandle;
      _audioHandle.PlayMusicLoop(new GameMusicTrack1());
    }

    void IEngineState<GameStateID>.Exit() {
      _audioHandle.StopMusicLoop();
    }

    void IEngineState<GameStateID>.Render() {
      _renderer.RenderDynamicContent();
    }

    void IEngineState<GameStateID>.Update(double deltaTime, ConsoleKey userInputKey) {
      switch (MenuInputMapper.ToAction(userInputKey)) {
        case MenuAction.MoveUp:
          _audioHandle.PlaySound(StockMenuSounds.CreateCursorBlip());
          if (_selectedIndex == 0) return;
          _selectedIndex--;
          _arrowComposer.Sprite = _arrows[_selectedIndex];
          return;

        case MenuAction.MoveDown:
          _audioHandle.PlaySound(StockMenuSounds.CreateCursorBlip());
          if (_selectedIndex >= _arrows.Length -1) return;
          _selectedIndex ++;
          _arrowComposer.Sprite = _arrows[_selectedIndex];
          return;

        case MenuAction.Confirm:
          ActivateSelectedItem();
          return;

        default:
          return;
      }
    }
    private void ActivateSelectedItem() {
      switch ((MenuItem)_selectedIndex) {
        case MenuItem.Play:
          _audioHandle.PlaySound(StockMenuSounds.CreateDenialBlip());
          break;
        case MenuItem.Credits:
          _audioHandle.PlaySound(StockMenuSounds.CreateDenialBlip());
          break;
        case MenuItem.Exit:
          _audioHandle.PlaySound(StockMenuSounds.CreateConfirmationBlip());
          _contextHandle.RequestStateChange(GameStateID.ExitScreen);
          break;
        default:
          break;
      }
    }
  }
}
