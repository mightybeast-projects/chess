using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
internal class BishopTests : SlidingPieceTest<Bishop>
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
    public override void SlidingPieceHasCorrectTilesUnderAttack(
        string piecePosition,
        string[] tilesUnderAttack,
        string[] blockerPawnsPos) =>
            base.SlidingPieceHasCorrectTilesUnderAttack(
                piecePosition, tilesUnderAttack, blockerPawnsPos);

    public static TestCaseData[] legalMovesGeneralCases =
    {
        new TestCaseData(
            "a1", new[] { "b2", "c3", "d4", "e5", "f6", "g7", "h8" }
        ),
        new TestCaseData(
            "a8", new[] { "h1", "g2", "f3", "e4", "d5", "c6", "b7" }
        ),
        new TestCaseData(
            "h1", new[] { "g2", "f3", "e4", "d5", "c6", "b7", "a8" }
        ),
        new TestCaseData(
            "h8", new[] { "a1", "b2", "c3", "d4", "e5", "f6", "g7" }
        ),
        new TestCaseData(
            "d4", new[] {
                "e5", "f6", "g7", "h8",
                "e3", "f2", "g1",
                "c3", "b2", "a1",
                "c5", "b6", "a7"
            }
        ),
    };

    private static TestCaseData[] legalMovesEdgeCases =
    {
        new TestCaseData(
            "d4", new string[] { },
            Color.WHITE, new[] { "e5", "c3", "c5", "e3" }
        ),
        new TestCaseData(
            "d4", new[] { "c5", "e5", "e3", "c3", "b6", "f6", "f2", "b2" },
            Color.BLACK, new[] { "b2", "b6", "f2", "f6" }
        )
    };

    private static TestCaseData[] tilesUnderAttackCases =
    {
        new TestCaseData(
            "d4", new[] { "c5", "e5", "e3", "c3", "b6", "f6", "f2", "b2" },
            new[] { "b2", "b6", "f2", "f6" }
        )
    };
}