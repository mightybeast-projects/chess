using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
class QueenTests : PieceTest<Queen>
{
    private static object[] generalCases = 
    {
        new object[] {
            "a1", new string[] {
                "b1", "c1", "d1", "e1", "f1", "g1", "h1",
                "b2", "c3", "d4", "e5", "f6", "g7", "h8",
                "a2", "a3", "a4", "a5", "a6", "a7", "a8"
            }
        },
        new object[] {
            "h8", new string[] {
                "a8", "b8", "c8", "d8", "e8", "f8", "g8",
                "a1", "b2", "c3", "d4", "e5", "f6", "g7",
                "h1", "h2", "h3", "h4", "h5", "h6", "h7"
            }
        },
        new object[] {
            "d4", new string[] {
                "e5", "f6", "g7", "h8",
                "e3", "f2", "g1",
                "c3", "b2", "a1",
                "c5", "b6", "a7",
                "d5", "d6", "d7", "d8",
                "d3", "d2", "d1",
                "e4", "f4", "g4", "h4",
                "c4", "b4", "a4"
            }
        }
    };

    private static object[] blockedPathCases = 
    {
        new object[] {
            Color.WHITE, new string[] {
                "e5", "e3", "c3", "c5", "d5", "d3", "e4", "c4"
            },
            "d4", new string[] { }
        },
        new object[] {
            Color.BLACK, new string[] {
                "e5", "e3", "c3", "c5", "d5", "d3", "e4", "c4"
            },
            "d4", new string[] {
                "e5", "e3", "c3", "c5", "d5", "d3", "e4", "c4"
            }
        }
    };
}