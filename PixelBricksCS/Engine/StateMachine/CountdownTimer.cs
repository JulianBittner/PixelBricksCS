using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.StateMachine
{
  internal class CountdownTimer
  {
    private double _duration = 0.0;
    private double _elapsed = 0.0;

    public CountdownTimer(double seconds) { 
      _duration = seconds;
    }

    public bool TimeUp(double deltaTime) {
      _elapsed += deltaTime;
      return _elapsed >= _duration;
    }

    public void Reset() {
      _elapsed = 0.0;
    }
  }
}
