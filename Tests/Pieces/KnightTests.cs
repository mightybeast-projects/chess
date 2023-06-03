using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
class KnightTests : PieceTest
{
    [Test]
    public override void PieceInitialization()
    {
        CreateAndAddPiece(typeof(Knight), "d4", Color.WHITE);

        AssertPiece();
    }

    [TestCaseSource(nameof(generalCases))]
    public override void PieceHasCorrectLegalMoves_InGeneralCases(
        string piecePosition,
        string[] legalMoves)
    {
        CreateAndAddPiece(typeof(Knight), piecePosition, Color.WHITE);

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
        CreateAndAddPiece(typeof(Knight), piecePos, Color.WHITE);

        AssertPieceLegalMoves(legalMoves);
    }

    private static object[] generalCases = 
    {
        new object[] { "a1", new[] { "b3", "c2" } },
        new object[] { "h1", new[] { "g3", "f2" } },
        new object[] { "a8", new[] { "b6", "c7" } },
        new object[] { "h8", new[] { "g6", "f7" } },
        new object[] {
            "d4", new[] {
                "c6", "e6",
                "f5", "f3",
                "c2", "e2",
                "b3", "b5"
            }
        }
    };

    private static object[] edgeCases = 
    {
        new object[] {
            Color.WHITE, new[] {
                "c6", "e6",
                "f5", "f3",
                "c2", "e2",
                "b3", "b5"
            },
            "d4", new string[] { }
        },
        new object[] {
            Color.BLACK, new[] {
                "c6", "e6",
                "f5", "f3",
                "c2", "e2",
                "b3", "b5"
            },
            "d4", new[] {
                "c6", "e6",
                "f5", "f3",
                "c2", "e2",
                "b3", "b5"
            }
        }
    };
}