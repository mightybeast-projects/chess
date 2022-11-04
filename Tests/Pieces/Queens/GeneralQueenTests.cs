using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Queens;

[TestFixture]
class GeneralQueenTests : PieceSetUp
{
    [Test]
    public void QueenInitialization()
    {
        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);
        AssertPiece();
    }

    [Test]
    public void QueenHasCorrectDiagonalHintTiles()
    {
        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { 
            "e5", "f6", "g7", "h8",
            "e3", "f2", "g1",
            "c3", "b2", "a1",
            "c5", "b6", "a7"
        });
    }
}