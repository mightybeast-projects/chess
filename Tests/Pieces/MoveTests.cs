using Chess.Core;
using Chess.Core.Exceptions;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
internal class MoveTests : BoardTestDataBuilder
{
    private List<Tile> preMoveHintTiles;

    [Test]
    public void PieceCanMakeLegalMove()
    {
        Piece piece = CreatePiece(typeof(Pawn), "d2", Color.WHITE);
        preMoveHintTiles = piece.legalMoves;

        piece.Move("d3");

        Assert.IsTrue(board.GetTile("d2").isEmpty);
        Assert.IsNull(board.GetTile("d2").piece);
        Assert.AreEqual(board.GetTile("d3"), piece.tile);
        Assert.IsFalse(board.GetTile("d3").isEmpty);
        Assert.AreEqual(board.GetTile("d3").piece, piece);
        Assert.AreNotEqual(preMoveHintTiles, piece.legalMoves);
    }

    [Test]
    public void PieceThrowsExceptionOnIllegalMove()
    {
        Piece piece = CreatePiece(typeof(Pawn), "d2", Color.WHITE);
        preMoveHintTiles = piece.legalMoves;

        Assert.Throws<IllegalMoveException>(() => piece.Move("a3"));

        Assert.IsFalse(board.GetTile("d2").isEmpty);
        Assert.IsNotNull(board.GetTile("d2").piece);
        Assert.AreNotEqual(board.GetTile("a3"), piece.tile);
        Assert.IsTrue(board.GetTile("a3").isEmpty);
        Assert.AreNotEqual(board.GetTile("a3").piece, piece);
        Assert.AreEqual(preMoveHintTiles, piece.legalMoves);
    }

    [Test]
    public void PieceWillCaptureEnemyIfTargetTileIsOccupiedByThem()
    {
        CreatePiece(typeof(Pawn), "e5", Color.BLACK);
        Piece piece = CreatePiece(typeof(Pawn), "d4", Color.WHITE);

        piece.Move("e5");

        Assert.AreEqual(1, board.whitePieces.Count);
        Assert.AreEqual(0, board.blackPieces.Count);
        Assert.AreEqual(board.GetTile("e5"), piece.tile);
        Assert.AreEqual(board.GetTile("e5").piece, piece);
    }
}