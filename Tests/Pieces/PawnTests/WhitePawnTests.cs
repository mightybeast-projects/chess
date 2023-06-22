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
        Color blockerPawnsColor,
        string[] blockerPawnsPos,
        string piecePos,
        string[] legalMoves) =>
            base.PieceHasCorrectLegalMoves_InEdgeCases(
                blockerPawnsColor, blockerPawnsPos, piecePos, legalMoves);

    [TestCaseSource(nameof(tilesUnderAttackCases))]
    public override void PieceHasCorrectTilesUnderAttack(
        string piecePosition,
        string[] tilesUnderAttack) =>
            base.PieceHasCorrectTilesUnderAttack(piecePosition, tilesUnderAttack);

    private static TestCaseData[] legalMovesGeneralCases =
    {
        new TestCaseData("d4", new[] { "d5" }),
        new TestCaseData("d2", new[] { "d3", "d4" }),
        new TestCaseData("d8", new string[] { })
    };

    private static TestCaseData[] legalMovesEdgeCases =
    {
        new TestCaseData(
            Color.BLACK, new[] { "d3" },
            "d2", new string[] { }
        ),
        new TestCaseData(
            Color.BLACK, new[] { "d4" },
            "d2", new string[] { "d3" }
        ),
        new TestCaseData(
            Color.BLACK, new[] { "a5", "b5" },
            "a4", new string[] { "b5" }
        ),
        new TestCaseData(
            Color.BLACK, new[] { "h5", "g5" },
            "h4", new string[] { "g5" }
        ),
        new TestCaseData(
            Color.BLACK, new[] { "c5", "d5", "e5" },
            "d4", new string[] { "c5", "e5" }
        )
    };

    private static TestCaseData[] tilesUnderAttackCases =
    {
        new TestCaseData("d4", new[] { "c5", "e5", })
    };
}