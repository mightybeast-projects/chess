using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Kings;

[TestFixture]
class BlockedKingPathTests : PieceSetUp
{
    [Test]
    public void KingHasAlliesOnDiagonals()
    {
        CreateAndAddPawns(Color.WHITE, "c5", "e5", "c3", "e3");

        CreateAndAddPiece(typeof(King), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { });
    }

    [Test]
    public void KingHasCaptureOnDiagonals()
    {
        CreateAndAddPawns(Color.BLACK, "c5", "e5", "c3", "e3");

        CreateAndAddPiece(typeof(King), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c5", "e5", "c3", "e3" });
    }
}