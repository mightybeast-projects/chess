using NUnit.Framework;

namespace Chess.Tests.Pieces;

internal class PieceTestDataBuilder : BoardTestDataBuilder
{
    protected void AssertPieceLegalMoves(string[] legalMoves)
    {
        foreach (string legalMoveTileStr in legalMoves)
            AssertLegalMove(legalMoveTileStr);
            
        Assert.AreEqual(legalMoves.Length, piece.legalMoves.Count);
    }

    private void AssertLegalMove(string legalMoveTileStr)
    {
        tile = board.GetTile(legalMoveTileStr);
        
        Assert.Contains(tile, piece.legalMoves);
    }
}