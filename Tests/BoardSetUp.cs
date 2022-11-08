using System.Reflection;
using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class BoardSetUp
{
    protected Board board;
    protected Piece piece;
    protected Tile tile;
    protected Color color;

    private ConstructorInfo? ctor;
    private object? pieceObj;
    private Type[] ctorTypes;
    private object[] ctorArgs;

    [SetUp]
    public virtual void SetUp()
    {
        board = new Board();
        tile = new Tile(0, 0, Color.BLACK);
    }

    protected void CreateAndAddPiece(
        Type pieceType, 
        string tileName, 
        Color color)
    {
        this.color = color;
        tile = board.GetTile(tileName);
        ctorTypes = new[] {
            typeof(Tile), typeof(Color)
        };
        ctorArgs = new object[] {
            tile, this.color
        };
        ctor = pieceType.GetConstructor(ctorTypes);
        pieceObj = ctor?.Invoke(ctorArgs);
        piece = (Piece)pieceObj!;

        board.AddPiece(piece);
    }

    protected void AssertPiece()
    {
        Assert.AreEqual(board, piece.board);
        Assert.AreEqual(tile, piece.currentTile);
        Assert.AreEqual(tile.piece, piece);
        Assert.AreEqual(color, piece.color);
        Assert.IsFalse(board.GetTile(tile.notation).isEmpty);
        Assert.IsTrue(board.pieces.Contains(piece));
    }
}