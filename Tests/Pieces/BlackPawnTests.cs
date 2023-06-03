using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
class BlackPawnTests : PieceTest
{
    [Test]
    public override void PieceInitialization()
    {
        CreateAndAddPiece(typeof(Pawn), "d4", Color.BLACK);

        AssertPiece();
    }

    [TestCaseSource(nameof(generalCases))]
    public override void PieceHasCorrectLegalMoves_InGeneralCases(
        string piecePosition,
        string[] legalMoves)
    {
        CreateAndAddPiece(typeof(Pawn), piecePosition, Color.BLACK);

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
        CreateAndAddPiece(typeof(Pawn), piecePos, Color.BLACK);

        AssertPieceLegalMoves(legalMoves);
    }

    private static object[] generalCases = 
    {
        new object[] { "d5", new[] { "d4" } },
        new object[] { "d7", new[] { "d6", "d5" } },
        new object[] { "d1", new string[] { } }
    };

    private static object[] edgeCases = 
    {
        new object[] {
            Color.WHITE, new[] { "d6" },
            "d7", new string[] { }
        },
        new object[] {
            Color.WHITE, new[] { "d5" },
            "d7", new string[] { "d6" }
        },
        new object[] {
            Color.WHITE, new[] { "a4", "b4" },
            "a5", new string[] { "b4" }
        },
        new object[] {
            Color.WHITE, new[] { "h4", "g4" },
            "h5", new string[] { "g4" }
        },
        new object[] {
            Color.WHITE, new[] { "c4", "d4", "e4" },
            "d5", new string[] { "c4", "e4" }
        }
    };
}