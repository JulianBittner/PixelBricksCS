using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PixelBricksCS.Engine.Diagnostics
{
  internal class ValueTracer
  {

    private static Dictionary<string, string> _tracedValues = new();

    public static bool HasValue() {
      if (_tracedValues.Count == 0) return true;
      else                          return false;
    }

    public static string GetTraceTable() {
      StringBuilder traceTable = new StringBuilder();
      foreach (var key in _tracedValues.Keys) {
        traceTable.AppendLine("  " + key + ": " + _tracedValues[key]);
      }
      return traceTable.ToString();
    }

    public static void TraceValue(string key, string value) {
      _tracedValues[key] = value;
    }
  }
}
