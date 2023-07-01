using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.GameTests;

[TestFixture]
internal class CustomGameTests
{
    [Test]
    public void CustomGameSetUp_IsCorrect()
    {
        Board board = new Board();
        Game game = new Game(board, Color.BLACK);

        Assert.AreEqual(game.board, board);
        Assert.AreEqual(game.currentPlayer.color, Color.BLACK);
    }
}