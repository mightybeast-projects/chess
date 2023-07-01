using Chess.Core;
using Chess.Core.Exceptions;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.PawnTests;

[TestFixture]
internal class BlackPawnTests : PieceTest<Pawn>
{
    protected override Color pieceColor => Color.BLACK;

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
    public void BlackPawn_HasOneLegalMove_AfterOneMove()
    {
        Pawn pawn = new Pawn(board.GetTile("d7"), pieceColor);

        board.AddPiece(pawn);

        pawn.Move("d6");

        AssertPieceLegalMoves(pawn, new[] { "d5" });
    }

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

    private static TestCaseData[] legalMovesGeneralCases =
    {
        new TestCaseData("d7", new[] { "d6", "d5" }),
        new TestCaseData("d1", new string[] { })
    };

    private static TestCaseData[] legalMovesEdgeCases =
    {
        new TestCaseData(
            "d7", new string[] { },
            Color.WHITE, new[] { "d6" }
        ),
        new TestCaseData(
            "d7", new[] { "d6" },
            Color.WHITE, new[] { "d5" }
        ),
        new TestCaseData(
            "a5", new[] { "b4" },
            Color.WHITE, new[] { "a4", "b4" }
        ),
        new TestCaseData(
            "h5", new[] { "g4" },
            Color.WHITE, new[] { "h4", "g4" }
        ),
        new TestCaseData(
            "d5", new[] { "c4", "e4" },
            Color.WHITE, new[] { "c4", "d4", "e4" }
        )
    };

    private static TestCaseData[] tilesUnderAttackCases =
    {
        new TestCaseData("a5", new[] { "b4" }),
        new TestCaseData("h5", new[] { "g4" }),
        new TestCaseData("d5", new[] { "c4", "e4" })
    };
}