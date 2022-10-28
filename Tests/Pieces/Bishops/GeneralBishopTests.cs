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
    public void BishopHasTopLeftDiagonalHintTiles()
    {
        CreateAndAddPiece(typeof(Bishop), "d4", Core.Color.WHITE);

        AssertPieceHintTiles(new string[] { "e5", "f6", "g7", "h8" });
    }
}