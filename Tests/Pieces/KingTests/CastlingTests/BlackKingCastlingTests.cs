using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests.CastlingTests;

[TestFixture]
internal class BlackKingCastlingTests
{
    private Board board;

    [SetUp]
    public void SetUp() => board = new Board();

    [Test]
    public void BlackKing_DoesNotHaveAnyCaslingMoves_OnEmptyBoard()
    {
        King blackKing = new King(board.GetTile("e8"), Color.BLACK);

        board.AddPiece(blackKing);

        Assert.That(blackKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d8"),
            board.GetTile("d7"),
            board.GetTile("e7"),
            board.GetTile("f7"),
            board.GetTile("f8")
        }));
    }

    [Test]
    public void BlackKing_HaveCastlingMoves()
    {
        King blackKing = new King(board.GetTile("e8"), Color.BLACK);
        Rook blackQueenSideRook = new Rook(board.GetTile("a8"), Color.BLACK);
        Rook blackKingSideRook = new Rook(board.GetTile("h8"), Color.BLACK);

        board.AddPiece(blackKing);
        board.AddPiece(blackQueenSideRook);
        board.AddPiece(blackKingSideRook);

        Assert.That(blackKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d8"),
            board.GetTile("d7"),
            board.GetTile("e7"),
            board.GetTile("f7"),
            board.GetTile("f8"),
            board.GetTile("c8"),
            board.GetTile("g8"),
        }));
    }

    [Test]
    public void BlackKing_DoesNotHaveCastlingMoves_IfItHasMoved()
    {
        King blackKing = new King(board.GetTile("e8"), Color.BLACK);
        Rook blackQueenSideRook = new Rook(board.GetTile("a8"), Color.BLACK);
        Rook blackKingSideRook = new Rook(board.GetTile("h8"), Color.BLACK);

        board.AddPiece(blackKing);
        board.AddPiece(blackQueenSideRook);
        board.AddPiece(blackKingSideRook);

        blackKing.Move("e7");
        blackKing.Move("e8");

        Assert.That(blackKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d8"),
            board.GetTile("d7"),
            board.GetTile("e7"),
            board.GetTile("f7"),
            board.GetTile("f8")
        }));
    }

    [Test]
    public void BlackKing_DoesNotHaveCastlingMoves_IfItIsInCheck()
    {
        King blackKing = new King(board.GetTile("e8"), Color.BLACK);
        Rook blackQueenSideRook = new Rook(board.GetTile("a8"), Color.BLACK);
        Rook blackKingSideRook = new Rook(board.GetTile("h8"), Color.BLACK);

        Queen whiteQueen = new Queen(board.GetTile("e1"), Color.WHITE);

        board.AddPiece(blackKing);
        board.AddPiece(blackQueenSideRook);
        board.AddPiece(blackKingSideRook);
        board.AddPiece(whiteQueen);

        Assert.That(blackKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d8"),
            board.GetTile("d7"),
            board.GetTile("f7"),
            board.GetTile("f8")
        }));
    }


    [Test]
    public void BlackKing_DoesNotHaveCastlingMove_IfRookHasMoved()
    {
        King blackKing = new King(board.GetTile("e8"), Color.BLACK);
        Rook blackQueenSideRook = new Rook(board.GetTile("a8"), Color.BLACK);
        Rook blackKingSideRook = new Rook(board.GetTile("h8"), Color.BLACK);

        board.AddPiece(blackKing);
        board.AddPiece(blackQueenSideRook);
        board.AddPiece(blackKingSideRook);

        blackQueenSideRook.Move("a7");
        blackQueenSideRook.Move("a8");
        blackKingSideRook.Move("h7");
        blackKingSideRook.Move("h8");

        Assert.That(blackKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d8"),
            board.GetTile("d7"),
            board.GetTile("e7"),
            board.GetTile("f7"),
            board.GetTile("f8")
        }));
    }

    [Test]
    public void BlackKing_DoesNotHaveCastlingMoves_IfPassingTilesAreNotEmpty()
    {
        board.SetUp();

        Assert.IsEmpty(board.blackKing.legalMoves);
    }

    [Test]
    public void BlackKing_DoesNotHaveCastlingMoves_IfPassingTilesAreUnderAttack()
    {
        King blackKing = new King(board.GetTile("e8"), Color.BLACK);
        Rook blackQueenSideRook = new Rook(board.GetTile("a8"), Color.BLACK);
        Rook blackKingSideRook = new Rook(board.GetTile("h8"), Color.BLACK);

        Queen whiteQueen = new Queen(board.GetTile("b8"), Color.WHITE);
        Bishop whiteBishop1 = new Bishop(board.GetTile("h7"), Color.WHITE);
        Bishop whiteBishop2 = new Bishop(board.GetTile("h6"), Color.WHITE);
        Rook whiteRook1 = new Rook(board.GetTile("c1"), Color.WHITE);
        Rook whiteRook2 = new Rook(board.GetTile("d1"), Color.WHITE);

        board.AddPiece(blackKing);
        board.AddPiece(blackQueenSideRook);
        board.AddPiece(blackKingSideRook);
        board.AddPiece(whiteQueen);
        board.AddPiece(whiteBishop1);
        board.AddPiece(whiteBishop2);
        board.AddPiece(whiteRook1);
        board.AddPiece(whiteRook2);

        Assert.That(blackKing.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("e7"),
            board.GetTile("f7")
        }));
    }
}