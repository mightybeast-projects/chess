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
    }

    [Test]
    public void WhitePawnHasOneHintTile()
    {
        AssertHintTiles("d4", new string[] { "d5" });
        AssertHintTiles("e4", new string[] { "e5" });
    }

    [Test]
    public void WhitePawnHasTwoHintTiles()
    {
        AssertHintTiles("a2", new string[] { "a3", "a4" });
        AssertHintTiles("d2", new string[] { "d3", "d4" });
    }

    [Test]
    public void WhitePawnHasNoHintsWhenPathBlocked()
    {
        Piece d2Pawn = CreateAndAddPiece(typeof(Pawn), "d2", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "d3", Color.BLACK);

        Assert.IsEmpty(d2Pawn.hints);
    }

    private void AssertHintTiles(string startingPosition, string[] hints)
    {
        CreateAndAddPiece(typeof(Pawn), startingPosition, Color.WHITE);

        foreach (string hintTileStr in hints)
            AssertHintTile(hintTileStr);
    }

    private void AssertHintTile(string hintTileStr)
    {
        _tile = _board.GetTile(hintTileStr);
        Assert.Contains(_tile, _piece.hints);
    }
}