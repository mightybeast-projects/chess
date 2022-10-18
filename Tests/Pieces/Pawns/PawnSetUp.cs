using NUnit.Framework;

namespace Chess.Tests.Pieces.Pawns;

abstract class PawnSetUp : BoardSetUp
{
    protected virtual void CreateAndAssertPawnHintTiles(
        string startingPosition,
        string[] hints)
    {
        CreateAndAddPiece(typeof(Pawn), startingPosition, _color);

        foreach (string hintTileStr in hints)
            AssertHintTile(hintTileStr);
        Assert.AreEqual(hints.Length, _piece.hints.Count);
    }

    protected void AssertHintTile(string hintTileStr)
    {
        _tile = _board.GetTile(hintTileStr);
        Assert.Contains(_tile, _piece.hints);
    }
}