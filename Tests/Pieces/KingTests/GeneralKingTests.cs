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
        string piecePos,
        string[] legalMoves,
        Color blockerPawnsColor,
        string[] blockerPawnsPos) =>
            base.PieceHasCorrectLegalMoves_InEdgeCases(
                piecePos, legalMoves, blockerPawnsColor, blockerPawnsPos);

    [TestCaseSource(nameof(legalMovesGeneralCases))]
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
        new TestCaseData("h8", new[] { "h7", "g8", "g7" }),
        new TestCaseData(
            "d4", new[] { "c5", "c4", "c3", "d5", "d3", "e5", "e4", "e3" }
        )
    };

    private static TestCaseData[] legalMovesEdgeCases =
    {
        new TestCaseData(
            "d4", new string[] { },
            Color.WHITE, blockerPawnsPositions
        ),
        new TestCaseData(
            "d4", new string[] { "c5", "d5", "e5", "c3", "e3" },
            Color.BLACK, blockerPawnsPositions
        )
    };

    private static string[] blockerPawnsPositions =>
        new[] { "c4", "e4", "d5", "d3", "c5", "e5", "c3", "e3" };
}