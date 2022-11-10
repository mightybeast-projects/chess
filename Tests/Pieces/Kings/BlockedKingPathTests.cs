using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Kings;

[TestFixture]
class BlockedKingPathTests : PieceTestDataBuilder
{
    [Test, TestCaseSource(nameof(cases))]
    public void KingHasCorrectHintTilesWhilePathIsBlocked(
        Color blockerPawnsColor, string[] blockerPawnsPos,
        string kingPos, string[] hintTiles)
    {
        foreach (string pawnPos in blockerPawnsPos)
            CreateAndAddPiece(typeof(Pawn), pawnPos, blockerPawnsColor);
        CreateAndAddPiece(typeof(King), kingPos, Color.WHITE);

        AssertPieceHintTiles(hintTiles);
    }

    private static object[] cases = 
    {
        new object[] {
            Color.WHITE, new string[] {
                "c4", "e4", "d5", "d3", "c5", "e5", "c3", "e3"
            },
            "d4", new string[] { }
        },
        new object[] {
            Color.BLACK, new string[] {
                "c4", "e4", "d5", "d3", "c5", "e5", "c3", "e3"
            },
            "d4", new string[] {
                "c4", "e4", "d5", "d3", "c5", "e5", "c3", "e3"
            } 
        }
    };
}