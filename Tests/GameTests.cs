using chess.Core.Exceptions;
using Chess.Core;
using Chess.Core.Pieces;
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

    [Test]
    public void Check_ForWhiteKing()
    {
        Game game = new Game();
        Board board = game.board;

        game.currentPlayer = game.blackPlayer;

        board.AddPiece(new King(board, board.GetTile("a1"), Color.WHITE));
        board.AddPiece(new King(board, board.GetTile("a8"), Color.BLACK));
        board.AddPiece(new Pawn(board, board.GetTile("b3"), Color.BLACK));

        game.HandlePlayerMove("b3", "b2");

        Assert.IsTrue(game.whiteKing.isChecked);
    }

    [Test]
    public void Check_ForBlackKing()
    {
        Game game = new Game();
        Board board = game.board;

        game.currentPlayer = game.whitePlayer;

        board.AddPiece(new King(board, board.GetTile("a1"), Color.WHITE));
        board.AddPiece(new King(board, board.GetTile("a8"), Color.BLACK));
        board.AddPiece(new Pawn(board, board.GetTile("b6"), Color.WHITE));

        game.HandlePlayerMove("b6", "b7");

        Assert.IsTrue(game.blackKing.isChecked);
    }
}