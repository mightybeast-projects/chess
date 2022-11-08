using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Pawns;

[TestFixture]
class BlackPawnTests : PieceTestDataBuilder, IPawnTest
{
    [Test]
    public void PawnInitialization()
    {
        CreateAndAddPiece(typeof(Pawn), "e5", Color.BLACK);

        AssertPiece();
    }

    [Test]
    public void PawnHasOneHintTile()
    {
        CreateAndAddPiece(typeof(Pawn), "d5", Color.BLACK);

        AssertPieceHintTiles(new string[] { "d4" });
    }

    [Test]
    public void PawnHasTwoHintTiles()
    {
        CreateAndAddPiece(typeof(Pawn), "d7", Color.BLACK);
        
        AssertPieceHintTiles(new string[] { "d6", "d5" });
    }

    [Test]
    public void PawnHasNoHintTilesOnTheEdgeOfTheBoard()
    {
        CreateAndAddPiece(typeof(Pawn), "a1", Color.BLACK);

        Assert.AreEqual(0, piece.hintTiles.Count);
    }

    [Test]
    public void PawnHasNoHintsWhenPathBlocked()
    {
        CreateAndAddPiece(typeof(Pawn), "d6", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "d7", Color.BLACK);

        Assert.IsEmpty(piece.hintTiles);
    }

    [Test]
    public void PawnHasOneHintTileAndOneCapture()
    {
        CreateAndAddPawns(Color.WHITE, "b4", "e4", "g5");

        CreateAndAddPiece(typeof(Pawn), "a5", Color.BLACK);
        AssertPieceHintTiles(new string[] { "a4", "b4" });

        CreateAndAddPiece(typeof(Pawn), "d5", Color.BLACK);
        AssertPieceHintTiles(new string[] { "d4", "e4" });

        CreateAndAddPiece(typeof(Pawn), "h6", Color.BLACK);
        AssertPieceHintTiles(new string[] { "h5", "g5" });
    }

    [Test]
    public void PawnHasOneHintTileAndTwoCaptures()
    {
        CreateAndAddPawns(Color.WHITE, "c4", "e4");
        CreateAndAddPiece(typeof(Pawn), "d5", Color.BLACK);

        AssertPieceHintTiles(new string[] { "c4", "d4", "e4" });
    }
}