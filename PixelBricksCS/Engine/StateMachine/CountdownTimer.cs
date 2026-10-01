using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PixelBricksCS.Engine.StateMachine
{
  internal class CountdownTimer
  {
    private double _durationInSeconds = 0.0;
    private double _elapsedSeconds = 0.0;

    public CountdownTimer(double Seconds) { 
      _durationInSeconds = Seconds;
    }
    
    public double ElapsedSeconds => _elapsedSeconds;
    public double DurationInSeconds => _durationInSeconds;

    public bool TimeUp(double deltaTimeInSeconds) {
      _elapsedSeconds += deltaTimeInSeconds;
      return _elapsedSeconds >= _durationInSeconds;
    }

    public void SetDurationSeconds(double durationSeconds) {
      _durationInSeconds = durationSeconds;
    }

    public void Reset() {
      _elapsedSeconds = 0.0;
    }
  }
}
