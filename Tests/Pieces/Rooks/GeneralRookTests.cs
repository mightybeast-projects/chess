using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Rooks;

[TestFixture]
class GeneralRookTests : PieceTestDataBuilder
{
    [Test]
    public void RookInitialization()
    {
        CreateAndAddPiece(typeof(Rook), "d4", Color.WHITE);

        AssertPiece();
    }

    [Test]
    public void RookHasUpperVerticalHintTiles()
    {
        CreateAndAddPiece(typeof(Pawn), "b1", Color.WHITE);
        CreateAndAddPiece(typeof(Rook), "a1", Color.WHITE);

        AssertPieceHintTiles(new string[] {
            "a2", "a3", "a4", "a5", "a6", "a7", "a8"
        });
    }

    [Test]
    public void RookHasLowerVerticalHintTiles()
    {
        CreateAndAddPiece(typeof(Pawn), "b8", Color.WHITE);
        CreateAndAddPiece(typeof(Rook), "a8", Color.WHITE);

        AssertPieceHintTiles(new string[] {
            "a1", "a2", "a3", "a4", "a5", "a6", "a7"
        });
    }

    [Test]
    public void RookHasRightSideHintTiles()
    {
        CreateAndAddPiece(typeof(Pawn), "a2", Color.WHITE);
        CreateAndAddPiece(typeof(Rook), "a1", Color.WHITE);

        AssertPieceHintTiles(new string[] {
            "b1", "c1", "d1", "e1", "f1", "g1", "h1"
        });
    }

    [Test]
    public void RookHasLeftSideHintTiles()
    {
        CreateAndAddPiece(typeof(Pawn), "h2", Color.WHITE);
        CreateAndAddPiece(typeof(Rook), "h1", Color.WHITE);

        AssertPieceHintTiles(new string[] {
            "a1", "b1", "c1", "d1", "e1", "f1", "g1"
        });
    }

    [Test]
    public void RookHasAllCorrectTiles()
    {
        CreateAndAddPiece(typeof(Rook), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] {
            "d5", "d6", "d7", "d8",
            "d3", "d2", "d1",
            "e4", "f4", "g4", "h4",
            "c4", "b4", "a4"
        });
    }
}