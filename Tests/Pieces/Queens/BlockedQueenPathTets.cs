using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Queens;

[TestFixture]
class BlockedQueenPathTets : PieceTestDataBuilder
{
    [Test]
    public void QueenHasBlockedDiagonals()
    {
        CreateAndAddPawns(Color.WHITE, "c4", "e4", "d5", "d3");
        CreateAndAddPawns(Color.WHITE, "b6", "f6", "b2", "f2");

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c5", "e5", "c3", "e3" });
    }

    [Test]
    public void QueenHasCapturesOnDiagonals()
    {
        CreateAndAddPawns(Color.WHITE, "c4", "e4", "d5", "d3");
        CreateAndAddPawns(Color.BLACK, "b6", "f6", "b2", "f2");

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] {
            "c5", "e5", "c3", "e3",
            "b6", "f6", "b2", "f2"
        });
    }

    [Test]
    public void QueenHasBlockedAxises()
    {
        CreateAndAddPawns(Color.WHITE, "c5", "e5", "c3", "e3");
        CreateAndAddPawns(Color.WHITE, "b4", "f4", "d6", "d2");

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "d5", "d3", "c4", "e4" });
    }

    [Test]
    public void QueenHasCapturesOnAxises()
    {
        CreateAndAddPawns(Color.WHITE, "c5", "e5", "c3", "e3");
        CreateAndAddPawns(Color.BLACK, "b4", "f4", "d6", "d2");

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] {
            "d5", "d3", "c4", "e4",
            "b4", "f4", "d6", "d2"
        });
    }
}