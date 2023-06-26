using Chess.Core;
using Chess.Core.Exceptions;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests;

[TestFixture]
internal class CheckTests : BoardTestFixtureSetUp
{
    [Test]
    public void WhiteKing_IsChecked()
    {
        Piece blackPawn = new Pawn(board.GetTile("b3"), Color.BLACK);

        board.AddPiece(new King(board.GetTile("a1"), Color.WHITE));

        board.AddPiece(blackPawn);

        blackPawn.Move("b2");

        Assert.IsTrue(board.whiteKing.isChecked);
        Assert.That(board.whiteKing.legalMoves, Is.EquivalentTo(new[] {
            board.GetTile("a2"),
            board.GetTile("b2"),
            board.GetTile("b1")
        }));
    }

    [Test]
    public void BlackKing_IsChecked()
    {
        Piece whitePawn = new Pawn(board.GetTile("b6"), Color.WHITE);

        board.AddPiece(new King(board.GetTile("a8"), Color.BLACK));

        board.AddPiece(whitePawn);

        whitePawn.Move("b7");

        Assert.IsTrue(board.blackKing.isChecked);
        Assert.That(board.blackKing.legalMoves, Is.EquivalentTo(new[] {
            board.GetTile("a7"),
            board.GetTile("b7"),
            board.GetTile("b8")
        }));
    }

    [Test]
    public void WhiteKing_AvoidedCheck()
    {
        Piece whiteKing = new King(board.GetTile("a1"), Color.WHITE);
        Piece blackPawn = new Pawn(board.GetTile("b3"), Color.BLACK);

        board.AddPiece(whiteKing);
        board.AddPiece(blackPawn);

        blackPawn.Move("b2");
        whiteKing.Move("a2");

        Assert.IsFalse(board.whiteKing.isChecked);
    }

    [Test]
    public void BlackKing_AvoidedCheck()
    {
        Piece blackKing = new King(board.GetTile("a8"), Color.BLACK);
        Piece whitePawn = new Pawn(board.GetTile("b6"), Color.WHITE);

        board.AddPiece(blackKing);
        board.AddPiece(whitePawn);

        whitePawn.Move("b7");
        blackKing.Move("a7");

        Assert.IsFalse(board.blackKing.isChecked);
    }

    [Test]
    public void PlayerCannotMoveAllyPiece_IfKingIsStillUnderCheck_AfterMoveIsMade()
    {
        Piece whitePawn = new Pawn(board.GetTile("b4"), Color.WHITE);
        Piece blackPawn = new Pawn(board.GetTile("b3"), Color.BLACK);

        board.AddPiece(new King(board.GetTile("a1"), Color.WHITE));
        board.AddPiece(whitePawn);

        board.AddPiece(new King(board.GetTile("a8"), Color.BLACK));
        board.AddPiece(blackPawn);

        blackPawn.Move("b2");

        Assert.IsEmpty(whitePawn.legalMoves);
        Assert.Throws<IllegalMoveException>(
            () => whitePawn.Move("b5")
        );
    }

    [Test]
    public void PlayerCanMoveAllyPiece_IfKingIsNotInCheck_AfterMoveIsMade()
    {
        Piece whiteKing = new King(board.GetTile("a1"), Color.WHITE);
        Piece whitePawn = new Pawn(board.GetTile("b4"), Color.WHITE);
        Piece bishop = new Bishop(board.GetTile("h8"), Color.WHITE);
        Piece knight = new Knight(board.GetTile("d1"), Color.WHITE);
        Piece rook = new Rook(board.GetTile("b1"), Color.WHITE);
        Piece queen = new Rook(board.GetTile("h2"), Color.WHITE);

        Piece blackPawn = new Pawn(board.GetTile("b3"), Color.BLACK);

        board.AddPiece(whiteKing);
        board.AddPiece(whitePawn);
        board.AddPiece(bishop);
        board.AddPiece(knight);
        board.AddPiece(rook);
        board.AddPiece(queen);

        board.AddPiece(blackPawn);

        blackPawn.Move("b2");

        Assert.That(whiteKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("a2"),
            board.GetTile("b2")
        }));
        Assert.IsEmpty(whitePawn.legalMoves);
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