using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests;

[TestFixture]
internal class BlackKingTests : PieceTest<King>
{
    protected override Color pieceColor => Color.BLACK;

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
            Color.WHITE, new [] {
                "b6", "c6", "c7"
            },
            "a8", new string[] { }
        )
    };
}