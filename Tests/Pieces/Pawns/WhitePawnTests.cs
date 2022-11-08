using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Pawns;

[TestFixture]
class WhitePawnTests : PieceSetUp, IPawnTest
{
    [Test]
    public void PawnInitialization()
    {
        CreateAndAddPiece(typeof(Pawn), "d4", Color.WHITE);
        
        AssertPiece();
    }

    [Test]
    public void PawnHasOneHintTile()
    {
        CreateAndAddPiece(typeof(Pawn), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "d5" });
    }

    [Test]
    public void PawnHasTwoHintTiles()
    {
        CreateAndAddPiece(typeof(Pawn), "d2", Color.WHITE);

        AssertPieceHintTiles(new string[] { "d3", "d4" });
    }

    [Test]
    public void PawnHasNoHintTilesOnTheEdgeOfTheBoard()
    {
        CreateAndAddPiece(typeof(Pawn), "a8", Color.WHITE);

        Assert.AreEqual(0, piece.hintTiles.Count);
    }

    [Test]
    public void PawnHasNoHintsWhenPathBlocked()
    {
        CreateAndAddPiece(typeof(Pawn), "d3", Color.BLACK);
        CreateAndAddPiece(typeof(Pawn), "d2", Color.WHITE);

        Assert.IsEmpty(piece.hintTiles);
    }

    [Test]
    public void PawnHasOneHintTileAndOneCapture()
    {
        CreateAndAddPawns(Color.BLACK, "b5", "g5", "e5");

        CreateAndAddPiece(typeof(Pawn), "a4", Color.WHITE);
        AssertPieceHintTiles(new string[] { "a5", "b5" });

        CreateAndAddPiece(typeof(Pawn), "h4", Color.WHITE);
        AssertPieceHintTiles(new string[] { "h5", "g5" });

        CreateAndAddPiece(typeof(Pawn), "d4", Color.WHITE);
        AssertPieceHintTiles(new string[] { "d5", "e5" });
    }

    [Test]
    public void PawnHasOneHintTileAndTwoCaptures()
    {
        CreateAndAddPawns(Color.BLACK, "c5", "e5");

        CreateAndAddPiece(typeof(Pawn), "d4", Color.WHITE);
        AssertPieceHintTiles(new string[] { "c5", "d5", "e5" });
    }
}