using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
class BishopTests : PieceTest
{
    [Test]
    public override void PieceInitialization()
    {
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPiece();
    }

    [TestCaseSource(nameof(generalCases))]
    public override void PieceHasCorrectLegalMoves_InGeneralCases(
        string piecePosition,
        string[] legalMoves)
    {
        CreateAndAddPiece(typeof(Bishop), piecePosition, Color.WHITE);

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
        CreateAndAddPiece(typeof(Bishop), piecePos, Color.WHITE);

        AssertPieceLegalMoves(legalMoves);
    }

    public static object[] generalCases = 
    {
        new object[] {
            "a1", new[] {
                "b2", "c3", "d4", "e5", "f6", "g7", "h8"
            }
        },
        new object[] {
            "a8", new[] {
                "h1", "g2", "f3", "e4", "d5", "c6", "b7"
            }
        },
        new object[] {
            "h1", new[] {
                "g2", "f3", "e4", "d5", "c6", "b7", "a8"
            }
        },
        new object[] {
            "h8", new[] {
                "a1", "b2", "c3", "d4", "e5", "f6", "g7"
            }
        },
        new object[] {
            "d4", new[] {
                "e5", "f6", "g7", "h8",
                "e3", "f2", "g1",
                "c3", "b2", "a1",
                "c5", "b6", "a7"
            }
        }
    };

    private static object[] edgeCases = 
    {
        new object[] {
            Color.WHITE, new[] { "e5", "c3", "c5", "e3" },
            "d4", new string[] { }
        },
        new object[] {
            Color.BLACK, new[] { "e5", "c3", "c5", "e3" },
            "d4", new string[] { "e5", "c3", "c5", "e3" }, 
        }
    };
}