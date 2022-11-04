using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Knights;

[TestFixture]
class BlockedPathTests : PieceSetUp
{
    [Test]
    public void KnightHasNoBottomAndLeftLHintTiles()
    {
        CreateAndAddPiece(typeof(Knight), "b2", Color.WHITE);

        AssertPieceHintTiles(new string[] { "a4", "c4", "d3", "d1" });
    }

    [Test]
    public void KnightHasNoTopAndRightLHintTiles()
    {
        CreateAndAddPiece(typeof(Knight), "g7", Color.BLACK);

        AssertPieceHintTiles(new string[] { "e8", "e6", "f5", "h5" });
    }

    [Test]
    public void KnightHasCaptureHintTiles()
    {
        CreateAndAddPiece(typeof(Pawn), "c6", Color.BLACK);
        CreateAndAddPiece(typeof(Pawn), "e6", Color.BLACK);

        CreateAndAddPiece(typeof(Knight), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] {
            "c6", "e6", 
            "f5", "f3", 
            "c2", "e2", 
            "b3", "b5"
        });
    }
}