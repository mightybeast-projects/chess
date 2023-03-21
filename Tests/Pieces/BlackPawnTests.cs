using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
class BlackPawnTests : PieceTest<Pawn>
{
    protected override Color pieceColor => Color.BLACK;

    private static object[] generalCases = 
    {
        new object[] { "d5", new[] { "d4" } },
        new object[] { "d7", new[] { "d6", "d5" } },
        new object[] { "d1", new string[] { } }
    };

    private static object[] blockedPathCases = 
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