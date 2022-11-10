using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Bishops;

[TestFixture]
class BlockedBishopPathTests : PieceTestDataBuilder
{
    [Test, TestCaseSource(nameof(cases))]
    public void BishopAtPostionHasCorrectHintTilesWhilePathIsBlocked(
        Color blockerPawnsColor, string[] blockerPawnsPos,
        string bishopPos, string[] hintTiles)
    {
        foreach (string pawnPos in blockerPawnsPos)
            CreateAndAddPiece(typeof(Pawn), pawnPos, blockerPawnsColor);
        CreateAndAddPiece(typeof(Bishop), bishopPos, Color.WHITE);

        AssertPieceHintTiles(hintTiles);
    }

    private static object[] cases = 
    {
        new object[] {
            Color.WHITE, new string[] { "e5", "c3", "c5", "e3" },
            "d4", new string[] { }
        },
        new object[] {
            Color.BLACK, new string[] { "e5", "c3", "c5", "e3" },
            "d4", new string[] { "e5", "c3", "c5", "e3" }, 
        },
    };
}