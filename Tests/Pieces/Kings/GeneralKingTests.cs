using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Kings;

[TestFixture]
class GeneralKingTests : PieceSetUp
{
    [Test]
    public void KingInitialization()
    {
        CreateAndAddPiece(typeof(King), "d4", Color.WHITE);
        AssertPiece();
    }

    [Test]
    public void KingHasDiagonalHintTiles()
    {
        CreateAndAddPawns(Color.WHITE, "c4", "e4", "d5", "d3");

        CreateAndAddPiece(typeof(King), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c5", "e5", "c3", "e3" });
    }

    [Test]
    public void KingHasAxisHintTiles()
    {
        CreateAndAddPawns(Color.WHITE, "c5", "e5", "c3", "e3");

        CreateAndAddPiece(typeof(King), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c4", "e4", "d5", "d3" });
    }
}