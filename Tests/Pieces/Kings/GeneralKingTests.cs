using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Kings;

[TestFixture]
class GeneralKingTests : PieceTestDataBuilder
{
    [Test]
    public void KingInitialization()
    {
        CreateAndAddPiece(typeof(King), "d4", Color.WHITE);

        AssertPiece();
    }

    [Test, TestCaseSource(nameof(cases))]
    public void KingAtPositionHasHintTiles(
        string kingPosition,
        string[] hintTiles)
    {
        CreateAndAddPiece(typeof(King), kingPosition, Color.WHITE);

        AssertPieceHintTiles(hintTiles);
    }

    private static object[] cases =
    {
        new object[] {
            "a1", new string[] { "a2", "b2", "b1" }
        },
        new object[] {
            "a8", new string[] { "a7", "b8", "b7" }
        },
        new object[] {
            "h1", new string[] { "h2", "g2", "g1" }
        },
        new object[] {
            "h8", new string[] { "h7", "g8", "g7" }
        },
        new object[] {
            "d4", new string[] {
                "c5", "c4", "c4",
                "d5", "d3",
                "e5", "e4", "e3"
            }
        }
    };
}