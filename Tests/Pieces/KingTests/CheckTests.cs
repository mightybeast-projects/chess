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

        Assert.IsTrue(board.whiteKing.isChecked);
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

        Assert.IsTrue(board.blackKing.isChecked);
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

        Assert.IsFalse(board.whiteKing.isChecked);
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

        Assert.IsFalse(board.blackKing.isChecked);
    }

    [Test]
    public void PlayerCannotMoveAllyPiece_IfKingIsStillUnderCheck_AfterMoveIsMade()
    {
        Game game = new Game();
        Board board = game.board;

        game.currentPlayer = game.blackPlayer;

        board.AddPiece(new King(board.GetTile("a1"), Color.WHITE));
        board.AddPiece(new Pawn(board.GetTile("b4"), Color.WHITE));

        board.AddPiece(new King(board.GetTile("a8"), Color.BLACK));
        board.AddPiece(new Pawn(board.GetTile("b3"), Color.BLACK));

        game.HandlePlayerMove("b3", "b2");

        Assert.Throws<IllegalMoveException>(
            () => game.HandlePlayerMove("b4", "b5")
        );
    }

    [Test]
    public void PlayerCanMoveAllyPiece_IfKingIsNotInCheck_AfterMoveIsMade()
    {
        Game game = new Game();
        Board board = game.board;

        Piece bishop = new Bishop(board.GetTile("h8"), Color.WHITE);
        Piece knight = new Knight(board.GetTile("d1"), Color.WHITE);
        Piece rook = new Rook(board.GetTile("b1"), Color.WHITE);
        Piece queen = new Rook(board.GetTile("h2"), Color.WHITE);

        game.currentPlayer = game.blackPlayer;

        board.AddPiece(new King(board.GetTile("a1"), Color.WHITE));
        board.AddPiece(new Pawn(board.GetTile("b4"), Color.WHITE));
        board.AddPiece(bishop);
        board.AddPiece(knight);
        board.AddPiece(rook);
        board.AddPiece(queen);

        board.AddPiece(new King(board.GetTile("a8"), Color.BLACK));
        board.AddPiece(new Pawn(board.GetTile("b3"), Color.BLACK));

        game.HandlePlayerMove("b3", "b2");

        Assert.That(bishop.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("b2")
        }));
        Assert.That(knight.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("b2")
        }));
        Assert.That(rook.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("b2")
        }));
        Assert.That(queen.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("b2")
        }));
    }
}