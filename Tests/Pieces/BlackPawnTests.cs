using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
internal class BlackPawnTests : PieceTest<Pawn>
{
    protected override Color pieceColor => Color.BLACK;

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
        new TestCaseData("d5", new[] { "d4" }),
        new TestCaseData("d7", new[] { "d6", "d5" }),
        new TestCaseData("d1", new string[] { })
    };

    private static TestCaseData[] edgeCases =
    {
        new TestCaseData(
            Color.WHITE, new[] { "d6" },
            "d7", new string[] { }
        ),
        new TestCaseData(
            Color.WHITE, new[] { "d5" },
            "d7", new[] { "d6" }
        ),
        new TestCaseData(
            Color.WHITE, new[] { "a4", "b4" },
            "a5", new[] { "b4" }
        ),
        new TestCaseData(
            Color.WHITE, new[] { "h4", "g4" },
            "h5", new[] { "g4" }
        ),
        new TestCaseData(
            Color.WHITE, new[] { "c4", "d4", "e4" },
            "d5", new[] { "c4", "e4" }
        )
    };
}