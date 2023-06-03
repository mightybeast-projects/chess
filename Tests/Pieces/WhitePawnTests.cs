using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
class WhitePawnTests : PieceTest
{
    [Test]
    public override void PieceInitialization()
    {
        CreateAndAddPiece(typeof(Pawn), "d4", Color.WHITE);

        AssertPiece();
    }

    [TestCaseSource(nameof(generalCases))]
    public override void PieceHasCorrectLegalMoves_InGeneralCases(
        string piecePosition,
        string[] legalMoves)
    {
        CreateAndAddPiece(typeof(Pawn), piecePosition, Color.WHITE);

        AssertPieceLegalMoves(legalMoves);
    }

    [TestCaseSource(nameof(edgeCases))]
    public override void PieceHasCorrectLegalMoves_InEdgeCases(
        Color blockerPawnsColor,
        string[] blockerPawnsPos,
        string piecePos,
        string[] legalMoves)
    {
        foreach (string pawnPos in blockerPawnsPos)
            CreateAndAddPiece(typeof(Pawn), pawnPos, blockerPawnsColor);
        CreateAndAddPiece(typeof(Pawn), piecePos, Color.WHITE);

        AssertPieceLegalMoves(legalMoves);
    }

    private static object[] generalCases = 
    {
        new object[] { "d4", new[] { "d5" } },
        new object[] { "d2", new[] { "d3", "d4" } },
        new object[] { "d8", new string[] { } }
    };

    private static object[] edgeCases = 
    {
        new object[] {
            Color.BLACK, new[] { "d3" },
            "d2", new string[] { }
        },
        new object[] {
            Color.BLACK, new[] { "d4" },
            "d2", new string[] { "d3" }
        },
        new object[] {
            Color.BLACK, new[] { "a5", "b5" },
            "a4", new string[] { "b5" }
        },
        new object[] {
            Color.BLACK, new[] { "h5", "g5" },
            "h4", new string[] { "g5" }
        },
        new object[] {
            Color.BLACK, new[] { "c5", "d5", "e5" },
            "d4", new string[] { "c5", "e5" }
        }
    };
}