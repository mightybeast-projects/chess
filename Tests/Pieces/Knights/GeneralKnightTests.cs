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
        BlockKnightLHintTiles("f3", "f5");
        BlockKnightLHintTiles("c2", "e2");
        BlockKnightLHintTiles("b3", "b5");

        CreateAndAddPiece(typeof(Knight), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c6", "e6" });
    }

    [Test]
    public void KnightHasRightLHintTiles()
    {
        BlockKnightLHintTiles("c6", "e6");
        BlockKnightLHintTiles("c2", "e2");
        BlockKnightLHintTiles("b3", "b5");

        CreateAndAddPiece(typeof(Knight), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "f5", "f3" });
    }

    [Test]
    public void KnightHasBottomLHintTiles()
    {
        BlockKnightLHintTiles("c6", "e6");
        BlockKnightLHintTiles("f5", "f3");
        BlockKnightLHintTiles("b3", "b5");

        CreateAndAddPiece(typeof(Knight), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c2", "e2" });
    }

    [Test]
    public void KnightHasLeftLHintTiles()
    {
        BlockKnightLHintTiles("c6", "e6");
        BlockKnightLHintTiles("f5", "f3");
        BlockKnightLHintTiles("c2", "e2");

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

    private void BlockKnightLHintTiles(string s1, string s2)
    {
        CreateAndAddPiece(typeof(Pawn), s1, Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), s2, Color.WHITE);
    }
}