using Chess.Core;
using Chess.Core.Exceptions;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.PawnTests;

[TestFixture]
internal class PromotionTests : BoardTestFixtureSetUp
{
    private Pawn pawn;

    [Test]
    public void WhitePawn_Throws_CannotBePromotedException()
    {
        AddWhitePawn();

        AssertPawnThrowsExceptionOnPromotion();
    }

    [Test]
    public void WhitePawn_SuccessfullyPromoted_ToQueen()
    {
        AddWhitePawn();

        pawn.Move("a8");
        pawn.Promote(typeof(Queen));

        AssertWhitePawnPromotionIsSuccessful<Queen>();
    }

    [Test]
    public void WhitePawn_SuccessfullyPromoted_ToBishop()
    {
        AddWhitePawn();

        pawn.Move("a8");
        pawn.Promote(typeof(Bishop));

        AssertWhitePawnPromotionIsSuccessful<Bishop>();
    }

    [Test]
    public void WhitePawn_SuccessfullyPromoted_ToKnight()
    {
        AddWhitePawn();

        pawn.Move("a8");
        pawn.Promote(typeof(Knight));

        AssertWhitePawnPromotionIsSuccessful<Knight>();
    }

    [Test]
    public void WhitePawn_SuccessfullyPromoted_ToRook()
    {
        AddWhitePawn();

        pawn.Move("a8");
        pawn.Promote(typeof(Rook));

        AssertWhitePawnPromotionIsSuccessful<Rook>();
    }

    [Test]
    public void BlackPawn_Throws_CannotBePromotedException()
    {
        AddBlackPawn();

        AssertPawnThrowsExceptionOnPromotion();
    }

    [Test]
    public void BlackPawn_SuccessfullyPromoted_ToQueen()
    {
        AddBlackPawn();

        pawn.Move("a1");
        pawn.Promote(typeof(Queen));

        AssertBlackPawnPromotionIsSuccessful<Queen>();
    }

    [Test]
    public void BlackPawn_SuccessfullyPromoted_ToBishop()
    {
        AddBlackPawn();

        pawn.Move("a1");
        pawn.Promote(typeof(Bishop));

        AssertBlackPawnPromotionIsSuccessful<Bishop>();
    }

    [Test]
    public void BlackPawn_SuccessfullyPromoted_ToKnight()
    {
        AddBlackPawn();

        pawn.Move("a1");
        pawn.Promote(typeof(Knight));

        AssertBlackPawnPromotionIsSuccessful<Knight>();
    }

    [Test]
    public void BlackPawn_SuccessfullyPromoted_ToRook()
    {
        AddBlackPawn();

        pawn.Move("a1");
        pawn.Promote(typeof(Rook));

        AssertBlackPawnPromotionIsSuccessful<Rook>();
    }

    private void AssertPawnThrowsExceptionOnPromotion()
    {
        Assert.Throws<CannotPromotePawnException>(
            () => pawn.Promote(typeof(Queen))
        );
        Assert.Throws<CannotPromotePawnException>(
            () => pawn.Promote(typeof(Pawn))
        );
        Assert.Throws<CannotPromotePawnException>(
            () => pawn.Promote(typeof(King))
        );
    }

    private void AddWhitePawn()
    {
        pawn = new Pawn(board.GetTile("a7"), Color.WHITE);
        board.AddPiece(pawn);
    }

    private void AssertWhitePawnPromotionIsSuccessful<T>()
    {
        Assert.IsFalse(board.whitePieces.Contains(pawn));
        Assert.IsFalse(board.GetTile("a8").isEmpty);
        Assert.IsInstanceOf<T>(board.GetTile("a8").piece);
        Assert.AreEqual(1, board.whitePieces.Count);
    }

    private void AddBlackPawn()
    {
        pawn = new Pawn(board.GetTile("a2"), Color.BLACK);
        board.AddPiece(pawn);
    }

    private void AssertBlackPawnPromotionIsSuccessful<T>()
    {
        Assert.IsFalse(board.whitePieces.Contains(pawn));
        Assert.IsFalse(board.GetTile("a1").isEmpty);
        Assert.IsInstanceOf<T>(board.GetTile("a1").piece);
        Assert.AreEqual(1, board.blackPieces.Count);
    }
}