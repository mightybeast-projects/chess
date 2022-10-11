using Chess.Core;
using Chess.Core.Exceptions;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class PieceTests : BoardSetUp
{
    private Piece _piece;
    private Tile _tile;
    private Color _color;

    [SetUp]
    public override void SetUp()
    {
        base.SetUp();
    }

    [Test]
    public void PieceInitializationTest()
    {
        CreatePiece("d4", Color.WHITE);
        _piece.board = _board;
        
        AssertPiece();
    }

    [Test]
    public void AddPieceToBoard()
    {
        CreatePiece("a1", Color.WHITE);
        _board.AddPiece(_piece);

        AssertPiece();

        CreatePiece("b1", Color.BLACK);
        _board.AddPiece(_piece);

        AssertPiece();
    }

    [Test]
    public void TileWithPieceIsNotEmpty()
    {
        CreatePiece("a1", Color.BLACK);
        _board.AddPiece(_piece);
        CreatePiece("e4", Color.BLACK);
        _board.AddPiece(_piece);
        CreatePiece("d4", Color.BLACK);
        _board.AddPiece(_piece);

        Assert.IsFalse(_board.grid[0, 0].isEmpty);
        Assert.IsFalse(_board.grid[3, 3].isEmpty);
        Assert.IsFalse(_board.grid[3, 4].isEmpty);
    }

    [Test]
    public void MovePiece()
    {
        CreatePiece("d4", Color.WHITE);
        _piece = _board.AddPiece(_piece);
        _piece.Move("d8");

        Assert.IsTrue(_board.GetTile("d4").isEmpty);
        Assert.AreEqual(_board.GetTile("d8"), _piece.tile);
        Assert.IsFalse(_board.GetTile("d8").isEmpty);
    }

    private void CreatePiece(string tileName, Color color)
    {
        _tile = _board.GetTile(tileName);
        _color = color;
        _piece = new Piece(_tile, _color);
    }

    private void AssertPiece()
    {
        Assert.AreEqual(_board, _piece.board);
        Assert.AreEqual(_tile, _piece.tile);
        Assert.AreEqual(_color, _piece.color);
    }
}