using PixelBricksCS.Engine.Audio;
using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using SimpleEngineCS;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PixelBricksCS.Engine.StateMachine
{
  internal class GameLoop<T> : IContextHandle<T> where T : Enum
  {
    private readonly Dictionary<T, IEngineState<T>> _states = new();
    private IEngineState<T> _currentState = null!;
    private T _nextStateID;

    private FrameTimer _frameTimer = new(EngineConfig.FramesPerSecond);
    private double _deltaTime = 0;

    private AudioPlayer _audioPlayer = new();

    private bool _exitGameLoop = false;

    public GameLoop(T initialState) {
      _nextStateID = initialState;
    }

    public void Run() {
      if (!_states.ContainsKey(_nextStateID)) {
        throw new InvalidOperationException(
          $"Cannot start the game loop: state '{_nextStateID}' is not registered. " +
          $"Register it via RegisterEngineState() before calling Run().");
      }

      GameConsole.InitConsole();

      _audioPlayer.Init();
      _audioPlayer.Start();

      _currentState = _states[_nextStateID];
      _currentState.Enter(contextHandle: this, audioHandle: _audioPlayer);
      _frameTimer.Start();

      while (!_exitGameLoop) {
        _currentState.Update(_deltaTime, UserInput.Poll());
        _currentState.Render();
        GameConsole.Present(_currentState.TargetBuffer);

        if (EngineConfig.DiagnosticsOverlayEnabled) 
          DiagnosticsScreen.PresentOverlay();
        
        // Handle state change request
        if (!_currentState.StateID.Equals(_nextStateID)) {
          _currentState.Exit();
          _currentState = _states[_nextStateID];
          _currentState.Enter(contextHandle: this, _audioPlayer);
        }

        _deltaTime = _frameTimer.WaitForNextFrame();
      }

      _audioPlayer.Dispose();      
      GameConsole.ResetCursorPosition();
    }

    public void RegisterEngineState(IEngineState<T> engineState) {
      _states.Add(engineState.StateID, engineState);
    }

    void IContextHandle<T>.RequestStateChange(T requestedStateID) {
      _nextStateID = requestedStateID;
    }

    void IContextHandle<T>.RequestShutdown() {
      _exitGameLoop = true;
    }
  }
}
