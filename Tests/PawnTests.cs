using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class PawnTests : BoardSetUp
{
    [Test]
    public void PawnInitialization()
    {
        _tile = _board.GetTile("d4");
        _color = Color.WHITE;
        _piece = new Pawn(_tile, _color);
        _piece.board = _board;

        Assert.AreEqual(_board, _piece.board);
        Assert.AreEqual(_tile, _piece.tile);
        Assert.AreEqual(_color, _piece.color);
    }
}