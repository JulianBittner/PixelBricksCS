using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Sandbox
{
  internal class DemoBoard : ITileMap<MinoID>
  {
    private MinoID[,] matrix;
    public int Height { get => matrix.GetLength(0); }
    public int Width { get => matrix.GetLength(1); }
    public MinoID this[int y, int x] => matrix[y,x];

    public DemoBoard() {

      const MinoID _ = MinoID.None;
      const MinoID I = MinoID.I;
      const MinoID O = MinoID.O;
      const MinoID T = MinoID.T;
      const MinoID L = MinoID.L;
      const MinoID J = MinoID.J;
      const MinoID S = MinoID.S;
      const MinoID Z = MinoID.Z;
      matrix = new MinoID[,] {
        { _,_,_,_,_,_,_,_,_,_, },
        { _,_,_,_,_,_,_,_,_,_, },
        { _,_,_,_,_,_,_,_,_,_, },
        { _,_,_,_,_,_,_,_,_,_, },
        { _,_,Z,Z,_,_,_,S,S,_, },
        { _,_,_,Z,Z,_,S,S,_,_, },
        { I,_,_,_,_,_,_,_,_,_, },
        { I,_,_,_,_,_,J,_,_,L, },
        { I,O,O,_,T,_,J,_,_,L, },
        { I,O,O,T,T,T,J,J,L,L, },
      };
    }
  }
}
