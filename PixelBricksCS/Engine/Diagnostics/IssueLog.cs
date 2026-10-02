using PixelBricksCS.Engine.StateMachine;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Diagnostics
{
  internal class IssueLog
  {
    private static StringBuilder _logMessages = new();

    public static string LogMessages { get => _logMessages.ToString(); }

    public static bool IsEmpty() {
      if (_logMessages.Length == 0) return true;
      else                          return false;
    }
    public static void AddIssueMessage(string msg) {
      _logMessages.AppendLine("  " + msg);
    }
  }
}
