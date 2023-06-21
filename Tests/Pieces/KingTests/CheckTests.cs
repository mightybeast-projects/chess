using Chess.Core;
using Chess.Core.Exceptions;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests;

[TestFixture]
public class CheckTests
{
    [Test]
    public void WhiteKing_IsChecked()
    {
        Game game = new Game();
        Board board = game.board;

        game.currentPlayer = game.blackPlayer;

        board.AddPiece(new King(board.GetTile("a1"), Color.WHITE));
        board.AddPiece(new King(board.GetTile("a8"), Color.BLACK));
        board.AddPiece(new Pawn(board.GetTile("b3"), Color.BLACK));

        game.HandlePlayerMove("b3", "b2");

        Assert.IsTrue(game.board.whiteKing.isChecked);
        Assert.That(board.whiteKing.legalMoves, Is.SubsetOf(new[] {
            board.GetTile("a2"),
            board.GetTile("b2"),
            board.GetTile("b1")
        }));
    }

    [Test]
    public void BlackKing_IsChecked()
    {
        Game game = new Game();
        Board board = game.board;

        game.currentPlayer = game.whitePlayer;

        board.AddPiece(new King(board.GetTile("a1"), Color.WHITE));
        board.AddPiece(new King(board.GetTile("a8"), Color.BLACK));
        board.AddPiece(new Pawn(board.GetTile("b6"), Color.WHITE));

        game.HandlePlayerMove("b6", "b7");

        Assert.IsTrue(game.board.blackKing.isChecked);
        Assert.That(board.blackKing.legalMoves, Is.SubsetOf(new[] {
            board.GetTile("a7"),
            board.GetTile("b7"),
            board.GetTile("b8")
        }));
    }

    [Test]
    public void WhiteKing_AvoidedCheck()
    {
        Game game = new Game();
        Board board = game.board;

        game.currentPlayer = game.blackPlayer;

        board.AddPiece(new King(board.GetTile("a1"), Color.WHITE));
        board.AddPiece(new King(board.GetTile("a8"), Color.BLACK));
        board.AddPiece(new Pawn(board.GetTile("b3"), Color.BLACK));

        game.HandlePlayerMove("b3", "b2");
        game.HandlePlayerMove("a1", "a2");

        Assert.IsFalse(game.board.whiteKing.isChecked);
    }

    [Test]
    public void BlackKing_AvoidedCheck()
    {
        Game game = new Game();
        Board board = game.board;

        game.currentPlayer = game.whitePlayer;

        board.AddPiece(new King(board.GetTile("a1"), Color.WHITE));
        board.AddPiece(new King(board.GetTile("a8"), Color.BLACK));
        board.AddPiece(new Pawn(board.GetTile("b6"), Color.WHITE));

        game.HandlePlayerMove("b6", "b7");
        game.HandlePlayerMove("a8", "a7");

        Assert.IsFalse(game.board.blackKing.isChecked);
    }
}