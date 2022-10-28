using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Bishops;

[TestFixture]
class BlockedPathTests : PieceSetUp
{
    [Test]
    public void BishopHasBlockedTopLeftDiagonal()
    {
        CreateAndAddPiece(typeof(Pawn), "f6", Color.WHITE);

        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "e5" });
    }
}