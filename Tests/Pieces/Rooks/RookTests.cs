using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Rooks;

[TestFixture]
class RookTests : PieceSetUp
{
    [Test]
    public void RookInitialization()
    {
        CreateAndAddPiece(typeof(Rook), "d4", Color.WHITE);
        AssertPiece();
    }

    [Test]
    public void RookHasVerticalHintTiles()
    {
        CreateAndAddPiece(typeof(Rook), "a1", Color.WHITE);
        AssertPieceHintTiles(
            new string[] { "a2", "a3", "a4", "a5", "a6", "a7", "a8" });

        CreateAndAddPiece(typeof(Rook), "a8", Color.WHITE);
        AssertPieceHintTiles(
            new string[] { "a1", "a2", "a3", "a4", "a5", "a6", "a7" });
    }
}