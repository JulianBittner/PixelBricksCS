using System;
using System.Collections.Generic;
using System.Text;
using B = PixelBricksCS.Game.Gameplay.BrickID;

namespace PixelBricksCS.Game.Gameplay
{
  // Bodies are indexed [y, x]. Each occupied cell holds the brick's ID, empty cells are None.
  internal static class BrickBodies
  {
    private const B _ = B.None;

    public static readonly B[][,] I = [
      /// <see cref="Rotation.Spawn"/>
      new B[,] {
        { _,   _,   _,   _   },
        { B.I, B.I, B.I, B.I },
        { _,   _,   _,   _   },
        { _,   _,   _,   _   },
      },
      /// <see cref="Rotation.Right"/>
      new B[,] {
        { _,   _,   B.I, _ },
        { _,   _,   B.I, _ },
        { _,   _,   B.I, _ },
        { _,   _,   B.I, _ },
      },
      /// <see cref="Rotation.Flip"/>
      new B[,] {
        { _,   _,   _,   _   },
        { _,   _,   _,   _   },
        { B.I, B.I, B.I, B.I },
        { _,   _,   _,   _   },
      },
      /// <see cref="Rotation.Left"/>
      new B[,] {
        { _,   B.I, _,   _ },
        { _,   B.I, _,   _ },
        { _,   B.I, _,   _ },
        { _,   B.I, _,   _ },
      },
    ];

    public static readonly B[][,] O = [
      /// <see cref="Rotation.Spawn"/>
      new B[,] {
        { B.O, B.O },
        { B.O, B.O },
      },
      /// <see cref="Rotation.Right"/>
      new B[,] {
        { B.O, B.O },
        { B.O, B.O },
      },
      /// <see cref="Rotation.Flip"/>
      new B[,] {
        { B.O, B.O },
        { B.O, B.O },
      },
      /// <see cref="Rotation.Left"/>
      new B[,] {
        { B.O, B.O },
        { B.O, B.O },
      },
    ];

    public static readonly B[][,] T = [
      /// <see cref="Rotation.Spawn"/>
      new B[,] {
        { _,   B.T, _   },
        { B.T, B.T, B.T },
        { _,   _,   _   },
      },
      /// <see cref="Rotation.Right"/>
      new B[,] {
        { _,   B.T, _   },
        { _,   B.T, B.T },
        { _,   B.T, _   },
      },
      /// <see cref="Rotation.Flip"/>
      new B[,] {
        { _,   _,   _   },
        { B.T, B.T, B.T },
        { _,   B.T, _   },
      },
      /// <see cref="Rotation.Left"/>
      new B[,] {
        { _,   B.T, _   },
        { B.T, B.T, _   },
        { _,   B.T, _   },
      },
    ];

    public static readonly B[][,] L = [
      /// <see cref="Rotation.Spawn"/>
      new B[,] {
        { _,   _,   B.L },
        { B.L, B.L, B.L },
        { _,   _,   _   },
      },
      /// <see cref="Rotation.Right"/>
      new B[,] {
        { _,   B.L, _   },
        { _,   B.L, _   },
        { _,   B.L, B.L },
      },
      /// <see cref="Rotation.Flip"/>
      new B[,] {
        { _,   _,   _   },
        { B.L, B.L, B.L },
        { B.L, _,   _   },
      },
      /// <see cref="Rotation.Left"/>
      new B[,] {
        { B.L, B.L, _   },
        { _,   B.L, _   },
        { _,   B.L, _   },
      },
    ];

    public static readonly B[][,] J = [
      /// <see cref="Rotation.Spawn"/>
      new B[,] {
        { B.J, _,   _   },
        { B.J, B.J, B.J },
        { _,   _,   _   },
      },
      /// <see cref="Rotation.Right"/>
      new B[,] {
        { _,   B.J, B.J },
        { _,   B.J, _   },
        { _,   B.J, _   },
      },
      /// <see cref="Rotation.Flip"/>
      new B[,] {
        { _,   _,   _   },
        { B.J, B.J, B.J },
        { _,   _,   B.J },
      },
      /// <see cref="Rotation.Left"/>
      new B[,] {
        { _,   B.J, _   },
        { _,   B.J, _   },
        { B.J, B.J, _   },
      },
    ];

    public static readonly B[][,] S = [
      /// <see cref="Rotation.Spawn"/>
      new B[,] {
        { _,   B.S, B.S },
        { B.S, B.S, _   },
        { _,   _,   _   },
      },
      /// <see cref="Rotation.Right"/>
      new B[,] {
        { _,   B.S, _   },
        { _,   B.S, B.S },
        { _,   _,   B.S },
      },
      /// <see cref="Rotation.Flip"/>
      new B[,] {
        { _,   _,   _   },
        { _,   B.S, B.S },
        { B.S, B.S, _   },
      },
      /// <see cref="Rotation.Left"/>
      new B[,] {
        { B.S, _,   _   },
        { B.S, B.S, _   },
        { _,   B.S, _   },
      },
    ];

    public static readonly B[][,] Z = [
      /// <see cref="Rotation.Spawn"/>
      new B[,] {
        { B.Z, B.Z, _   },
        { _,   B.Z, B.Z },
        { _,   _,   _   },
      },
      /// <see cref="Rotation.Right"/>
      new B[,] {
        { _,   _,   B.Z },
        { _,   B.Z, B.Z },
        { _,   B.Z, _   },
      },
      /// <see cref="Rotation.Flip"/>
      new B[,] {
        { _,   _,   _   },
        { B.Z, B.Z, _   },
        { _,   B.Z, B.Z },
      },
      /// <see cref="Rotation.Left"/>
      new B[,] {
        { _,   B.Z, _   },
        { B.Z, B.Z, _   },
        { B.Z, _,   _   },
      },
    ];
  }
}