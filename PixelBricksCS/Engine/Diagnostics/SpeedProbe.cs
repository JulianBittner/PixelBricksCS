using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text;

namespace PixelBricksCS.Engine.Diagnostics
{
  internal class SpeedProbe
  {
    private static StringBuilder _speedProbeLogs = new();

    private Stopwatch _sw = new Stopwatch();
    private int _counter = 0;
    private string _valueName;

    public static string LogMessages { get => _speedProbeLogs.ToString(); }

    public static bool LogIsEmpty() {
      if (_speedProbeLogs.Length == 0) return true;
      else                             return false;
    }

    private static void LogSpeedProbe(string key, string value) {
      _speedProbeLogs.AppendLine("  " + key + ": " + value);
    }

    public SpeedProbe(string valueName) {
      _valueName = valueName;
      _sw.Start();
    }
    
    public void Start() {
      _sw.Start();
    }

    public void Continue() {
      _counter++;
    }

    public bool RepeatLoop(int cycles = 1000) {
      if (_counter >= cycles) {
        _sw.Stop();
        float averageTime = (float)_sw.Elapsed.TotalMicroseconds / (float)cycles;
        LogSpeedProbe(
          _valueName,
          cycles + " " + "cycles, average time " + averageTime.ToString() + " µs");
        return false;
      }
      return true;
    }
  }
}
