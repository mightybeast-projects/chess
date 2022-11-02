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
        AssertPieceHintTiles(new string[] { "b2", "c3", "d4", "e5", "f6", "g7", "h8" });

        CreateAndAddPiece(typeof(Bishop), "g1", Color.WHITE);
        AssertPieceHintTiles(new string[] { "h2" });

        CreateAndAddPiece(typeof(Bishop), "a7", Color.WHITE);
        AssertPieceHintTiles(new string[] { "b8" });

        CreateAndAddPiece(typeof(Pawn), "e3", Color.WHITE);
        CreateAndAddPiece(typeof(Bishop), "f4", Color.WHITE);
        AssertPieceHintTiles(new string[] { "g5", "h6" });
    }

    [Test]
    public void BishopHasBottomLeftDiagonalHintTiles()
    {
        CreateAndAddPiece(typeof(Bishop), "h8", Color.WHITE);
        AssertPieceHintTiles(new string[] { "a1", "b2", "c3", "d4", "e5", "f6", "g7" });

    }
}