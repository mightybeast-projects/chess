using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.PawnTests;

[TestFixture]
internal class BlackPawnTests : PieceTest<Pawn>
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
    public void BlackPawnHasOneLegalMove_AfterOneMove()
    {
        Pawn pawn = new Pawn(board.GetTile("d7"), pieceColor);
        board.AddPiece(pawn);

        pawn.Move("d6");

        Assert.IsTrue(pawn.hasMoved);
        Assert.That(pawn.legalMoves, Is.SubsetOf(new Tile[] {
            board.GetTile("d5")
        }));
    }

    private static TestCaseData[] legalMovesGeneralCases =
    {
        new TestCaseData("d7", new[] { "d6", "d5" }),
        new TestCaseData("d1", new string[] { })
    };

    private static TestCaseData[] legalMovesEdgeCases =
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

    private static TestCaseData[] tilesUnderAttackCases =
    {
        new TestCaseData("d5", new[] { "c4", "e4", })
    };
}