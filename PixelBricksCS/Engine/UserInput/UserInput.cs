using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEngineCS
{
  public static class UserInput
  {
    public static ConsoleKey Poll() {
      ConsoleKey key = ConsoleKey.None;
      while (Console.KeyAvailable) {
        key = Console.ReadKey(intercept: true).Key;
      }
      return key;
    }
  }
}