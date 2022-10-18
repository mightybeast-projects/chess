using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class PawnTests : BoardSetUp
{
    [Test]
    public void PawnInitialization()
    {
        CreateAndAddPiece(typeof(Pawn), "d4", Color.WHITE);
        AssertPiece();

        CreateAndAddPiece(typeof(Pawn), "e5", Color.BLACK);
        AssertPiece();
    }

    [Test]
    public void WhitePawnHasOneHintTile()
    {
        CreateAndAssertWhitePawnHintTiles("d4", new string[] { "d5" });
        CreateAndAssertWhitePawnHintTiles("e4", new string[] { "e5" });
    }

    [Test]
    public void BlackPawnHasOneHintTile()
    {
        CreateAndAssertBlackPawnHintTiles("d5", new string[] { "d4" });
        CreateAndAssertBlackPawnHintTiles("e5", new string[] { "e4" });
    }

    [Test]
    public void WhitePawnHasTwoHintTiles()
    {
        CreateAndAssertWhitePawnHintTiles("d2", new string[] { "d3", "d4" });
        CreateAndAssertWhitePawnHintTiles("e2", new string[] { "e3", "e4" });
    }

    [Test]
    public void BlackPawnHasTwoHintTiles()
    {
        CreateAndAssertBlackPawnHintTiles("d7", new string[] { "d6", "d5" });
        CreateAndAssertBlackPawnHintTiles("e7", new string[] { "e6", "e5" });
    }

    [Test]
    public void WhitePawnHasNoHintsWhenPathBlocked()
    {
        Piece d2Pawn = CreateAndAddPiece(typeof(Pawn), "d2", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "d3", Color.BLACK);

        Assert.IsEmpty(d2Pawn.hints);
    }

    [Test]
    public void WhitePawnHasOneHintTileAndOneCapture()
    {
        CreateAndAddPiece(typeof(Pawn), "e5", Color.BLACK);
        CreateAndAssertWhitePawnHintTiles("d4", new string[] { "d5", "e5" });

        CreateAndAddPiece(typeof(Pawn), "g5", Color.BLACK);
        CreateAndAssertWhitePawnHintTiles("h4", new string[] { "h5", "g5" });

        CreateAndAddPiece(typeof(Pawn), "b3", Color.BLACK);
        CreateAndAssertWhitePawnHintTiles("a2", new string[] { "a3", "a4", "b3" });
    }

    [Test]
    public void WhitePawnHasOneHintTileAndTwoCaptures()
    {
        CreateAndAddPiece(typeof(Pawn), "c5", Color.BLACK);
        CreateAndAddPiece(typeof(Pawn), "e5", Color.BLACK);

        CreateAndAssertWhitePawnHintTiles("d4", new string[] { "c5", "d5", "e5" });
    }

    private void CreateAndAssertWhitePawnHintTiles(string startingPosition, string[] hints)
    {
        CreateAndAddPiece(typeof(Pawn), startingPosition, Color.WHITE);

        foreach (string hintTileStr in hints)
            AssertHintTile(hintTileStr);
        Assert.AreEqual(hints.Length, _piece.hints.Count);
    }

    private void CreateAndAssertBlackPawnHintTiles(string startingPosition, string[] hints)
    {
        CreateAndAddPiece(typeof(Pawn), startingPosition, Color.BLACK);

        foreach (string hintTileStr in hints)
            AssertHintTile(hintTileStr);
        Assert.AreEqual(hints.Length, _piece.hints.Count);
    }

    private void AssertHintTile(string hintTileStr)
    {
        _tile = _board.GetTile(hintTileStr);
        Assert.Contains(_tile, _piece.hints);
    }
}