using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class BoardSetupTests : BoardTestDataBuilder
{
    private char letter;
    private string tileName;

    [Test]
    public void BoardSetupIsCorrect()
    {
        board.SetUp();

        AssertPieceRows(Color.WHITE, 2, 1);
        AssertPieceRows(Color.BLACK, 7, 8);
        Assert.AreEqual(32, board.pieces.Count);
    }

    private void AssertPieceRows(Color color, int pawnRowIndex, int pieceRowIndex)
    {
        this.color = color;
        AssertPawnRow(pawnRowIndex);
        AssertSetupPiece(typeof(Rook), "a" + pieceRowIndex);
        AssertSetupPiece(typeof(Knight), "b" + pieceRowIndex);
        AssertSetupPiece(typeof(Bishop), "c" + pieceRowIndex);
        AssertSetupPiece(typeof(Queen), "d" + pieceRowIndex);
        AssertSetupPiece(typeof(King), "e" + pieceRowIndex);
        AssertSetupPiece(typeof(Bishop), "f" + pieceRowIndex);
        AssertSetupPiece(typeof(Knight), "g" + pieceRowIndex);
        AssertSetupPiece(typeof(Rook), "h" + pieceRowIndex);
    }

    private void AssertPawnRow(int rowIndex)
    {
        for (int i = 0; i < board.grid.GetLength(0); i++)
            AssertPawnInRow(i, rowIndex);
    }

    private void AssertPawnInRow(int letterIndex, int rowIndex)
    {
        letter = (char) (letterIndex+ 65);
        tileName = letter.ToString().ToLower() + rowIndex;

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