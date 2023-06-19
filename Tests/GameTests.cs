using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
internal class GameTests
{
    [Test]
    public void GameInitialization() => new Game();

    [Test]
    public void GameStartSetUpIsCorrect()
    {
        Game game = new Game();
        
        game.Start();

        Assert.IsNotEmpty(game.board.pieces);
        Assert.NotNull(game.whitePlayer);
        Assert.NotNull(game.blackPlayer);
        Assert.AreEqual(game.currentPlayer.color, Color.WHITE);
    }
}