using Chess.Core;
using Chess.Core.Exceptions;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
class MoveTests : BoardTestDataBuilder
{
    private List<Tile> preMoveHintTiles;

    [Test]
    public void PieceCanMakeLegalMove()
    {
        CreateAndAddPiece(typeof(Pawn), "d2", Color.WHITE);
        preMoveHintTiles = piece.hintTiles;

        piece.Move("d3");

        Assert.IsTrue(board.GetTile("d2").isEmpty);
        Assert.IsNull(board.GetTile("d2").piece);
        Assert.AreEqual(board.GetTile("d3"), piece.currentTile);
        Assert.IsFalse(board.GetTile("d3").isEmpty);
        Assert.AreEqual(board.GetTile("d3").piece, piece);
        Assert.AreNotEqual(preMoveHintTiles, piece.hintTiles);
    }

    [Test]
    public void PieceThrowsExceptionOnIllegalMove()
    {
        CreateAndAddPiece(typeof(Pawn), "d2", Color.WHITE);
        preMoveHintTiles = piece.hintTiles;

        Assert.Throws<IllegalMoveException>(
            () => piece.Move("a3")
        );

        Assert.IsFalse(board.GetTile("d2").isEmpty);
        Assert.IsNotNull(board.GetTile("d2").piece);
        Assert.AreNotEqual(board.GetTile("a3"), piece.currentTile);
        Assert.IsTrue(board.GetTile("a3").isEmpty);
        Assert.AreNotEqual(board.GetTile("a3").piece, piece);
        Assert.AreEqual(preMoveHintTiles, piece.hintTiles);
    }

    [Test]
    public void PieceWillCaptureEnemyIfTargetTileIsOccupiedByThem()
    {
        CreateAndAddPiece(typeof(Pawn), "e5", Color.BLACK);
        CreateAndAddPiece(typeof(Pawn), "d4", Color.WHITE);

        piece.Move("e5");

        Assert.AreEqual(1, board.pieces.Count);
        Assert.AreEqual(board.GetTile("e5"), piece.currentTile);
        Assert.AreEqual(board.GetTile("e5").piece, piece);
    }
}