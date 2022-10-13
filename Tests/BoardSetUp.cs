using System.Reflection;
using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class BoardSetUp
{
    protected Board _board;
    protected Piece _piece;
    protected Tile _tile;
    protected Color _color;

    private ConstructorInfo? _ctor;
    private object? _pieceObj;
    private Type[] _ctorTypes;
    private object[] _ctorArgs;

    [SetUp]
    public virtual void SetUp()
    {
        _board = new Board();
        _tile = new Tile(0, 0, Color.BLACK);
    }

    protected Piece CreateAndAddPiece(Type pieceType, string tileName, Color color)
    {
        _tile = _board.GetTile(tileName);
        _color = color;

        _ctorTypes = new[] {
            typeof(Tile), typeof(Color)
        };
        _ctorArgs = new object[] {
            _tile, _color
        };
        _ctor = pieceType.GetConstructor(_ctorTypes);
        _pieceObj = _ctor?.Invoke(_ctorArgs);
        _piece = (Piece)_pieceObj!;

        return _board.AddPiece(_piece);
    }

    protected void AssertPiece()
    {
        Assert.AreEqual(_board, _piece.board);
        Assert.AreEqual(_tile, _piece.currentTile);
        Assert.AreEqual(_tile.piece, _piece);
        Assert.AreEqual(_color, _piece.color);
        Assert.IsFalse(_board.GetTile(_tile.notation).isEmpty);
    }
}