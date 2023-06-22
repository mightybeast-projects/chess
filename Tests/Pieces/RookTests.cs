using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
internal class RookTests : PieceTest<Rook>
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

    [TestCaseSource(nameof(tilesUnderAttackCases))]
    public override void SlidingPieceHasCorrectTilesUnderAttack(
        string piecePosition,
        string[] tilesUnderAttack,
        string[] blockerPawnsPos) =>
            base.SlidingPieceHasCorrectTilesUnderAttack(
                piecePosition, tilesUnderAttack, blockerPawnsPos);

    private static TestCaseData[] generalCases =
    {
        new TestCaseData(
            "a1", new[] {
                "b1", "c1", "d1", "e1", "f1", "g1", "h1",
                "a2", "a3", "a4", "a5", "a6", "a7", "a8"
        }),
        new TestCaseData(
            "h8", new[] {
                "a8", "b8", "c8", "d8", "e8", "f8", "g8",
                "h1", "h2", "h3", "h4", "h5", "h6", "h7"
        }),
        new TestCaseData(
            "d4", new[] {
                "d5", "d6", "d7", "d8",
                "d3", "d2", "d1",
                "e4", "f4", "g4", "h4",
                "c4", "b4", "a4"
        })
    };

    private static TestCaseData[] edgeCases =
    {
        new TestCaseData(
            Color.WHITE, new[] { "d5", "d3", "e4","c4" },
            "d4", new string[] { }
        ),
        new TestCaseData(
            Color.BLACK, new[] { "d2", "d6", "b4", "f4" },
            "d4", new[] { "d5", "d6", "e4", "f4", "d3", "d2", "c4", "b4" }
        )
    };

    private static TestCaseData[] tilesUnderAttackCases =
    {
        new TestCaseData(
            "d4", new[] { "d5", "d6", "e4", "f4", "d3", "d2", "c4", "b4" },
            new[] { "d2", "d6", "b4", "f4" }
        )
    };
}