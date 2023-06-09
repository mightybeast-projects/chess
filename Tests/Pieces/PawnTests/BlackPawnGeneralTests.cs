using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.PawnTests;

[TestFixture]
internal class BlackPawnGeneralTests : PieceTest<Pawn>
{
    protected override Color pieceColor => Color.BLACK;

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

    [Test]
    public void BlackPawn_HasMovedTwoTiles()
    {
        Pawn pawn = new Pawn(board.GetTile("a7"), Color.BLACK);

        board.AddPiece(pawn);

        pawn.Move("a5");

        Assert.IsTrue(pawn.hasMovedTwoTiles);
    }

    private static TestCaseData[] legalMovesGeneralCases =
    {
        new TestCaseData("d7", new[] { "d6", "d5" }),
        new TestCaseData("d6", new[] { "d5" }),
        new TestCaseData("d1", new string[] { })
    };

    private static TestCaseData[] legalMovesEdgeCases =
    {
        new TestCaseData(
            "d7", new string[] { },
            Color.WHITE, new[] { "d6" }
        ),
        new TestCaseData(
            "d7", new[] { "d6" },
            Color.WHITE, new[] { "d5" }
        ),
        new TestCaseData(
            "a5", new[] { "b4" },
            Color.WHITE, new[] { "a4", "b4" }
        ),
        new TestCaseData(
            "h5", new[] { "g4" },
            Color.WHITE, new[] { "h4", "g4" }
        ),
        new TestCaseData(
            "d5", new[] { "c4", "e4" },
            Color.WHITE, new[] { "c4", "d4", "e4" }
        )
    };

    private static TestCaseData[] tilesUnderAttackCases =
    {
        new TestCaseData("a5", new[] { "b4" }),
        new TestCaseData("h5", new[] { "g4" }),
        new TestCaseData("d5", new[] { "c4", "e4" })
    };
}