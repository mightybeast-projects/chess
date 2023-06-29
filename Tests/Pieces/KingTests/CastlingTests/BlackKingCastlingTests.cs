using Chess.Core;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests.CastlingTests;

[TestFixture]
internal class BlackKingCastlingTests : BoardTestFixtureSetUp
{
    private King king;
    private Rook queenSideRook;
    private Rook kingSideRook;

    private Tile[] defaultLegalMoves => new Tile[]
    {
        board.GetTile("d8"),
        board.GetTile("d7"),
        board.GetTile("e7"),
        board.GetTile("f7"),
        board.GetTile("f8")
    };

    [Test]
    public void BlackKing_DoesNotHaveCaslingMoves_OnEmptyBoard()
    {
        board.AddPiece(new King(board.GetTile("e8"), Color.BLACK));

        Assert.That(board.blackKing.legalMoves,
            Is.EquivalentTo(defaultLegalMoves)
        );
    }

    [Test]
    public void BlackKing_HaveCastlingMoves()
    {
        AddKingAndRooks();

        Assert.That(king.legalMoves, Is.EquivalentTo(
            defaultLegalMoves
            .Union(new Tile[] {
                board.GetTile("c8"),
                board.GetTile("g8"),
            }))
        );
    }

    [Test]
    public void BlackKing_DoesNotHaveCastlingMoves_IfItHasMoved()
    {
        AddKingAndRooks();

        king.Move("e7");
        king.Move("e8");

        Assert.That(king.legalMoves, Is.EquivalentTo(defaultLegalMoves));
    }

    [Test]
    public void BlackKing_DoesNotHaveCastlingMoves_IfItIsInCheck()
    {
        AddKingAndRooks();

        board.AddPiece(new Queen(board.GetTile("e1"), Color.WHITE));

        Assert.That(king.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("d8"),
            board.GetTile("d7"),
            board.GetTile("f7"),
            board.GetTile("f8")
        }));
    }

    [Test]
    public void BlackKing_DoesNotHaveCastlingMove_IfRookHasMoved()
    {
        AddKingAndRooks();

        queenSideRook.Move("a7");
        queenSideRook.Move("a8");
        kingSideRook.Move("h7");
        kingSideRook.Move("h8");

        Assert.That(king.legalMoves, Is.EquivalentTo(defaultLegalMoves));
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
        AddKingAndRooks();

        board.AddPiece(new Queen(board.GetTile("b8"), Color.WHITE));
        board.AddPiece(new Bishop(board.GetTile("h7"), Color.WHITE));
        board.AddPiece(new Bishop(board.GetTile("h6"), Color.WHITE));
        board.AddPiece(new Rook(board.GetTile("c1"), Color.WHITE));
        board.AddPiece(new Rook(board.GetTile("d1"), Color.WHITE));

        Assert.That(king.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("e7"),
            board.GetTile("f7")
        }));
    }

    [Test]
    public void KingSideRook_ChangedPosition_OnSuccessfulCastlingMove()
    {
        AddKingAndRooks();

        king.Move("g8");

        Assert.AreEqual(board.GetTile("f8"), kingSideRook.tile);
    }

    [Test]
    public void QueenSideRook_ChangedPostion_OnSuccessfulCastlingMove()
    {
        AddKingAndRooks();

        king.Move("c8");

        Assert.AreEqual(board.GetTile("d8"), queenSideRook.tile);
    }

    [Test]
    public void KingSideRook_DidNotChangePosition_OnNonCastlingMove()
    {
        AddKingAndRooks();

        king.Move("f8");
        king.Move("g8");

        Assert.AreEqual(board.GetTile("h8"), kingSideRook.tile);
    }

    [Test]
    public void QueenSideRook_DidNotChangePosition_OnNonCastlingMove()
    {
        AddKingAndRooks();

        queenSideRook.Move("a7");
        queenSideRook.Move("a8");

        king.Move("d8");
        king.Move("c8");

        Assert.AreEqual(board.GetTile("a8"), queenSideRook.tile);
    }

    private void AddKingAndRooks()
    {
        king = new King(board.GetTile("e8"), Color.BLACK);
        queenSideRook = new Rook(board.GetTile("a8"), Color.BLACK);
        kingSideRook = new Rook(board.GetTile("h8"), Color.BLACK);

        board.AddPiece(king);
        board.AddPiece(queenSideRook);
        board.AddPiece(kingSideRook);
    }
}