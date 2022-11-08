using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class BoardSetupTests : BoardTestDataBuilder
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
        AssertSetupPiece(typeof(Bishop), "c1");
        AssertSetupPiece(typeof(Bishop), "f1");
        AssertSetupPiece(typeof(Queen), "d1");
        AssertSetupPiece(typeof(King), "e1");

        color = Color.BLACK;
        AssertPawnRow(7);
        AssertSetupPiece(typeof(Rook), "a8");
        AssertSetupPiece(typeof(Rook), "h8");
        AssertSetupPiece(typeof(Knight), "b8");
        AssertSetupPiece(typeof(Knight), "g8");
        AssertSetupPiece(typeof(Bishop), "c8");
        AssertSetupPiece(typeof(Bishop), "f8");
        AssertSetupPiece(typeof(Queen), "d8");
        AssertSetupPiece(typeof(King), "e8");

        Assert.AreEqual(32, board.pieces.Count);
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