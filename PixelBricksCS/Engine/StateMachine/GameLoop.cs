using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Diagnostics;
using PixelBricksCS.Engine.Rendering;
using PixelBricksCS.Sandbox;
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
    private bool _exitGameLoop = false;
    private FrameTimer _frameTimer = new(EngineConfig.FramesPerSecond);
    private double _deltaTime = 0;

    public GameLoop(T initialState) {
      _nextStateID = initialState;
    }

    public void Run() {
      if (!_states.ContainsKey(_nextStateID)) {
        throw new InvalidOperationException(
          $"Cannot start the game loop: state '{_nextStateID}' is not registered. " +
          $"Register it via RegisterEngineState() before calling Run().");
      }

      _currentState = _states[_nextStateID];
      _frameTimer.Start();

      while (!_exitGameLoop) {
        _currentState.Update(_deltaTime);
        _currentState.Render();
        GameConsole.Present(_currentState.TargetBuffer);

        if (EngineConfig.DiagnosticsOverlayEnabled) 
          DiagnosticsScreen.PresentOverlay();
        
        // Process state-requests
        if (!_currentState.StateID.Equals(_nextStateID)) {
          _currentState.Exit();
          _currentState = _states[_nextStateID];
          _currentState.Enter(contextHandle: this);
        }

        _deltaTime = _frameTimer.WaitForNextFrame();
      }
      GameConsole.ResetCursorPosition();
    }

    // API
    public void RegisterEngineState(IEngineState<T> engineState) {
      _states.Add(engineState.StateID, engineState);
    }

    // Interface
    void IContextHandle<T>.RequestStateChange(T requestedStateID) {
      _nextStateID = requestedStateID;
    }

    void IContextHandle<T>.RequestShutdown() {
      _exitGameLoop = true;
    }
  }
}
