using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class BoardNotationTests : BoardSetUp
{
    [Test]
    public void TileIsInMatrix()
    {
        Tile a1 = _board.GetTile("a1");
        Assert.AreEqual(_board.grid[0, 0], a1);
    }

    [Test]
    public void D4TileIsBlack()
    {
        Tile d4 = _board.GetTile("d4");
        Assert.AreEqual(TileColor.BLACK, d4.color);
    }

    [Test]
    public void E4TileIsWhite()
    {
        Tile e4 = _board.GetTile("e4");
        Assert.AreEqual(TileColor.WHITE, e4.color);
    }

    [Test]
    public void FullBoardNotationTest()
    {
        for (int i = 0; i < _board.grid.GetLength(0); i++)
            AssertLineNotation(i);
    }

    private void AssertLineNotation(int index)
    {
        Tile tile;

        for (int i = 0; i < _board.grid.GetLength(0); i++)
        {
            char letter = (char) (i + 65);
            string tileName = letter.ToString().ToLower() + (index + 1);
            tile = _board.GetTile(tileName);
            Assert.AreEqual(_board.grid[index, i], tile);
        }
    }
}