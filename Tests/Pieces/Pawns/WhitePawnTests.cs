using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Pawns;

[TestFixture]
class WhitePawnTests : PawnSetUp, IPawnTest
{
    [Test]
    public void PawnInitialization()
    {
        CreateAndAddPiece(typeof(Pawn), "d4", Color.WHITE);
        AssertPiece();
    }

    [Test]
    public void PawnHasOneHintTile()
    {
        CreateAndAssertPawnHintTiles("d4", new string[] { "d5" });
        CreateAndAssertPawnHintTiles("e4", new string[] { "e5" });
    }

    [Test]
    public void PawnHasTwoHintTiles()
    {
        CreateAndAssertPawnHintTiles("d2", new string[] { "d3", "d4" });
        CreateAndAssertPawnHintTiles("e2", new string[] { "e3", "e4" });
    }

    [Test]
    public void PawnHasNoHintsWhenPathBlocked()
    {
        Piece d2Pawn = CreateAndAddPiece(typeof(Pawn), "d2", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "d3", Color.BLACK);

        Assert.IsEmpty(d2Pawn.hints);
    }

    [Test]
    public void PawnHasOneHintTileAndOneCapture()
    {
        CreateAndAddPiece(typeof(Pawn), "b5", Color.BLACK);
        CreateAndAssertPawnHintTiles("a4", new string[] { "a5", "b5" });

        CreateAndAddPiece(typeof(Pawn), "g5", Color.BLACK);
        CreateAndAssertPawnHintTiles("h4", new string[] { "h5", "g5" });

        CreateAndAddPiece(typeof(Pawn), "e5", Color.BLACK);
        CreateAndAssertPawnHintTiles("d4", new string[] { "d5", "e5" });
    }

    [Test]
    public void PawnHasOneHintTileAndTwoCaptures()
    {
        CreateAndAddPiece(typeof(Pawn), "c5", Color.BLACK);
        CreateAndAddPiece(typeof(Pawn), "e5", Color.BLACK);

        CreateAndAssertPawnHintTiles("d4", new string[] { "c5", "d5", "e5" });
    }

    protected override void CreateAndAssertPawnHintTiles(
        string startingPosition,
        string[] hints)
    {
        _color = Color.WHITE;
        base.CreateAndAssertPawnHintTiles(startingPosition, hints);
    }
}