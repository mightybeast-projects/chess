using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Bishops;

[TestFixture]
class GeneralBishopTests : PieceSetUp
{
    [Test]
    public void BishopInitialization()
    {
        CreateAndAddPiece(typeof(Bishop), "d4", Core.Color.WHITE);
        AssertPiece();
    }

    [Test]
    public void BishopHasTopRightDiagonalHintTiles()
    {
        CreateAndAddPiece(typeof(Bishop), "a1", Color.WHITE);
        AssertPieceHintTiles(new string[] {
            "b2", "c3", "d4", "e5", "f6", "g7", "h8"
        });
    }

    [Test]
    public void BishopHasBottomLeftDiagonalHintTiles()
    {
        CreateAndAddPiece(typeof(Bishop), "h8", Color.WHITE);
        AssertPieceHintTiles(new string[] {
            "a1", "b2", "c3", "d4", "e5", "f6", "g7"
        });
    }

    [Test]
    public void BishopHasTopLeftDiagonalHintTiles()
    {
        CreateAndAddPiece(typeof(Bishop), "h1", Color.WHITE);
        AssertPieceHintTiles(new string[] {
            "g2", "f3", "e4", "d5", "c6", "b7", "a8"
        });
    }

    [Test]
    public void BishopHasBottomRightDiagonalHintTiles()
    {
        CreateAndAddPiece(typeof(Bishop), "a8", Color.WHITE);
        AssertPieceHintTiles(new string[] {
            "h1", "g2", "f3", "e4", "d5", "c6", "b7"
        });
    }

    [Test]
    public void BishopHasAllCorrectHintTiles()
    {
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);
        AssertPieceHintTiles(new string[] { 
            "e5", "f6", "g7", "h8",
            "e3", "f2", "g1",
            "c3", "b2", "a1",
            "c5", "b6", "a7"
        });
    }
}