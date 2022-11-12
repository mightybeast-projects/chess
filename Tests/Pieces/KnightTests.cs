using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
class KnightTests : PieceTest<Knight>
{
    protected override Color pieceColor => Color.WHITE;

    private static object[] generalCases = 
    {
        new object[] { "a1", new string[] { "b3", "c2" } },
        new object[] { "h1", new string[] { "g3", "f2" } },
        new object[] { "a8", new string[] { "b6", "c7" } },
        new object[] { "h8", new string[] { "g6", "f7" } },
        new object[] {
            "d4", new string[] {
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
            Color.WHITE, new string[] {
                "c6", "e6",
                "f5", "f3",
                "c2", "e2",
                "b3", "b5"
            },
            "d4", new string[] { }
        },
        new object[] {
            Color.BLACK, new string[] {
                "c6", "e6",
                "f5", "f3",
                "c2", "e2",
                "b3", "b5"
            },
            "d4", new string[] {
                "c6", "e6",
                "f5", "f3",
                "c2", "e2",
                "b3", "b5"
            }
        }
    };
}