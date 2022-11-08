using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Kings;

[TestFixture]
class BlockedKingPathTests : PieceTestDataBuilder
{
    [Test]
    public void KingHasAlliesOnDiagonalsAndAxises()
    {
        CreateAndAddPawns(Color.WHITE, "c4", "e4", "d5", "d3");
        CreateAndAddPawns(Color.WHITE, "c5", "e5", "c3", "e3");

        CreateAndAddPiece(typeof(King), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { });
    }

    [Test]
    public void KingHasCaptureOnDiagonalsAndAxises()
    {
        CreateAndAddPawns(Color.BLACK, "c4", "e4", "d5", "d3");
        CreateAndAddPawns(Color.BLACK, "c5", "e5", "c3", "e3");

        CreateAndAddPiece(typeof(King), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] {
            "c5", "e5", "c3", "e3",
            "c4", "e4", "d5", "d3"
        });
    }
}