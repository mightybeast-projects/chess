using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Knights;

[TestFixture]
class GeneralKnightTests : PieceSetUp
{
    [Test]
    public void KnightInitialization()
    {
        CreateAndAddPiece(typeof(Knight), "d4", Core.Color.WHITE);
        AssertPiece();
    }

    [Test]
    public void KnightHasTopLHintTiles()
    {
        CreateAndAddPawns(Color.WHITE, "b3", "b5", "f5", "f3", "c2", "e2");

        CreateAndAddPiece(typeof(Knight), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c6", "e6" });
    }

    [Test]
    public void KnightHasRightLHintTiles()
    {
        CreateAndAddPawns(Color.WHITE, "c6", "e6", "c2", "e2", "b3", "b5");

        CreateAndAddPiece(typeof(Knight), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "f5", "f3" });
    }

    [Test]
    public void KnightHasBottomLHintTiles()
    {
        CreateAndAddPawns(Color.WHITE, "c6", "e6", "f5", "f3", "b3", "b5");

        CreateAndAddPiece(typeof(Knight), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c2", "e2" });
    }

    [Test]
    public void KnightHasLeftLHintTiles()
    {
        CreateAndAddPawns(Color.WHITE, "c6", "e6", "f5", "f3", "c2", "e2");

        CreateAndAddPiece(typeof(Knight), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "b3", "b5" });
    }

    [Test]
    public void KnightHasAllLHintTiles()
    {
        CreateAndAddPiece(typeof(Knight), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { 
            "c6", "e6",
            "f5", "f3",
            "c2", "e2",
            "b3", "b5"
        });
    }
}