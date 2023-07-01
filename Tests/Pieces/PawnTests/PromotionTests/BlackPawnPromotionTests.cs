using Chess.Core;
using Chess.Core.Exceptions;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.PawnTests.PromotionTests;

[TestFixture]
internal class BlackPawnPromotionTests : BoardTestFixtureSetUp
{
    private Pawn pawn;

    [Test]
    public void BlackPawn_Throws_CannotBePromotedException()
    {
        pawn = new Pawn(board.GetTile("a2"), Color.BLACK);

        board.AddPiece(pawn);

        Assert.Throws<CannotPromotePawnException>(
            () => pawn.Promote(typeof(Queen))
        );

        pawn.Move("a1");

        Assert.Throws<CannotPromotePawnException>(
            () => pawn.Promote(typeof(Pawn))
        );
        Assert.Throws<CannotPromotePawnException>(
            () => pawn.Promote(typeof(King))
        );
    }

    [Test]
    public void BlackPawn_SuccessfullyPromoted_ToQueen()
    {
        AddPromotablePawn();

        pawn.Promote(typeof(Queen));

        AssertPawnPromotionIsSuccessful<Queen>();
    }

    [Test]
    public void BlackPawn_SuccessfullyPromoted_ToBishop()
    {
        AddPromotablePawn();

        pawn.Promote(typeof(Bishop));

        AssertPawnPromotionIsSuccessful<Bishop>();
    }

    [Test]
    public void BlackPawn_SuccessfullyPromoted_ToKnight()
    {
        AddPromotablePawn();

        pawn.Promote(typeof(Knight));

        AssertPawnPromotionIsSuccessful<Knight>();
    }

    [Test]
    public void BlackPawn_SuccessfullyPromoted_ToRook()
    {
        AddPromotablePawn();

        pawn.Promote(typeof(Rook));

        AssertPawnPromotionIsSuccessful<Rook>();
    }

    private void AddPromotablePawn()
    {
        pawn = new Pawn(board.GetTile("a1"), Color.BLACK);
        board.AddPiece(pawn);
    }

    private void AssertPawnPromotionIsSuccessful<T>()
    {
        Assert.IsFalse(board.whitePieces.Contains(pawn));
        Assert.IsFalse(board.GetTile("a1").isEmpty);
        Assert.IsInstanceOf<T>(board.GetTile("a1").piece);
        Assert.AreEqual(1, board.blackPieces.Count);
    }
}