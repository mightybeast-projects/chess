using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests;

[TestFixture]
internal class GeneralKingTests : PieceTest<King>
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
        new TestCaseData("a1", new[] { "a2", "b2", "b1" }),
        new TestCaseData("a8", new[] { "a7", "b8", "b7" }),
        new TestCaseData("h1", new[] { "h2", "g2", "g1" }),
        new TestCaseData("h8", new[] { "h7", "g8", "g7" }),
        new TestCaseData(
            "d4", new[] {
                "c5", "c4", "c3",
                "d5", "d3",
                "e5", "e4", "e3"
        })
    };

    private static TestCaseData[] edgeCases =
    {
        new TestCaseData(
            Color.WHITE, new[] {
                "c4", "e4", "d5", "d3", "c5", "e5", "c3", "e3"
            },
            "d4", new string[] { }
        ),
        new TestCaseData(
            Color.BLACK, new[] {
                "c4", "e4", "d5", "d3", "c5", "e5", "c3", "e3"
            },
            "d4", new string[] {
                "c5", "d5", "e5", "c3", "e3"
        })
    };
}