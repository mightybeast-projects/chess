using Chess.Core;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests;

[TestFixture]
internal class StalemateTests : BoardTestFixtureSetUp
{
    [Test]
    public void WhiteKing_IsInStalemate()
    {
        King whiteKing = new King(board.GetTile("h1"), Color.WHITE);

        board.AddPiece(whiteKing);

        board.AddPiece(new King(board.GetTile("a8"), Color.BLACK));
        board.AddPiece(new Queen(board.GetTile("f2"), Color.BLACK));

        Assert.IsTrue(whiteKing.isInStalemate);
    }

    [Test]
    public void BlackKing_IsInStalemate()
    {
        King blackKing = new King(board.GetTile("a8"), Color.BLACK);

        board.AddPiece(new King(board.GetTile("a1"), Color.WHITE));
        board.AddPiece(new Queen(board.GetTile("c7"), Color.WHITE));

        board.AddPiece(blackKing);

        Assert.IsTrue(blackKing.isInStalemate);
    }
}