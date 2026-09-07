using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Sandbox
{
  internal class DemoBoard : ITileMap<MinoID>
  {
    private MinoID[,] _matrix;
    private int _animate = 0;
    public int Height { get => _matrix.GetLength(0); }
    public int Width { get => _matrix.GetLength(1); }
    public MinoID this[int y, int x] => _matrix[y,x];

    public DemoBoard() {
      _matrix = matrixes[0];
    }
    public void Animate() {
      _matrix = matrixes[_animate = ++_animate %2];
    }
    private const MinoID _ = MinoID.None;
    private const MinoID I = MinoID.I;
    private const MinoID O = MinoID.O;
    private const MinoID T = MinoID.T;
    private const MinoID L = MinoID.L;
    private const MinoID J = MinoID.J;
    private const MinoID S = MinoID.S;
    private const MinoID Z = MinoID.Z;

    private static readonly MinoID[][,] matrixes = {
      new MinoID[,] {
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
      },
      new MinoID[,] {
        { _,_,_,_,_,_,_,_,_,_, },
        { _,_,_,_,_,_,_,_,_,_, },
        { _,_,_,_,_,_,_,_,_,_, },
        { _,_,_,_,_,_,_,_,_,_, },
        { _,_,_,Z,_,_,_,_,S,_, },
        { _,_,Z,Z,_,_,_,S,S,_, },
        { I,_,Z,_,_,_,_,S,_,_, },
        { I,_,_,_,_,_,J,_,_,L, },
        { I,O,O,_,T,_,J,_,_,L, },
        { I,O,O,T,T,T,J,J,L,L, },
      },
    };
  }
}
