using Chess.Core;
using Chess.Core.Exceptions;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.PawnTests;

[TestFixture]
internal class WhitePawnTests : PieceTest<Pawn>
{
    protected override Color pieceColor => Color.WHITE;

    private Pawn pawn;

    [TestCaseSource(nameof(legalMovesGeneralCases))]
    public override void PieceHasCorrectLegalMoves_InGeneralCases(
        string piecePosition,
        string[] legalMoves) =>
            base.PieceHasCorrectLegalMoves_InGeneralCases(
                piecePosition, legalMoves);

    [TestCaseSource(nameof(legalMovesEdgeCases))]
    public override void PieceHasCorrectLegalMoves_InEdgeCases(
        string piecePos,
        string[] legalMoves,
        Color blockerPawnsColor,
        string[] blockerPawnsPos) =>
            base.PieceHasCorrectLegalMoves_InEdgeCases(
                piecePos, legalMoves, blockerPawnsColor, blockerPawnsPos);

    [TestCaseSource(nameof(tilesUnderAttackCases))]
    public override void PieceHasCorrectTilesUnderAttack(
        string piecePosition,
        string[] tilesUnderAttack) =>
            base.PieceHasCorrectTilesUnderAttack(piecePosition, tilesUnderAttack);

    [Test]
    public void WhitePawn_HasOneLegalMove_AfterOneMove()
    {
        Pawn pawn = new Pawn(board.GetTile("d2"), pieceColor);

        board.AddPiece(pawn);

        pawn.Move("d3");

        AssertPieceLegalMoves(pawn, new[] { "d4" });
    }

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

    private static TestCaseData[] legalMovesGeneralCases =
    {
        new TestCaseData("d2", new[] { "d3", "d4" }),
        new TestCaseData("d8", new string[] { })
    };

    private static TestCaseData[] legalMovesEdgeCases =
    {
        new TestCaseData(
            "d2", new string[] { },
            Color.BLACK, new[] { "d3" }
        ),
        new TestCaseData(
            "d2", new string[] { "d3" },
            Color.BLACK, new[] { "d4" }
        ),
        new TestCaseData(
            "a4", new string[] { "b5" },
            Color.BLACK, new[] { "a5", "b5" }
        ),
        new TestCaseData(
            "h4", new string[] { "g5" },
            Color.BLACK, new[] { "h5", "g5" }
        ),
        new TestCaseData(
            "d4", new string[] { "c5", "e5" },
            Color.BLACK, new[] { "c5", "d5", "e5" }
        )
    };

    private static TestCaseData[] tilesUnderAttackCases =
    {
        new TestCaseData("a4", new string[] { "b5" }),
        new TestCaseData("h4", new string[] { "g5" }),
        new TestCaseData("d4", new[] { "c5", "e5" })
    };
}