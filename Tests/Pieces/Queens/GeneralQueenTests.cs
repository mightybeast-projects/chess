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
        CreateAndAddPiece(typeof(Pawn), "d5", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "d3", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "c4", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "e4", Color.WHITE);

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { 
            "e5", "f6", "g7", "h8",
            "e3", "f2", "g1",
            "c3", "b2", "a1",
            "c5", "b6", "a7"
        });
    }

    [Test]
    public void QueenHasCorrectAxisHintTiles()
    {
        CreateAndAddPiece(typeof(Pawn), "c5", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "e5", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "c3", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "e3", Color.WHITE);

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { 
            "d5", "d6", "d7", "d8",
            "d3", "d2", "d1",
            "e4", "f4", "g4", "h4",
            "c4", "b4", "a4"
        });
    }
}