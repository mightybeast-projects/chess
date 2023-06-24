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
        new TestCaseData("d1", d1LegalMoves),
        new TestCaseData("d8", d8LegalMoves),
        new TestCaseData("d4", d4LegalMoves),
    };

    private static TestCaseData[] legalMovesEdgeCases =
    {
        new TestCaseData(
            "d4", new string[] { },
            Color.WHITE, new[] { "e5", "c3", "c5", "e3" }
        ),
        new TestCaseData(
            "d4", d4BlockedTilesUnderAttack,
            Color.BLACK, d4BlockerPawnsPositions
        )
    };

    private static TestCaseData[] tilesUnderAttackCases =
    {
        new TestCaseData("d1", d1LegalMoves, null),
        new TestCaseData("d8", d8LegalMoves, null),
        new TestCaseData("d4", d4LegalMoves, null),
        new TestCaseData(
            "d4", d4BlockedTilesUnderAttack, d4BlockerPawnsPositions
        )
    };

    private static string[] d1LegalMoves =>
        new[] { "c2", "b3", "a4", "e2", "f3", "g4", "h5" };

    private static string[] d8LegalMoves =>
        new[] { "c7", "b6", "a5", "e7", "f6", "g5", "h4" };

    private static string[] d4LegalMoves => new[]
    {
        "e5", "f6", "g7", "h8",
        "e3", "f2", "g1",
        "c3", "b2", "a1",
        "c5", "b6", "a7"
    };

    private static string[] d4BlockedTilesUnderAttack =>
        new[] { "c5", "e5", "e3", "c3", "b6", "f6", "f2", "b2" };

    private static string[] d4BlockerPawnsPositions =>
        new[] { "b2", "b6", "f2", "f6" };
}