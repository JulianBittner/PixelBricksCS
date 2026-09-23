using PixelBricksCS.Engine.Core;
using PixelBricksCS.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Diagnostics
{
  internal class DiagnosticsScreen
  {
    static public void PresentOverlay() {
      Console.SetCursorPosition(0, EngineConfig.DebugOverlayRaw);
      Console.WriteLine(AssambleOverlay());
    }

    private static string AssambleOverlay() {
      StringBuilder overlay = new StringBuilder();

      if (!SpeedProbe.LogIsEmpty()) {
        overlay.AppendLine("SpeedProbe Results:" + AnsiColorCode.Yellow);
        overlay.Append(SpeedProbe.LogMessages);
        overlay.Append(AnsiColorCode.Reset);
      }

      if (!ValueTracer.HasValue()) {
        overlay.AppendLine("Traced Values:" + AnsiColorCode.Yellow);
        overlay.AppendLine(ValueTracer.GetTraceTable());
        overlay.Append(AnsiColorCode.Reset);
      }

      if (!IssueLog.IsEmpty()) {
        overlay.AppendLine("Issues accurt:" + AnsiColorCode.Yellow);
        overlay.AppendLine(IssueLog.LogMessages);
      }

      overlay.Append(AnsiColorCode.Reset);
      return overlay.ToString();
    }
  }
}
