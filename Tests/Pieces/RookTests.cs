using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
class RookTests : PieceTest
{
    [Test]
    public override void PieceInitialization()
    {
        CreateAndAddPiece(typeof(Rook), "d4", Color.WHITE);

        AssertPiece();
    }

    [TestCaseSource(nameof(generalCases))]
    public override void PieceHasCorrectLegalMoves_InGeneralCases(
        string piecePosition,
        string[] legalMoves)
    {
        CreateAndAddPiece(typeof(Rook), piecePosition, Color.WHITE);

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
        CreateAndAddPiece(typeof(Rook), piecePos, Color.WHITE);

        AssertPieceLegalMoves(legalMoves);
    }

    private static object[] generalCases = 
    {
        new object[] {
            "a1", new[] {
                "b1", "c1", "d1", "e1", "f1", "g1", "h1",
                "a2", "a3", "a4", "a5", "a6", "a7", "a8"
            }
        },
        new object[] {
            "h8", new[] {
                "a8", "b8", "c8", "d8", "e8", "f8", "g8",
                "h1", "h2", "h3", "h4", "h5", "h6", "h7"
            }
        },
        new object[] {
            "d4", new[] {
                "d5", "d6", "d7", "d8",
                "d3", "d2", "d1",
                "e4", "f4", "g4", "h4",
                "c4", "b4", "a4"
            }
        }
    };

    private static object[] edgeCases = 
    {
        new object[] {
            Color.WHITE, new[] { "d5", "d3", "e4","c4" },
            "d4", new string[] { }
        },
        new object[] {
            Color.BLACK, new[] { "d5", "d3", "e4","c4" },
            "d4", new string[] { "d5", "d3", "e4","c4" }
        }
    };
}