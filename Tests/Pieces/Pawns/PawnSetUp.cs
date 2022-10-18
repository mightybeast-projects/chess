using NUnit.Framework;

namespace Chess.Tests.Pieces.Pawns;

abstract class PawnSetUp : BoardSetUp
{
    protected virtual void CreateAndAssertPawnHintTiles(
        string startingPosition,
        string[] hints)
    {
        CreateAndAddPiece(typeof(Pawn), startingPosition, color);

        foreach (string hintTileStr in hints)
            AssertHintTile(hintTileStr);
        Assert.AreEqual(hints.Length, piece.hints.Count);
    }

    protected void AssertHintTile(string hintTileStr)
    {
        tile = board.GetTile(hintTileStr);
        Assert.Contains(tile, piece.hints);
    }
}