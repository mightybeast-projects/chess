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
        piece = new Piece(tile, color);
        piece.SetBoard(board);
        
        AssertPiece();
    }

    [Test]
    public void AddPieceToBoard()
    {
        CreateAndAddPiece(typeof(Piece), "a1", Color.WHITE);
        AssertBoardPiece();

        CreateAndAddPiece(typeof(Piece), "e4", Color.BLACK);
        AssertBoardPiece();
    }

    [Test]
    public void MovePiece()
    {
        CreateAndAddPiece(typeof(Piece), "d4", Color.WHITE);
        
        piece.Move("d8");

        Assert.IsTrue(board.GetTile("d4").isEmpty);
        Assert.IsNull(board.GetTile("d4").piece);
        Assert.AreEqual(board.GetTile("d8"), piece.currentTile);
        Assert.IsFalse(board.GetTile("d8").isEmpty);
        Assert.AreEqual(board.GetTile("d8").piece, piece);
    }

    [Test]
    public void MovePieceToATileOccupiedByAlly()
    {
        Piece d4Piece, d5Piece;
        d4Piece = CreateAndAddPiece(typeof(Piece), "d4", Color.WHITE);
        d5Piece = CreateAndAddPiece(typeof(Piece), "d5", Color.WHITE);

        Assert.Throws<OccupiedByAllyException>(
            () => d4Piece.Move("d5")
        );
        Assert.AreEqual(board.GetTile("d4"), d4Piece.currentTile);
        Assert.AreEqual(board.GetTile("d5"), d5Piece.currentTile);
    }

    [Test]
    public void MovePieceToATileOccupiedByEnemy()
    {
        Piece d4Piece, d5Piece;
        d4Piece = CreateAndAddPiece(typeof(Piece), "d4", Color.WHITE);
        d5Piece = CreateAndAddPiece(typeof(Piece), "d5", Color.BLACK);

        d4Piece.Move("d5");
        Assert.AreEqual(1, board.pieces.Count);
        Assert.AreEqual(board.GetTile("d5"), d4Piece.currentTile);
        Assert.AreEqual(board.GetTile("d5").piece, d4Piece);
        Assert.IsFalse(board.pieces.Contains(d5Piece));
    }

    private void AssertBoardPiece()
    {
        AssertPiece();

        Assert.IsTrue(board.pieces.Contains(piece));
    }
}