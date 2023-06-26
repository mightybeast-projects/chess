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
    public void WhiteKing_HasCastlingMoves()
    {
        King whiteKing = new King(board.GetTile("e1"), Color.WHITE);
        Rook whiteQueenSideRook = new Rook(board.GetTile("a1"), Color.WHITE);
        Rook whiteKingSideRook = new Rook(board.GetTile("h1"), Color.WHITE);

        board.AddPiece(whiteKing);
        board.AddPiece(whiteQueenSideRook);
        board.AddPiece(whiteKingSideRook);

        Assert.That(whiteKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d1"),
            board.GetTile("d2"),
            board.GetTile("e2"),
            board.GetTile("f2"),
            board.GetTile("f1"),
            board.GetTile("c1"),
            board.GetTile("g1"),
        }));
    }

    [Test]
    public void WhiteKing_DoesNotHaveCastlingMoves_IfItHasMoved()
    {
        King whiteKing = new King(board.GetTile("e1"), Color.WHITE);
        Rook whiteQueenSideRook = new Rook(board.GetTile("a1"), Color.WHITE);
        Rook whiteKingSideRook = new Rook(board.GetTile("h1"), Color.WHITE);

        board.AddPiece(whiteKing);
        board.AddPiece(whiteQueenSideRook);
        board.AddPiece(whiteKingSideRook);

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
        Rook whiteQueenSideRook = new Rook(board.GetTile("a1"), Color.WHITE);
        Rook whiteKingSideRook = new Rook(board.GetTile("h1"), Color.WHITE);

        Queen blackQueen = new Queen(board.GetTile("e8"), Color.BLACK);

        board.AddPiece(whiteKing);
        board.AddPiece(whiteQueenSideRook);
        board.AddPiece(whiteKingSideRook);
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
        Rook whiteQueenSideRook = new Rook(board.GetTile("a1"), Color.WHITE);
        Rook whiteKingSideRook = new Rook(board.GetTile("h1"), Color.WHITE);

        board.AddPiece(whiteKing);
        board.AddPiece(whiteQueenSideRook);
        board.AddPiece(whiteKingSideRook);

        whiteQueenSideRook.Move("a2");
        whiteQueenSideRook.Move("a1");
        whiteKingSideRook.Move("h2");
        whiteKingSideRook.Move("h1");

        Assert.That(whiteKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d1"),
            board.GetTile("d2"),
            board.GetTile("e2"),
            board.GetTile("f2"),
            board.GetTile("f1"),
        }));
    }

    [Test]
    public void WhiteKing_DoesNotHaveCastlingMoves_IfPassingTilesAreNotEmpty()
    {
        board.SetUp();

        Assert.IsEmpty(board.whiteKing.legalMoves);
    }

    [Test]
    public void WhiteKing_DoesNotHaveCastlingMoves_IfPassingTilesAreUnderAttack()
    {
        King whiteKing = new King(board.GetTile("e1"), Color.WHITE);
        Rook whiteRook = new Rook(board.GetTile("h1"), Color.WHITE);

        Queen blackQueen = new Queen(board.GetTile("b1"), Color.BLACK);
        Bishop blackBishop1 = new Bishop(board.GetTile("h3"), Color.BLACK);
        Bishop blackBishop2 = new Bishop(board.GetTile("h2"), Color.BLACK);
        Rook blackRook1 = new Rook(board.GetTile("c8"), Color.BLACK);
        Rook blackRook2 = new Rook(board.GetTile("d8"), Color.BLACK);

        board.AddPiece(whiteKing);
        board.AddPiece(whiteRook);
        board.AddPiece(blackQueen);
        board.AddPiece(blackBishop1);
        board.AddPiece(blackBishop2);
        board.AddPiece(blackRook1);
        board.AddPiece(blackRook2);

        Assert.That(whiteKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("e2"),
            board.GetTile("f2")
        }));
    }
}