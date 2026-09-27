using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Audio
{
  internal static class NoteDurations
  {
    public const int Q = 450;        // Viertel (quarter) – Grundeinheit
    public const int W = Q * 4;      // Ganze     (whole)
    public const int H = Q * 2;      // Halbe     (half)
    public const int E = Q / 2;      // Achtel    (eighth)
    public const int S = Q / 4;      // Sechzehntel (sixteenth)

    // Punktierte Noten: 1,5-fache Länge (Note + halbe Note dazu)
    public const int WD = Q * 6;      // punktierte Ganze
    public const int HD = Q * 3;      // punktierte Halbe
    public const int QD = Q * 3 / 2;  // punktierte Viertel
    public const int ED = Q * 3 / 4;  // punktiertes Achtel
  }
}
