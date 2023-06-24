using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.PawnTests;

[TestFixture]
internal class WhitePawnTests : PieceTest<Pawn>
{
    protected override Color pieceColor => Color.WHITE;

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
    public void WhitePawnHasOneLegalMove_AfterOneMove()
    {
        Pawn pawn = (Pawn)CreatePiece(typeof(Pawn), "d2", pieceColor);

        pawn.Move("d3");

        Assert.IsTrue(pawn.hasMoved);
        AssertPieceLegalMoves(pawn, new[] { "d4" });
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
        new TestCaseData("d4", new[] { "c5", "e5", })
    };
}