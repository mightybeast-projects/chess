using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests;

[TestFixture]
public class CastlingTests
{
    private Board board;

    [SetUp]
    public void SetUp() => board = new Board();

    [Test]
    public void WhiteKing_DoesNotHaveAnyCaslingMoves_OnEmptyBoard()
    {
        King whiteKing = new King(board.GetTile("e1"), Color.WHITE);

        board.AddPiece(whiteKing);

        Assert.That(whiteKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d1"),
            board.GetTile("d2"),
            board.GetTile("e2"),
            board.GetTile("f2"),
            board.GetTile("f1")
        }));
    }

    [Test]
    public void WhiteKing_HasKingSideCastlingMove()
    {
        King whiteKing = new King(board.GetTile("e1"), Color.WHITE);
        Rook whiteRook = new Rook(board.GetTile("h1"), Color.WHITE);

        board.AddPiece(whiteKing);
        board.AddPiece(whiteRook);

        Assert.That(whiteKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d1"),
            board.GetTile("d2"),
            board.GetTile("e2"),
            board.GetTile("f2"),
            board.GetTile("f1"),
            board.GetTile("g1"),
        }));
    }

    [Test]
    public void WhiteKing_DoesNotHaveCastlingMoves_IfItHasMoved()
    {
        King whiteKing = new King(board.GetTile("e1"), Color.WHITE);
        Rook whiteRook = new Rook(board.GetTile("h1"), Color.WHITE);

        board.AddPiece(whiteKing);
        board.AddPiece(whiteRook);

        whiteKing.Move("e2");
        whiteKing.Move("e1");

        Assert.That(whiteKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d1"),
            board.GetTile("d2"),
            board.GetTile("e2"),
            board.GetTile("f2"),
            board.GetTile("f1"),
        }));
    }

    [Test]
    public void WhiteKing_DoesNotHaveCastlingMoves_IfItIsInCheck()
    {
        King whiteKing = new King(board.GetTile("e1"), Color.WHITE);
        Rook whiteRook = new Rook(board.GetTile("h1"), Color.WHITE);

        Queen blackQueen = new Queen(board.GetTile("e8"), Color.BLACK);

        board.AddPiece(whiteKing);
        board.AddPiece(whiteRook);
        board.AddPiece(blackQueen);

        Assert.That(whiteKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d1"),
            board.GetTile("d2"),
            board.GetTile("f2"),
            board.GetTile("f1"),
        }));
    }

    [Test]
    public void WhiteKing_DoesNotHaveCastlingMoves_IfRookHasMoved()
    {
        King whiteKing = new King(board.GetTile("e1"), Color.WHITE);
        Rook whiteRook = new Rook(board.GetTile("h1"), Color.WHITE);

        board.AddPiece(whiteKing);
        board.AddPiece(whiteRook);

        whiteRook.Move("h2");
        whiteRook.Move("h1");

        Assert.That(whiteKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d1"),
            board.GetTile("d2"),
            board.GetTile("e2"),
            board.GetTile("f2"),
            board.GetTile("f1"),
        }));
    }

    [Test]
    public void WhiteKing_DoesNotHaveKingSideCastlingMove_IfPassingTilesAreNotEmpty()
    {
        King whiteKing = new King(board.GetTile("e1"), Color.WHITE);
        Bishop whiteBishop = new Bishop(board.GetTile("f1"), Color.WHITE);
        Knight whiteKnight = new Knight(board.GetTile("g1"), Color.WHITE);
        Rook whiteRook = new Rook(board.GetTile("h1"), Color.WHITE);

        board.AddPiece(whiteKing);
        board.AddPiece(whiteBishop);
        board.AddPiece(whiteKnight);
        board.AddPiece(whiteRook);

        Assert.That(whiteKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d1"),
            board.GetTile("d2"),
            board.GetTile("e2"),
            board.GetTile("f2"),
        }));
    }

    [Test]
    public void WhiteKing_DoesNotHaveCastlingMoves_IfPassingTilesAreUnderAttack()
    {
        King whiteKing = new King(board.GetTile("e1"), Color.WHITE);
        Pawn whitePawn = new Pawn(board.GetTile("e2"), Color.WHITE);
        Rook whiteRook = new Rook(board.GetTile("h1"), Color.WHITE);

        Queen blackQueen = new Queen(board.GetTile("e8"), Color.BLACK);
        Bishop blackBishop1 = new Bishop(board.GetTile("h3"), Color.BLACK);
        Bishop blackBishop2 = new Bishop(board.GetTile("h2"), Color.BLACK);

        board.AddPiece(whiteKing);
        board.AddPiece(whiteRook);
        board.AddPiece(whitePawn);
        board.AddPiece(blackQueen);
        board.AddPiece(blackBishop1);
        board.AddPiece(blackBishop2);

        Assert.That(whiteKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d1"),
            board.GetTile("d2"),
            board.GetTile("f2")
        }));
    }
}