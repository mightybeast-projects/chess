using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
class WhitePawnTests : PieceTest<Pawn>
{
    protected override Color pieceColor => Color.WHITE;

    private static object[] generalCases = 
    {
        new object[] { "d4", new string[] { "d5" } },
        new object[] { "d2", new string[] { "d3", "d4" } },
        new object[] { "d8", new string[] { } }
    };

    private static object[] blockedPathCases = 
    {
        new object[] {
            Color.BLACK, new string[] { "d3" },
            "d2", new string[] { }
        },
        new object[] {
            Color.BLACK, new string[] { "d4" },
            "d2", new string[] { "d3" }
        },
        new object[] {
            Color.BLACK, new string[] { "a5", "b5" },
            "a4", new string[] { "b5" }
        },
        new object[] {
            Color.BLACK, new string[] { "h5", "g5" },
            "h4", new string[] { "g5" }
        },
        new object[] {
            Color.BLACK, new string[] { "c5", "d5", "e5" },
            "d4", new string[] { "c5", "e5" }
        }
    };
}