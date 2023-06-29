using Chess.Core;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests.CastlingTests;

[TestFixture]
internal class WhiteKingCastlingTests : BoardTestFixtureSetUp
{
    private King king;
    private Rook queenSideRook;
    private Rook kingSideRook;

    private Tile[] defaultLegalMoves => new Tile[]
    {
        board.GetTile("d1"),
        board.GetTile("d2"),
        board.GetTile("e2"),
        board.GetTile("f2"),
        board.GetTile("f1")
    };

    [Test]
    public void WhiteKing_DoesNotHaveCaslingMoves_OnEmptyBoard()
    {
        board.AddPiece(new King(board.GetTile("e1"), Color.WHITE));

        Assert.That(board.whiteKing.legalMoves,
            Is.EquivalentTo(defaultLegalMoves)
        );
    }

    [Test]
    public void WhiteKing_HaveCastlingMoves()
    {
        AddKingAndRooks();

        Assert.That(king.legalMoves, Is.EquivalentTo(
            defaultLegalMoves
            .Union(new Tile[] {
                board.GetTile("c1"),
                board.GetTile("g1"),
            }))
        );
    }

    [Test]
    public void WhiteKing_DoesNotHaveCastlingMoves_IfItHasMoved()
    {
        AddKingAndRooks();

        king.Move("e2");
        king.Move("e1");

        Assert.That(king.legalMoves, Is.EquivalentTo(defaultLegalMoves));
    }

    [Test]
    public void WhiteKing_DoesNotHaveCastlingMoves_IfItIsInCheck()
    {
        AddKingAndRooks();

        board.AddPiece(new Queen(board.GetTile("e8"), Color.BLACK));

        Assert.That(king.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d1"),
            board.GetTile("d2"),
            board.GetTile("f2"),
            board.GetTile("f1"),
        }));
    }

    [Test]
    public void WhiteKing_DoesNotHaveCastlingMove_IfRookHasMoved()
    {
        AddKingAndRooks();

        queenSideRook.Move("a2");
        queenSideRook.Move("a1");
        kingSideRook.Move("h2");
        kingSideRook.Move("h1");

        Assert.That(king.legalMoves, Is.EquivalentTo(defaultLegalMoves));
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
        AddKingAndRooks();

        board.AddPiece(new Queen(board.GetTile("b1"), Color.BLACK));
        board.AddPiece(new Bishop(board.GetTile("h3"), Color.BLACK));
        board.AddPiece(new Bishop(board.GetTile("h2"), Color.BLACK));
        board.AddPiece(new Rook(board.GetTile("c8"), Color.BLACK));
        board.AddPiece(new Rook(board.GetTile("d8"), Color.BLACK));

        Assert.That(king.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("e2"),
            board.GetTile("f2")
        }));
    }

    [Test]
    public void Rook_ChangedPosition_OnSuccessfulCastling()
    {
        AddKingAndRooks();

        king.Move("g1");

        Assert.AreEqual(board.GetTile("g1"), king.tile);
        Assert.AreEqual(board.GetTile("f1"), kingSideRook.tile);
    }

    private void AddKingAndRooks()
    {
        king = new King(board.GetTile("e1"), Color.WHITE);
        queenSideRook = new Rook(board.GetTile("a1"), Color.WHITE);
        kingSideRook = new Rook(board.GetTile("h1"), Color.WHITE);

        board.AddPiece(king);
        board.AddPiece(queenSideRook);
        board.AddPiece(kingSideRook);
    }
}