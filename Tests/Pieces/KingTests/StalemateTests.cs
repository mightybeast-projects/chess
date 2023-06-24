using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests;

[TestFixture]
public class StalemateTests
{
    [Test]
    public void WhiteKing_IsInStalemate()
    {
        Board board = new Board();

        King whiteKing = new King(board.GetTile("h1"), Color.WHITE);

        board.AddPiece(whiteKing);

        board.AddPiece(new King(board.GetTile("a8"), Color.BLACK));
        board.AddPiece(new Queen(board.GetTile("f2"), Color.BLACK));

        Assert.IsTrue(whiteKing.isInStalemate);
    }

    [Test]
    public void BlackKing_IsInStalemate()
    {
        Board board = new Board();

        King blackKing = new King(board.GetTile("a8"), Color.BLACK);

        board.AddPiece(new King(board.GetTile("a1"), Color.WHITE));
        board.AddPiece(new Queen(board.GetTile("c7"), Color.WHITE));

        board.AddPiece(blackKing);

        Assert.IsTrue(blackKing.isInStalemate);
    }
}