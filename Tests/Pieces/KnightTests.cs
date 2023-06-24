using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
internal class KnightTests : PieceTest<Knight>
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

    private static TestCaseData[] legalMovesGeneralCases =
    {
        new TestCaseData("a1", new[] { "b3", "c2" }),
        new TestCaseData("h1", new[] { "g3", "f2" }),
        new TestCaseData("a8", new[] { "b6", "c7" }),
        new TestCaseData("h8", new[] { "g6", "f7" }),
        new TestCaseData(
            "d4", new[] { "c6", "e6", "f5", "f3", "c2", "e2", "b3", "b5" }
        ),
    };

    private static TestCaseData[] legalMovesEdgeCases =
    {
        new TestCaseData(
            "d4", new string[] { },
            Color.WHITE, new[] { "c6", "e6", "f5", "f3", "c2", "e2", "b3", "b5" }
        ),
        new TestCaseData(
            "d4", new[] { "c6", "e6", "f5", "f3", "c2", "e2", "b3", "b5" },
            Color.BLACK, new[] { "c6", "e6", "f5", "f3", "c2", "e2", "b3", "b5" }
        ),
    };

    private static TestCaseData[] tilesUnderAttackCases =
    {
        new TestCaseData(
            "d4", new[] { "c6", "e6", "f5", "f3", "c2", "e2", "b3", "b5" }
        )
    };
}