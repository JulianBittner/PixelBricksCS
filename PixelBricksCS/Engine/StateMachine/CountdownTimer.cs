using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.StateMachine
{
  internal class CountdownTimer
  {
    private double _durationInSeconds = 0.0;
    private double _elapsedSeconds = 0.0;

    public CountdownTimer(double milliseconds) { 
      _durationInSeconds = milliseconds/1000;
    }

    public bool TimeUp(double deltaTimeInSeconds) {
      _elapsedSeconds += deltaTimeInSeconds;
      return _elapsedSeconds >= _durationInSeconds;
    }

    public void Reset() {
      _elapsedSeconds = 0.0;
    }
  }
}
