using NUnit.Framework;

namespace Chess.Tests.Pieces;

class PieceSetUp : BoardSetUp
{
    protected void AssertPieceHintTiles(string[] hints)
    {
        foreach (string hintTileStr in hints)
            AssertHintTile(hintTileStr);
        Assert.AreEqual(hints.Length, piece.hintTiles.Count);
    }

    protected void AssertHintTile(string hintTileStr)
    {
        tile = board.GetTile(hintTileStr);
        Assert.Contains(tile, piece.hintTiles);
    }
}