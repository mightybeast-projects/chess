using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Pawns;

[TestFixture]
class BlackPawnTests : PieceSetUp, IPawnTest
{
    [Test]
    public void PawnInitialization()
    {
        CreateAndAddPiece(typeof(Pawn), "e5", Color.BLACK);
        AssertPiece();
    }

    [Test]
    public void PawnHasOneHintTile()
    {
        CreateAndAssertBlackPawnHintTiles("d5", new string[] { "d4" });
        CreateAndAssertBlackPawnHintTiles("e5", new string[] { "e4" });
    }

    [Test]
    public void PawnHasTwoHintTiles()
    {
        CreateAndAssertBlackPawnHintTiles("d7", new string[] { "d6", "d5" });
        CreateAndAssertBlackPawnHintTiles("e7", new string[] { "e6", "e5" });
    }

    [Test]
    public void PawnHasNoHintTilesOnTheEdgeOfTheBoard()
    {
        CreateAndAddPiece(typeof(Pawn), "a1", Color.BLACK);

        Assert.AreEqual(0, piece.hintTiles.Count);
    }

    [Test]
    public void PawnHasNoHintsWhenPathBlocked()
    {
        Piece d7Pawn = CreateAndAddPiece(typeof(Pawn), "d7", Color.BLACK);
        CreateAndAddPiece(typeof(Pawn), "d6", Color.WHITE);

        Assert.IsEmpty(d7Pawn.hintTiles);
    }

    [Test]
    public void PawnHasOneHintTileAndOneCapture()
    {
        CreateAndAddPiece(typeof(Pawn), "b4", Color.WHITE);
        CreateAndAssertBlackPawnHintTiles("a5", new string[] { "a4", "b4" });

        CreateAndAddPiece(typeof(Pawn), "e4", Color.WHITE);
        CreateAndAssertBlackPawnHintTiles("d5", new string[] { "d4", "e4" });

        CreateAndAddPiece(typeof(Pawn), "g5", Color.WHITE);
        CreateAndAssertBlackPawnHintTiles("h6", new string[] { "h5", "g5" });
    }

    [Test]
    public void PawnHasOneHintTileAndTwoCaptures()
    {
        CreateAndAddPiece(typeof(Pawn), "c4", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "e4", Color.WHITE);

        CreateAndAssertBlackPawnHintTiles("d5", new string[] { "c4", "d4", "e4" });
    }

    private void CreateAndAssertBlackPawnHintTiles(
        string startingPosition,
        string[] hints)
    {
        color = Color.BLACK;
        CreateAndAddPiece(typeof(Pawn), startingPosition, color);
        AssertPieceHintTiles(hints);
    }
}