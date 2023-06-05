using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
internal class KnightTests : PieceTest<Knight>
{
    protected override Color pieceColor => Color.WHITE;

    [TestCaseSource(nameof(generalCases))]
    public override void PieceHasCorrectLegalMoves_InGeneralCases(
        string piecePosition,
        string[] legalMoves) =>
            base.PieceHasCorrectLegalMoves_InGeneralCases(
                piecePosition, legalMoves);

    [TestCaseSource(nameof(edgeCases))]
    public override void PieceHasCorrectLegalMoves_InEdgeCases(
        Color blockerPawnsColor,
        string[] blockerPawnsPos,
        string piecePos,
        string[] legalMoves) =>
            base.PieceHasCorrectLegalMoves_InEdgeCases(
                blockerPawnsColor, blockerPawnsPos, piecePos, legalMoves);

    private static TestCaseData[] generalCases =
    {
        new TestCaseData("a1", new[] { "b3", "c2" }),
        new TestCaseData("h1", new[] { "g3", "f2" }),
        new TestCaseData("a8", new[] { "b6", "c7" }),
        new TestCaseData("h8", new[] { "g6", "f7" }),
        new TestCaseData("d4", new[] {
            "c6", "e6",
            "f5", "f3",
            "c2", "e2",
            "b3", "b5"
        }),
    };

    private static TestCaseData[] edgeCases =
    {
        new TestCaseData(
            Color.WHITE, new[] {
                "c6", "e6",
                "f5", "f3",
                "c2", "e2",
                "b3", "b5"
            },
            "d4", new string[] { }
        ),
        new TestCaseData(
            Color.BLACK, new[] {
                "c6", "e6",
                "f5", "f3",
                "c2", "e2",
                "b3", "b5"
            },
            "d4", new[] {
                "c6", "e6",
                "f5", "f3",
                "c2", "e2",
                "b3", "b5"
        }),
    };
}