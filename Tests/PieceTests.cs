using Chess.Core;
using Chess.Core.Exceptions;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class PieceTests : BoardSetUp
{
    private Piece _piece;

    [SetUp]
    public override void SetUp()
    {
        base.SetUp();
        _piece = new Piece();
    }

    [Test]
    public void PieceInitializationTest()
    {
        Assert.NotNull(_piece);
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
        Assert.AreEqual(false, _board.grid[0, 0].isEmpty);
    }
}