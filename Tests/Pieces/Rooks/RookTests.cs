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
    public void RookHasUpperVerticalHintTiles()
    {
        CreateAndAddPiece(typeof(Rook), "a1", Color.WHITE);
        AssertPieceHintTiles(
            new string[] { "a2", "a3", "a4", "a5", "a6", "a7", "a8" });
    }

    [Test]
    public void RookHasLowerVerticalHintTiles()
    {
        CreateAndAddPiece(typeof(Rook), "a8", Color.WHITE);
        AssertPieceHintTiles(
            new string[] { "a1", "a2", "a3", "a4", "a5", "a6", "a7" });
    }

    [Test]
    public void RookHasCorrectVerticalHintTiles()
    {
        CreateAndAddPiece(typeof(Rook), "a5", Color.WHITE);
        AssertPieceHintTiles(
            new string[] { "a1", "a2", "a3", "a4", "a6", "a7", "a8" });
    }

    [Test]
    public void RookHasBlockedUpperVerticalPath()
    {
        CreateAndAddPiece(typeof(Pawn), "a5", Color.WHITE);
        CreateAndAddPiece(typeof(Rook), "a1", Color.WHITE);
        AssertPieceHintTiles(
            new string[] { "a2", "a3", "a4"});
    }

    [Test]
    public void RookHasBlockedLowerVerticalPath()
    {
        CreateAndAddPiece(typeof(Pawn), "a5", Color.WHITE);
        CreateAndAddPiece(typeof(Rook), "a8", Color.WHITE);
        AssertPieceHintTiles(
            new string[] { "a7", "a6" });
    }

    [Test]
    public void RookHasEnemyOnTheUpperVerticalWay()
    {
        CreateAndAddPiece(typeof(Pawn), "a5", Color.BLACK);
        CreateAndAddPiece(typeof(Rook), "a1", Color.WHITE);
        AssertPieceHintTiles(
            new string[] { "a2", "a3", "a4", "a5"});
    }

    [Test]
    public void RookHasEnemyOnTheLowerVerticalWay()
    {
        CreateAndAddPiece(typeof(Pawn), "a5", Color.BLACK);
        CreateAndAddPiece(typeof(Rook), "a8", Color.WHITE);
        AssertPieceHintTiles(
            new string[] { "a7", "a6", "a5" });
    }
}