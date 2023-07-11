using Chess.Core;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests;

[TestFixture]
internal class StalemateTests
{
    private Game game;
    private Board board;

    [SetUp]
    public void SetUp() => board = new Board();

    [Test]
    public void WhiteKing_IsInStalemate()
    {
        game = new Game(board, Color.WHITE);

        board.AddPiece(new King(board.GetTile("h1"), Color.WHITE));
        board.AddPiece(new Queen(board.GetTile("f2"), Color.BLACK));

        Assert.IsTrue(board.whiteKing.isInStalemate);
        Assert.IsTrue(game.isOver);
    }

    [Test]
    public void BlackKing_IsInStalemate()
    {
        game = new Game(board, Color.BLACK);

        board.AddPiece(new Queen(board.GetTile("c7"), Color.WHITE));
        board.AddPiece(new King(board.GetTile("a8"), Color.BLACK));

        Assert.IsTrue(board.blackKing.isInStalemate);
        Assert.IsTrue(game.isOver);
    }
}