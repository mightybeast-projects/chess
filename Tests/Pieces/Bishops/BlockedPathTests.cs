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
        CreateAndAddPiece(typeof(Pawn), "c5", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "f6", Color.WHITE);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "e5" });
    }
    
    [Test]
    public void BishopHasCaptureOnTopRightDiagonal()
    {
        CreateAndAddPiece(typeof(Pawn), "c3", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "c5", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "f6", Color.BLACK);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "e5", "f6" });
    }

    [Test]
    public void BishopHasBlockedBottomLeftDiagonal()
    {
        CreateAndAddPiece(typeof(Pawn), "b2", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "c5", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "e5", Color.WHITE);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c3" });
    }

    [Test]
    public void BishopHasCaptureOnBottomLeftDiagonal()
    {
        CreateAndAddPiece(typeof(Pawn), "b2", Color.BLACK);
        CreateAndAddPiece(typeof(Pawn), "c5", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "e5", Color.WHITE);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c3", "b2" });
    }

    [Test]
    public void BishopHasBlockedTopLeftDiagonal()
    {
        CreateAndAddPiece(typeof(Pawn), "e5", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "c3", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "b6", Color.WHITE);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c5" });
    }

    [Test]
    public void BishopHasCaptureOnTopLeftDiagonal()
    {
        CreateAndAddPiece(typeof(Pawn), "e5", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "c3", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "b6", Color.BLACK);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "b6", "c5" });
    }
}