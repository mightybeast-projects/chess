using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
class MoveTests : BoardSetUp
{
    private List<Tile> firstHintTiles;

    [Test]
    public void CorrectlyMovePiece()
    {
        CreateAndAddPiece(typeof(Pawn), "d2", Color.WHITE);
        firstHintTiles = piece.hintTiles;

        piece.Move("d3");

        Assert.IsTrue(board.GetTile("d2").isEmpty);
        Assert.IsNull(board.GetTile("d2").piece);
        Assert.AreEqual(board.GetTile("d3"), piece.currentTile);
        Assert.IsFalse(board.GetTile("d3").isEmpty);
        Assert.AreEqual(board.GetTile("d3").piece, piece);
        Assert.AreNotEqual(firstHintTiles, piece.hintTiles);
    }

    [Test]
    public void IncorrectlyMovePiece()
    {
        CreateAndAddPiece(typeof(Pawn), "d2", Color.WHITE);
        firstHintTiles = piece.hintTiles;

        Assert.Throws<WrongMoveException>(
            () => piece.Move("a3")
        );

        Assert.IsFalse(board.GetTile("d2").isEmpty);
        Assert.IsNotNull(board.GetTile("d2").piece);
        Assert.AreNotEqual(board.GetTile("a3"), piece.currentTile);
        Assert.IsTrue(board.GetTile("a3").isEmpty);
        Assert.AreNotEqual(board.GetTile("a3").piece, piece);
        Assert.AreEqual(firstHintTiles, piece.hintTiles);
    }

    [Test]
    public void CaptureEnemyPiece()
    {
        Piece d4Piece, e5Piece;
        d4Piece = CreateAndAddPiece(typeof(Pawn), "d4", Color.WHITE);
        e5Piece = CreateAndAddPiece(typeof(Pawn), "e5", Color.BLACK);

        d4Piece.Move("e5");

        Assert.AreEqual(1, board.pieces.Count);
        Assert.AreEqual(board.GetTile("e5"), d4Piece.currentTile);
        Assert.AreEqual(board.GetTile("e5").piece, d4Piece);
        Assert.IsFalse(board.pieces.Contains(e5Piece));
    }
}