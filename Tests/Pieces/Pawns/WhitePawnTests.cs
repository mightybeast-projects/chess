using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Pawns;

[TestFixture]
class WhitePawnTests : PieceSetUp, IPawnTest
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
        CreateAndAssertWhitePawnHintTiles("d4", new string[] { "d5" });
        CreateAndAssertWhitePawnHintTiles("e4", new string[] { "e5" });
    }

    [Test]
    public void PawnHasTwoHintTiles()
    {
        CreateAndAssertWhitePawnHintTiles("d2", new string[] { "d3", "d4" });
        CreateAndAssertWhitePawnHintTiles("e2", new string[] { "e3", "e4" });
    }

    [Test]
    public void PawnHasNoHintTilesOnTheEdgeOfTheBoard()
    {
        CreateAndAddPiece(typeof(Pawn), "a8", Color.WHITE);

        Assert.AreEqual(0, piece.hintTiles.Count);
    }

    [Test]
    public void PawnHasNoHintsWhenPathBlocked()
    {
        Piece d2Pawn = CreateAndAddPiece(typeof(Pawn), "d2", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "d3", Color.BLACK);

        Assert.IsEmpty(d2Pawn.hintTiles);
    }

    [Test]
    public void PawnHasOneHintTileAndOneCapture()
    {
        CreateAndAddPiece(typeof(Pawn), "b5", Color.BLACK);
        CreateAndAssertWhitePawnHintTiles("a4", new string[] { "a5", "b5" });

        CreateAndAddPiece(typeof(Pawn), "g5", Color.BLACK);
        CreateAndAssertWhitePawnHintTiles("h4", new string[] { "h5", "g5" });

        CreateAndAddPiece(typeof(Pawn), "e5", Color.BLACK);
        CreateAndAssertWhitePawnHintTiles("d4", new string[] { "d5", "e5" });
    }

    [Test]
    public void PawnHasOneHintTileAndTwoCaptures()
    {
        CreateAndAddPiece(typeof(Pawn), "c5", Color.BLACK);
        CreateAndAddPiece(typeof(Pawn), "e5", Color.BLACK);

        CreateAndAssertWhitePawnHintTiles("d4", new string[] { "c5", "d5", "e5" });
    }

    private void CreateAndAssertWhitePawnHintTiles(
        string startingPosition,
        string[] hints)
    {
        color = Color.WHITE;
        CreateAndAddPiece(typeof(Pawn), startingPosition, color);
        AssertPieceHintTiles(hints);
    }
}