using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class BoardSetupTests : BoardSetUp
{
    [Test]
    public void BoardSetupIsCorrect()
    {
        board.SetUp();

        color = Color.WHITE;
        AssertPawnRow(2);
        AssertSetupPiece(typeof(Rook), "a1");
        AssertSetupPiece(typeof(Rook), "h1");
        AssertSetupPiece(typeof(Knight), "b1");
        AssertSetupPiece(typeof(Knight), "g1");

        color = Color.BLACK;
        AssertPawnRow(7);
        AssertSetupPiece(typeof(Rook), "a8");
        AssertSetupPiece(typeof(Rook), "h8");
        AssertSetupPiece(typeof(Knight), "b8");
        AssertSetupPiece(typeof(Knight), "g8");

        Assert.AreEqual(24, board.pieces.Count);
    }

    private void AssertPawnRow(int rowIndex)
    {
        for (int i = 0; i < board.grid.GetLength(0); i++)
            AssertPawnInRow(i, rowIndex);
    }

    private void AssertPawnInRow(int letterIndex, int rowIndex)
    {
        char letter = (char) (letterIndex+ 65);
        string tileName = letter.ToString().ToLower() + rowIndex;

        AssertSetupPiece(typeof(Pawn), tileName);
    }

    private void AssertSetupPiece(Type pieceType, string tileName)
    {
        tile = board.GetTile(tileName);
        piece = tile.piece;

        Assert.IsFalse(tile.isEmpty);
        Assert.AreEqual(pieceType, piece.GetType());
        Assert.AreEqual(color, piece.color);
    }
}