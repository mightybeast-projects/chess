using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
class PieceTests : BoardSetUp
{
    [Test]
    public void PieceInitializationTest()
    {
        tile = board.GetTile("d4");
        color = Color.WHITE;
        piece = new Pawn(tile, color);
        piece.SetBoard(board);
        
        AssertPiece();
    }

    [Test]
    public void AddPieceToBoard()
    {
        CreateAndAddPiece(typeof(Pawn), "a1", Color.WHITE);
        AssertBoardPiece();

        CreateAndAddPiece(typeof(Pawn), "e4", Color.BLACK);
        AssertBoardPiece();
    }

    private void AssertBoardPiece()
    {
        AssertPiece();

        Assert.IsTrue(board.pieces.Contains(piece));
    }
}