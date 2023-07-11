using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests;

[TestFixture]
internal class CheckmateTests : GameTestFixtureSetUp
{
    [Test]
    public void FoolsMate()
    {
        game.HandlePlayerMove("f2", "f3");
        game.HandlePlayerMove("e7", "e5");
        game.HandlePlayerMove("g2", "g4");
        game.HandlePlayerMove("d8", "h4");

        Assert.IsTrue(game.board.whiteKing.isCheckmated);
        Assert.IsTrue(game.isOver);
    }

    [Test]
    public void ReversedFoolsMate()
    {
        game.HandlePlayerMove("e2", "e4");
        game.HandlePlayerMove("f7", "f6");
        game.HandlePlayerMove("d2", "d4");
        game.HandlePlayerMove("g7", "g5");
        game.HandlePlayerMove("d1", "h5");

        Assert.IsTrue(game.board.blackKing.isCheckmated);
        Assert.IsTrue(game.isOver);
    }
}