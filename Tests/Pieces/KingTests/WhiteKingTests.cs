using Chess.Core;
using Chess.Core.Pieces;
using Chess.Tests.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests;

[TestFixture]
internal class WhiteKingTests : PieceTest<King>
{
    protected override Color pieceColor => Color.WHITE;

    [TestCaseSource(nameof(edgeCases))]
    public override void PieceHasCorrectLegalMoves_InEdgeCases(
        Color blockerPawnsColor,
        string[] blockerPawnsPos,
        string piecePos,
        string[] legalMoves) =>
            base.PieceHasCorrectLegalMoves_InEdgeCases(
                blockerPawnsColor, blockerPawnsPos, piecePos, legalMoves);

    private static TestCaseData[] edgeCases =
    {
        new TestCaseData(
            Color.BLACK, new [] {
                "b3", "c3", "c2"
            },
            "a1", new string[] { }
        )
    };
}