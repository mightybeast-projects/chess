using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Rooks;

[TestFixture]
class BlockedPathTests : PieceSetUp
{
    [Test]
    public void RookHasBlockedUpperVerticalPath()
    {
        CreateAndAddPiece(typeof(Pawn), "b1", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "a5", Color.WHITE);
        CreateAndAddPiece(typeof(Rook), "a1", Color.WHITE);

        AssertPieceHintTiles(new string[] { "a2", "a3", "a4"});
    }

    [Test]
    public void RookHasBlockedLowerVerticalPath()
    {
        CreateAndAddPiece(typeof(Pawn), "b8", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "a5", Color.WHITE);
        CreateAndAddPiece(typeof(Rook), "a8", Color.WHITE);

        AssertPieceHintTiles(new string[] { "a7", "a6" });
    }

    [Test]
    public void RookHasEnemyOnTheUpperVerticalWay()
    {
        CreateAndAddPiece(typeof(Pawn), "b1", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "a5", Color.BLACK);
        CreateAndAddPiece(typeof(Rook), "a1", Color.WHITE);

        AssertPieceHintTiles(new string[] { "a2", "a3", "a4", "a5"});
    }

    [Test]
    public void RookHasEnemyOnTheLowerVerticalWay()
    {
        CreateAndAddPiece(typeof(Pawn), "b8", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "a5", Color.BLACK);
        CreateAndAddPiece(typeof(Rook), "a8", Color.WHITE);

        AssertPieceHintTiles(new string[] { "a7", "a6", "a5" });
    }

    [Test]
    public void RookHasBlockedRightSideHorizontalPath()
    {
        CreateAndAddPiece(typeof(Pawn), "a2", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "d1", Color.WHITE);
        CreateAndAddPiece(typeof(Rook), "a1", Color.WHITE);

        AssertPieceHintTiles(new string[] { "b1", "c1" });
    }

    [Test]
    public void RookHasBlockedLeftSideHorizontalPath()
    {
        CreateAndAddPiece(typeof(Pawn), "h2", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "d1", Color.WHITE);
        CreateAndAddPiece(typeof(Rook), "h1", Color.WHITE);

        AssertPieceHintTiles(new string[] { "e1", "f1", "g1" });
    }

    [Test]
    public void RookHasEnemyOnRightSideHorizontalWay()
    {
        CreateAndAddPiece(typeof(Pawn), "a2", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "d1", Color.BLACK);
        CreateAndAddPiece(typeof(Rook), "a1", Color.WHITE);

        AssertPieceHintTiles(new string[] { "b1", "c1", "d1" });
    }

    [Test]
    public void RookHasEnemyOnLeftSideHorizontalWay()
    {
        CreateAndAddPiece(typeof(Pawn), "h2", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "d1", Color.BLACK);
        CreateAndAddPiece(typeof(Rook), "h1", Color.WHITE);

        AssertPieceHintTiles(new string[] { "d1", "e1", "f1", "g1" });
    }
}