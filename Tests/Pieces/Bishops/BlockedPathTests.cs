using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Bishops;

[TestFixture]
class BlockedPathTests : PieceSetUp
{
    [Test]
    public void BishopHasBlockedTopRightDiagonal()
    {
        CreateAndAddPiece(typeof(Pawn), "c3", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "f6", Color.WHITE);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "e5" });
    }
    
    [Test]
    public void BishopHasCaptureOnTopRightDiagonal()
    {
        CreateAndAddPiece(typeof(Pawn), "c3", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "f6", Color.BLACK);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "e5", "f6" });
    }
}