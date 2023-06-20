using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests;

[TestFixture]
public class CheckTests
{
    [Test]
    public void Check_ForWhiteKing()
    {
        Game game = new Game();
        Board board = game.board;

        game.currentPlayer = game.blackPlayer;

        board.AddPiece(new King(board.GetTile("a1"), Color.WHITE));
        board.AddPiece(new King(board.GetTile("a8"), Color.BLACK));
        board.AddPiece(new Pawn(board.GetTile("b3"), Color.BLACK));

        game.HandlePlayerMove("b3", "b2");

        Assert.IsTrue(game.board.whiteKing.isChecked);
    }

    [Test]
    public void Check_ForBlackKing()
    {
        Game game = new Game();
        Board board = game.board;

        game.currentPlayer = game.whitePlayer;

        board.AddPiece(new King(board.GetTile("a1"), Color.WHITE));
        board.AddPiece(new King(board.GetTile("a8"), Color.BLACK));
        board.AddPiece(new Pawn(board.GetTile("b6"), Color.WHITE));

        game.HandlePlayerMove("b6", "b7");

        Assert.IsTrue(game.board.blackKing.isChecked);
    }

    [Test]
    public void AvoidedCheck_ForWhiteKing()
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
    public void AvoidedCheck_ForBlackKing()
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