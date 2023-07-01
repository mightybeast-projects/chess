using Chess.Core;
using Chess.Core.Exceptions;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.PawnTests.PromotionTests;

[TestFixture]
internal class WhitePawnPromotionTests : BoardTestFixtureSetUp
{
    private Pawn pawn;

    [Test]
    public void WhitePawn_Throws_CannotBePromotedException()
    {
        pawn = new Pawn(board.GetTile("a7"), Color.WHITE);

        board.AddPiece(pawn);

        Assert.Throws<CannotPromotePawnException>(
            () => pawn.Promote(typeof(Queen))
        );

        pawn.Move("a8");

        Assert.Throws<CannotPromotePawnException>(
            () => pawn.Promote(typeof(Pawn))
        );
        Assert.Throws<CannotPromotePawnException>(
            () => pawn.Promote(typeof(King))
        );
    }

    [Test]
    public void WhitePawn_SuccessfullyPromoted_ToQueen()
    {
        AddPromotablePawn();

        pawn.Promote(typeof(Queen));

        AssertPawnPromotionIsSuccessful<Queen>();
    }

    [Test]
    public void WhitePawn_SuccessfullyPromoted_ToBishop()
    {
        AddPromotablePawn();

        pawn.Promote(typeof(Bishop));

        AssertPawnPromotionIsSuccessful<Bishop>();
    }

    [Test]
    public void WhitePawn_SuccessfullyPromoted_ToKnight()
    {
        AddPromotablePawn();

        pawn.Promote(typeof(Knight));

        AssertPawnPromotionIsSuccessful<Knight>();
    }

    [Test]
    public void WhitePawn_SuccessfullyPromoted_ToRook()
    {
        AddPromotablePawn();

        pawn.Promote(typeof(Rook));

        AssertPawnPromotionIsSuccessful<Rook>();
    }

    private void AddPromotablePawn()
    {
        pawn = new Pawn(board.GetTile("a8"), Color.WHITE);
        board.AddPiece(pawn);
    }

    private void AssertPawnPromotionIsSuccessful<T>()
    {
        Assert.IsFalse(board.whitePieces.Contains(pawn));
        Assert.IsFalse(board.GetTile("a8").isEmpty);
        Assert.IsInstanceOf<T>(board.GetTile("a8").piece);
        Assert.AreEqual(1, board.whitePieces.Count);
    }
}