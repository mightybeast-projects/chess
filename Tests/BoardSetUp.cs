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
    }

    protected void CreateAndAddPiece(Type pieceType, string tileName, Color color)
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
        _piece = _pieceObj is null ?
            new Piece(_tile, _color) :
            (Piece)_pieceObj;

        _board.AddPiece(_piece);
    }

    protected void AssertPiece()
    {
        Assert.AreEqual(_board, _piece.board);
        Assert.AreEqual(_tile, _piece.tile);
        Assert.AreEqual(_color, _piece.color);
    }
}