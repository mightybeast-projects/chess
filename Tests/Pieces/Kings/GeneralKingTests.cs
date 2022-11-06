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
        CreateAndAddPiece(typeof(King), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c5", "e5", "c3", "e3" });
    }
}