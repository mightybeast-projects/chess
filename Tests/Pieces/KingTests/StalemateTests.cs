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
        board.AddPiece(new King(board.GetTile("h1"), Color.WHITE));
        board.AddPiece(new Queen(board.GetTile("f2"), Color.BLACK));

        Assert.IsTrue(board.whiteKing.isInStalemate);
    }

    [Test]
    public void BlackKing_IsInStalemate()
    {
        board.AddPiece(new Queen(board.GetTile("c7"), Color.WHITE));
        board.AddPiece(new King(board.GetTile("a8"), Color.BLACK));

        Assert.IsTrue(board.blackKing.isInStalemate);
    }
}