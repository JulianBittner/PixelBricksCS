using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace PixelBricksCS.Engine.StateMachine
{
  internal class FrameTimer
  {
    private Stopwatch _timer = new();
    private readonly double _millisecondsPerFrame;

    public FrameTimer(int framesPerSecond) {
      _millisecondsPerFrame = 1000.0/framesPerSecond;
    }

    public void Start() {
      _timer.Start();
    }

    public double WaitForNextFrame() {
      double elapsedMilliseconds = _timer.Elapsed.TotalMilliseconds;
      int remainingFrameMilliseconds = (int)(_millisecondsPerFrame - elapsedMilliseconds);

      if (remainingFrameMilliseconds > 0)
        Thread.Sleep(remainingFrameMilliseconds);

      double deltaTimeSeconds = _timer.Elapsed.TotalSeconds;
      _timer.Restart();
      return deltaTimeSeconds;
    }
  }
}
