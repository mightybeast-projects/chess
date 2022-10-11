using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class BoardSetUp
{
    protected Board _board;
    protected Piece _piece;
    protected Tile _tile;
    protected Color _color;

    [SetUp]
    public virtual void SetUp()
    {
        _board = new Board();
    }

    protected void CreatePiece(string tileName, Color color)
    {
        _tile = _board.GetTile(tileName);
        _color = color;
        _piece = new Piece(_tile, _color);
    }

    protected void AssertPiece()
    {
        Assert.AreEqual(_board, _piece.board);
        Assert.AreEqual(_tile, _piece.tile);
        Assert.AreEqual(_color, _piece.color);
    }
}