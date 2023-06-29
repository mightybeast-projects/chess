using Chess.Core;
using Chess.Core.Exceptions;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

[TestFixture]
internal class MoveTests : BoardTestFixtureSetUp
{
    private List<Tile> preMoveLegalMoves;

    [Test]
    public void PieceCanMakeLegalMove()
    {
        Piece piece = new Pawn(board.GetTile("d2"), Color.WHITE);

        board.AddPiece(piece);

        preMoveLegalMoves = piece.legalMoves;

        piece.Move("d3");

        Assert.IsTrue(board.GetTile("d2").isEmpty);
        Assert.IsNull(board.GetTile("d2").piece);
        Assert.AreEqual(board.GetTile("d3"), piece.tile);
        Assert.IsFalse(board.GetTile("d3").isEmpty);
        Assert.AreEqual(board.GetTile("d3").piece, piece);
        Assert.IsTrue(piece.hasMoved);
        Assert.AreNotEqual(piece.legalMoves, preMoveLegalMoves);
    }

    [Test]
    public void PieceThrowsException_OnIllegalMove()
    {
        Piece piece = new Pawn(board.GetTile("d2"), Color.WHITE);

        board.AddPiece(piece);

        preMoveLegalMoves = piece.legalMoves;

        Assert.Throws<IllegalMoveException>(() => piece.Move("a3"));

        Assert.IsFalse(board.GetTile("d2").isEmpty);
        Assert.IsNotNull(board.GetTile("d2").piece);
        Assert.AreNotEqual(board.GetTile("a3"), piece.tile);
        Assert.IsTrue(board.GetTile("a3").isEmpty);
        Assert.AreNotEqual(board.GetTile("a3").piece, piece);
        Assert.IsFalse(piece.hasMoved);
        Assert.AreEqual(preMoveLegalMoves, piece.legalMoves);
    }

    [Test]
    public void PieceWillCaptureEnemy_IfTargetTileIsOccupiedByThem()
    {
        Piece piece = new Pawn(board.GetTile("d4"), Color.WHITE);

        board.AddPiece(piece);
        board.AddPiece(new Pawn(board.GetTile("e5"), Color.BLACK));

        piece.Move("e5");

        Assert.AreEqual(1, board.whitePieces.Count);
        Assert.AreEqual(0, board.blackPieces.Count);
        Assert.AreEqual(board.GetTile("e5"), piece.tile);
        Assert.AreEqual(board.GetTile("e5").piece, piece);
    }
}