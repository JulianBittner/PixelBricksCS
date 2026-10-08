using PixelBricksCS.Game.Gameplay;
using PixelBricksCS.Game.Gameplay.Bricks;

namespace PixelBricksCS.Game.Assets
{
  // Shapes are indexed [y, x]. Each occupied cell holds the brick's ID, empty cells are None.
  internal static class BrickBodySet
  {
    // Single-letter aliases keep the shapes readable as pictures.
    // Lowercase to avoid clashing with the BrickBody fields below.
    private const BrickID _ = BrickID.None;
    private const BrickID i = BrickID.I;
    private const BrickID o = BrickID.O;
    private const BrickID t = BrickID.T;
    private const BrickID l = BrickID.L;
    private const BrickID j = BrickID.J;
    private const BrickID s = BrickID.S;
    private const BrickID z = BrickID.Z;

    public static readonly BrickBody I = new([
      /// <see cref="BrickRotation.Spawn"/>
      new(new BrickID[,] {
        { _, _, _, _ },
        { i, i, i, i },
        { _, _, _, _ },
        { _, _, _, _ },
      }),
      /// <see cref="BrickRotation.Right"/>
      new(new BrickID[,] {
        { _, _, i, _ },
        { _, _, i, _ },
        { _, _, i, _ },
        { _, _, i, _ },
      }),
      /// <see cref="BrickRotation.Flip"/>
      new(new BrickID[,] {
        { _, _, _, _ },
        { _, _, _, _ },
        { i, i, i, i },
        { _, _, _, _ },
      }),
      /// <see cref="BrickRotation.Left"/>
      new(new BrickID[,] {
        { _, i, _, _ },
        { _, i, _, _ },
        { _, i, _, _ },
        { _, i, _, _ },
      }),
    ]);

    public static readonly BrickBody O = new([
      /// <see cref="BrickRotation.Spawn"/>
      new(new BrickID[,] {
        { o, o },
        { o, o },
      }),
      /// <see cref="BrickRotation.Right"/>
      new(new BrickID[,] {
        { o, o },
        { o, o },
      }),
      /// <see cref="BrickRotation.Flip"/>
      new(new BrickID[,] {
        { o, o },
        { o, o },
      }),
      /// <see cref="BrickRotation.Left"/>
      new(new BrickID[,] {
        { o, o },
        { o, o },
      }),
    ]);

    public static readonly BrickBody T = new([
      /// <see cref="BrickRotation.Spawn"/>
      new(new BrickID[,] {
        { _, t, _ },
        { t, t, t },
        { _, _, _ },
      }),
      /// <see cref="BrickRotation.Right"/>
      new(new BrickID[,] {
        { _, t, _ },
        { _, t, t },
        { _, t, _ },
      }),
      /// <see cref="BrickRotation.Flip"/>
      new(new BrickID[,] {
        { _, _, _ },
        { t, t, t },
        { _, t, _ },
      }),
      /// <see cref="BrickRotation.Left"/>
      new(new BrickID[,] {
        { _, t, _ },
        { t, t, _ },
        { _, t, _ },
      }),
    ]);

    public static readonly BrickBody L = new([
      /// <see cref="BrickRotation.Spawn"/>
      new(new BrickID[,] {
        { _, _, l },
        { l, l, l },
        { _, _, _ },
      }),
      /// <see cref="BrickRotation.Right"/>
      new(new BrickID[,] {
        { _, l, _ },
        { _, l, _ },
        { _, l, l },
      }),
      /// <see cref="BrickRotation.Flip"/>
      new(new BrickID[,] {
        { _, _, _ },
        { l, l, l },
        { l, _, _ },
      }),
      /// <see cref="BrickRotation.Left"/>
      new(new BrickID[,] {
        { l, l, _ },
        { _, l, _ },
        { _, l, _ },
      }),
    ]);

    public static readonly BrickBody J = new([
      /// <see cref="BrickRotation.Spawn"/>
      new(new BrickID[,] {
        { j, _, _ },
        { j, j, j },
        { _, _, _ },
      }),
      /// <see cref="BrickRotation.Right"/>
      new(new BrickID[,] {
        { _, j, j },
        { _, j, _ },
        { _, j, _ },
      }),
      /// <see cref="BrickRotation.Flip"/>
      new(new BrickID[,] {
        { _, _, _ },
        { j, j, j },
        { _, _, j },
      }),
      /// <see cref="BrickRotation.Left"/>
      new(new BrickID[,] {
        { _, j, _ },
        { _, j, _ },
        { j, j, _ },
      }),
    ]);

    public static readonly BrickBody S = new([
      /// <see cref="BrickRotation.Spawn"/>
      new(new BrickID[,] {
        { _, s, s },
        { s, s, _ },
        { _, _, _ },
      }),
      /// <see cref="BrickRotation.Right"/>
      new(new BrickID[,] {
        { _, s, _ },
        { _, s, s },
        { _, _, s },
      }),
      /// <see cref="BrickRotation.Flip"/>
      new(new BrickID[,] {
        { _, _, _ },
        { _, s, s },
        { s, s, _ },
      }),
      /// <see cref="BrickRotation.Left"/>
      new(new BrickID[,] {
        { s, _, _ },
        { s, s, _ },
        { _, s, _ },
      }),
    ]);

    public static readonly BrickBody Z = new([
      /// <see cref="BrickRotation.Spawn"/>
      new(new BrickID[,] {
        { z, z, _ },
        { _, z, z },
        { _, _, _ },
      }),
      /// <see cref="BrickRotation.Right"/>
      new(new BrickID[,] {
        { _, _, z },
        { _, z, z },
        { _, z, _ },
      }),
      /// <see cref="BrickRotation.Flip"/>
      new(new BrickID[,] {
        { _, _, _ },
        { z, z, _ },
        { _, z, z },
      }),
      /// <see cref="BrickRotation.Left"/>
      new(new BrickID[,] {
        { _, z, _ },
        { z, z, _ },
        { z, _, _ },
      }),
    ]);

    public static BrickBody Get(BrickID id) => id switch {
      BrickID.I => I,
      BrickID.O => O,
      BrickID.T => T,
      BrickID.L => L,
      BrickID.J => J,
      BrickID.S => S,
      BrickID.Z => Z,
      _ => throw new ArgumentOutOfRangeException(nameof(id), $"No body for brick '{id}'."),
    };
  }
}