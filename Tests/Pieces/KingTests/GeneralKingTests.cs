using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests;

[TestFixture]
internal class GeneralKingTests : PieceTest<King>
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

    [Test]
    public void KingsDoesNotHaveAnyLoseConditions()
    {
        King whiteKing = (King)CreatePiece(typeof(King), "e1", Color.WHITE);
        King blackKing = (King)CreatePiece(typeof(King), "e8", Color.BLACK);

        Assert.IsFalse(whiteKing.isChecked);
        Assert.IsFalse(whiteKing.isCheckmated);
        Assert.IsFalse(whiteKing.isInStalemate);

        Assert.IsFalse(blackKing.isChecked);
        Assert.IsFalse(blackKing.isCheckmated);
        Assert.IsFalse(blackKing.isInStalemate);
    }

    private static TestCaseData[] legalMovesGeneralCases =
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

    private static TestCaseData[] legalMovesEdgeCases =
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

    private static TestCaseData[] tilesUnderAttackCases =
    {
        new TestCaseData("d4",
            new[] { "c5", "d5", "e5", "e4", "e3", "d3", "c3", "c4" }
        )
    };
}