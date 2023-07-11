using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.GameTests;

[TestFixture]
public class PlayerTests : GameTestFixtureSetUp
{
    [Test]
    public void GamePlayers_AreCorrect()
    {
        Assert.AreEqual(game.whitePlayer.board, game.board);
        Assert.AreEqual(game.blackPlayer.board, game.board);
        Assert.AreEqual(game.whitePlayer.king, game.board.whiteKing);
        Assert.AreEqual(game.blackPlayer.king, game.board.blackKing);
    }
}