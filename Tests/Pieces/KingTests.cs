using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
class KingTests : PieceTest<King>
{
    protected override Color pieceColor => Color.WHITE;

    [TestCaseSource(nameof(generalCases))]
    public override void PieceHasCorrectLegalMoves(
        string piecePosition,
        string[] legalMoves)
    {
        CreateAndAddPiece(typeof(King), piecePosition, pieceColor);

        AssertPieceLegalMoves(legalMoves);
    }

    private static object[] generalCases =
    {
        new object[] {
            "a1", new[] { "a2", "b2", "b1" }
        }, 
        new object[] {
            "a8", new[] { "a7", "b8", "b7" }
        },
        new object[] {
            "h1", new[] { "h2", "g2", "g1" }
        },
        new object[] {
            "h8", new[] { "h7", "g8", "g7" }
        },
        new object[] {
            "d4", new[] {
                "c5", "c4", "c4",
                "d5", "d3",
                "e5", "e4", "e3"
            }
        }
    };

    private static object[] blockedPathCases = 
    {
        new object[] {
            Color.WHITE, new[] {
                "c4", "e4", "d5", "d3", "c5", "e5", "c3", "e3"
            },
            "d4", new string[] { }
        },
        new object[] {
            Color.BLACK, new[] {
                "c4", "e4", "d5", "d3", "c5", "e5", "c3", "e3"
            },
            "d4", new string[] {
                "c4", "e4", "d5", "d3", "c5", "e5", "c3", "e3"
            } 
        }
    };
}