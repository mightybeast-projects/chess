using Chess.Core;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests;

[TestFixture]
internal class StalemateTests : BoardTestFixtureSetUp
{
    private King king;

    [Test]
    public void WhiteKing_IsInStalemate()
    {
        king = new King(board.GetTile("h1"), Color.WHITE);

        board.AddPiece(king);
        board.AddPiece(new Queen(board.GetTile("f2"), Color.BLACK));

        Assert.IsTrue(king.isInStalemate);
    }

    [Test]
    public void BlackKing_IsInStalemate()
    {
        king = new King(board.GetTile("a8"), Color.BLACK);

        board.AddPiece(new Queen(board.GetTile("c7"), Color.WHITE));
        board.AddPiece(king);

        Assert.IsTrue(king.isInStalemate);
    }
}