using Chess.Core;
using Chess.Core.Exceptions;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.PawnTests;

[TestFixture]
internal class PromotionTests : BoardTestFixtureSetUp
{
    [Test]
    public void WhitePawn_Throws_CannotBePromotedException()
    {
        Pawn pawn = new Pawn(board.GetTile("a2"), Color.WHITE);

        board.AddPiece(pawn);

        AssertPawnThrowsExceptionOnPromotion(pawn);
    }

    [Test]
    public void WhitePawn_SuccessfullyPromoted()
    {
        Pawn pawn = new Pawn(board.GetTile("a7"), Color.WHITE);

        board.AddPiece(pawn);

        pawn.Move("a8");

        pawn.Promote(typeof(Queen));

        Assert.IsFalse(board.whitePieces.Contains(pawn));
        Assert.IsFalse(board.GetTile("a8").isEmpty);
        Assert.IsInstanceOf<Queen>(board.GetTile("a8").piece);
        Assert.AreEqual(1, board.whitePieces.Count);
    }

    [Test]
    public void BlackPawn_Throws_CannotBePromotedException()
    {
        Pawn pawn = new Pawn(board.GetTile("a7"), Color.BLACK);

        board.AddPiece(pawn);

        AssertPawnThrowsExceptionOnPromotion(pawn);
    }

    [Test]
    public void BlackPawn_SuccessfullyPromoted()
    {
        Pawn pawn = new Pawn(board.GetTile("a2"), Color.BLACK);

        board.AddPiece(pawn);

        pawn.Move("a1");

        pawn.Promote(typeof(Queen));

        Assert.IsFalse(board.whitePieces.Contains(pawn));
        Assert.IsFalse(board.GetTile("a1").isEmpty);
        Assert.IsInstanceOf<Queen>(board.GetTile("a1").piece);
        Assert.AreEqual(1, board.blackPieces.Count);
    }

    private void AssertPawnThrowsExceptionOnPromotion(Pawn pawn)
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
}