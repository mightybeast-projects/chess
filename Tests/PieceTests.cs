using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class PieceTests : BoardSetUp
{
    [Test]
    public void PieceInitializationTest()
    {
        _tile = _board.GetTile("d4");
        _color = Color.WHITE;
        _piece = new Piece(_tile, _color);
        _piece.SetBoard(_board);
        
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
        
        _piece.Move("d8");

        Assert.IsTrue(_board.GetTile("d4").isEmpty);
        Assert.IsNull(_board.GetTile("d4").piece);
        Assert.AreEqual(_board.GetTile("d8"), _piece.currentTile);
        Assert.IsFalse(_board.GetTile("d8").isEmpty);
        Assert.AreEqual(_board.GetTile("d8").piece, _piece);
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
        Assert.AreEqual(_board.GetTile("d4"), d4Piece.currentTile);
        Assert.AreEqual(_board.GetTile("d5"), d5Piece.currentTile);
    }

    [Test]
    public void MovePieceToATileOccupiedByEnemy()
    {
        Piece d4Piece, d5Piece;
        d4Piece = CreateAndAddPiece(typeof(Piece), "d4", Color.WHITE);
        d5Piece = CreateAndAddPiece(typeof(Piece), "d5", Color.BLACK);

        d4Piece.Move("d5");
        Assert.AreEqual(1, _board.pieces.Count);
        Assert.AreEqual(_board.GetTile("d5"), d4Piece.currentTile);
        Assert.AreEqual(_board.GetTile("d5").piece, d4Piece);
        Assert.IsFalse(_board.pieces.Contains(d5Piece));
    }

    private void AssertBoardPiece()
    {
        AssertPiece();

        Assert.IsTrue(_board.pieces.Contains(_piece));
    }
}