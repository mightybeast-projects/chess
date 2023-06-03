using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
class KnightTests : PieceTest<Knight>
{
    protected override Color pieceColor => Color.WHITE;

    [TestCaseSource(nameof(generalCases))]
    public override void PieceHasCorrectLegalMoves(
        string piecePosition,
        string[] legalMoves)
    {
        CreateAndAddPiece(typeof(Knight), piecePosition, pieceColor);

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

    private static object[] blockedPathCases = 
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