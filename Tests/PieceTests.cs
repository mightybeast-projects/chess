using Chess.Core;
using Chess.Core.Exceptions;
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
        _piece.board = _board;
        
        AssertPiece();
    }

    [Test]
    public void AddPieceToBoard()
    {
        CreateAndAddPiece(typeof(Piece), "a1", Color.WHITE);
        AssertPiece();

        CreateAndAddPiece(typeof(Piece), "b1", Color.BLACK);
        AssertPiece();
    }

    [Test]
    public void TileWithPieceIsNotEmpty()
    {
        CreateAndAddPiece(typeof(Piece), "a1", Color.BLACK);
        CreateAndAddPiece(typeof(Piece), "e4", Color.BLACK);
        CreateAndAddPiece(typeof(Piece), "d4", Color.BLACK);

        Assert.IsFalse(_board.grid[0, 0].isEmpty);
        Assert.IsFalse(_board.grid[3, 3].isEmpty);
        Assert.IsFalse(_board.grid[3, 4].isEmpty);
    }

    [Test]
    public void MovePiece()
    {
        CreateAndAddPiece(typeof(Piece), "d4", Color.WHITE);
        
        _piece.Move("d8");

        Assert.IsTrue(_board.GetTile("d4").isEmpty);
        Assert.AreEqual(_board.GetTile("d8"), _piece.tile);
        Assert.IsFalse(_board.GetTile("d8").isEmpty);
    }
}