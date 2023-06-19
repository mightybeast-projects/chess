using chess.Core.Exceptions;
using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
internal class GameTests
{
    [Test]
    public void GameInitialization() => new Game();

    [Test]
    public void GameStartSetUp_IsCorrect()
    {
        Game game = new Game();
        
        game.Start();

        Assert.IsNotEmpty(game.board.whitePieces);
        Assert.IsNotEmpty(game.board.blackPieces);
        Assert.IsNotNull(game.whitePlayer);
        Assert.IsNotNull(game.blackPlayer);
        Assert.AreEqual(game.currentPlayer.color, Color.WHITE);
    }

    [Test]
    public void HandlePlayerMove_WhenMove_IsCorrect()
    {
        Game game = new Game();

        game.Start();
        game.HandlePlayerMove("d2", "d4");

        Assert.IsNull(game.board.GetTile("d2").piece);
        Assert.IsNotNull(game.board.GetTile("d4").piece);
        Assert.AreEqual(game.currentPlayer.color, Color.BLACK);
    }

    [Test]
    public void HandlePlayerMove_WhenMove_IsWrong()
    {
        Game game = new Game();

        game.Start();
        game.HandlePlayerMove("d3", "d4");

        Assert.IsNull(game.board.GetTile("d3").piece);
        Assert.IsNull(game.board.GetTile("d4").piece);
        Assert.AreEqual(game.currentPlayer.color, Color.WHITE);
    }

    [Test]
    public void HandlePlayerMove_ThrowsException_OnEnemyPieceMove()
    {
        Game game = new Game();

        game.Start();

        Assert.Throws<CannotMoveEnemyPieceException>(
            () => game.HandlePlayerMove("d7", "d6")
        );
        Assert.IsNotNull(game.board.GetTile("d7").piece);
        Assert.IsNull(game.board.GetTile("d6").piece);
        Assert.AreEqual(game.currentPlayer.color, Color.WHITE);
    }
}