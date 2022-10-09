using Chess.Core;
using Chess.Core.Exceptions;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class PieceTests : BoardSetUp
{
    private Tile _tile;
    private Piece _piece;

    [SetUp]
    public override void SetUp()
    {
        base.SetUp();
    }

    [Test]
    public void PieceInitializationTest()
    {
        _tile = _board.GetTile("d4");
        _piece = new Piece(_board, _tile);
        
        Assert.AreEqual(_board, _piece.board);
        Assert.AreEqual(_tile, _piece.tile);
    }

    [Test]
    public void AddPieceBeyondBoard()
    {
        Assert.Throws<IncorrectTileNotationException>(
            () => _board.AddPiece("a0")
        );
    }

    [Test]
    public void AddPieceToBoard()
    {
        _piece = _board.AddPiece("a1");
        Assert.AreEqual(_board.grid[0, 0], _piece.tile);

        _piece = _board.AddPiece("b1");
        Assert.AreEqual(_board.grid[0, 1], _piece.tile);
    }

    [Test]
    public void TileWithPieceIsNotEmpty()
    {
        _board.AddPiece("a1");
        _board.AddPiece("e4");
        _board.AddPiece("d4");

        Assert.IsFalse(_board.grid[0, 0].isEmpty);
        Assert.IsFalse(_board.grid[3, 3].isEmpty);
        Assert.IsFalse(_board.grid[3, 4].isEmpty);
    }

    [Test]
    public void MovePiece()
    {
        _piece = _board.AddPiece("d4");
        _piece.Move("d8");

        Assert.IsTrue(_board.GetTile("d4").isEmpty);
        Assert.AreEqual(_board.GetTile("d8"), _piece.tile);
        Assert.IsFalse(_board.GetTile("d8").isEmpty);
    }
}