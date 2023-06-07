using System.Reflection;
using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
internal class BoardTestDataBuilder
{
    protected Board board;

    [SetUp]
    public virtual void SetUp() => board = new Board();

    protected Piece CreatePiece(Type pieceType, string tileName, Color color)
    {
        Tile tile = board.GetTile(tileName);

        Type[] ctorTypes = new[] {
            typeof(Board), typeof(Tile), typeof(Color)
        };
        object[] ctorArgs = new object[] {
            board, tile, color
        };
        
        ConstructorInfo ctor = pieceType.GetConstructor(ctorTypes);
        object pieceObj = ctor?.Invoke(ctorArgs);
        Piece piece = (Piece)pieceObj!;

        board.AddPiece(piece);

        return piece;
    }
}