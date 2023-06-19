using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
internal class BoardSetupTests : BoardTestDataBuilder
{
    private Color color;

    [Test]
    public void BoardSetupIsCorrect()
    {
        board.SetUp();

        AssertPieces(Color.WHITE, 2, 1);
        AssertPieces(Color.BLACK, 7, 8);
        Assert.AreEqual(16, board.whitePieces.Count);
        Assert.AreEqual(16, board.blackPieces.Count);
        Assert.IsInstanceOf<King>(board.whitePieces[0]);
        Assert.IsInstanceOf<King>(board.blackPieces[0]);
    }

    private void AssertPieces(Color color, int pawnRowIndex, int pieceRowIndex)
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
        char letter = (char) (letterIndex+ 65);
        string tileName = letter.ToString().ToLower() + rowIndex;

        AssertSetupPiece(typeof(Pawn), tileName);
    }

    private void AssertSetupPiece(Type pieceType, string tileName)
    {
        Tile tile = board.GetTile(tileName);
        Piece piece = tile.piece;

        Assert.IsFalse(tile.isEmpty);
        Assert.AreEqual(pieceType, piece.GetType());
        Assert.AreEqual(color, piece.color);
    }
}