using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Bishops;

[TestFixture]
class BlockedBishopPathTests : PieceTestDataBuilder
{
    [Test]
    public void BishopHasBlockedTopRightDiagonal()
    {
        CreateAndAddPawns(Color.WHITE, "c3", "c5", "e3");
        
        CreateAndAddPiece(typeof(Pawn), "f6", Color.WHITE);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "e5" });
    }
    
    [Test]
    public void BishopHasCaptureOnTopRightDiagonal()
    {
        CreateAndAddPawns(Color.WHITE, "c3", "c5", "e3");

        CreateAndAddPiece(typeof(Pawn), "f6", Color.BLACK);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "e5", "f6" });
    }

    [Test]
    public void BishopHasBlockedBottomLeftDiagonal()
    {
        CreateAndAddPawns(Color.WHITE, "e5", "c5", "e3");

        CreateAndAddPiece(typeof(Pawn), "b2", Color.WHITE);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c3" });
    }

    [Test]
    public void BishopHasCaptureOnBottomLeftDiagonal()
    {
        CreateAndAddPawns(Color.WHITE, "e5", "c5", "e3");

        CreateAndAddPiece(typeof(Pawn), "b2", Color.BLACK);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c3", "b2" });
    }

    [Test]
    public void BishopHasBlockedTopLeftDiagonal()
    {
        CreateAndAddPawns(Color.WHITE, "e5", "c3", "e3");

        CreateAndAddPiece(typeof(Pawn), "b6", Color.WHITE);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c5" });
    }

    [Test]
    public void BishopHasCaptureOnTopLeftDiagonal()
    {
        CreateAndAddPawns(Color.WHITE, "e5", "c3", "e3");

        CreateAndAddPiece(typeof(Pawn), "b6", Color.BLACK);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "b6", "c5" });
    }

    [Test]
    public void BishopHasBlockedBottomRightDiagonal()
    {
        CreateAndAddPawns(Color.WHITE, "e5", "c3", "c5");

        CreateAndAddPiece(typeof(Pawn), "f2", Color.WHITE);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "e3" });
    }

    [Test]
    public void BishopHasCaptureOnBottomRightDiagonal()
    {
        CreateAndAddPawns(Color.WHITE, "e5", "c3", "c5");

        CreateAndAddPiece(typeof(Pawn), "f2", Color.BLACK);
        CreateAndAddPiece(typeof(Bishop), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "e3", "f2" });
    }
}