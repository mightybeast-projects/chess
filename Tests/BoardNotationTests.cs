using Chess.Core;
using Chess.Core.Exceptions;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class BoardNotationTests : BoardSetUp
{
    [Test]
    public void BoardTileHasCorrectNotation()
    {
        Assert.AreEqual("a1", board.grid[0, 0].notation);
        Assert.AreEqual("h1", board.grid[0, 7].notation);
        Assert.AreEqual("d4", board.grid[3, 3].notation);
    }

    [Test]
    public void TileIsInBoardGrid()
    {
        AssertBoardTileNotation(0, 0);
    }

    [Test]
    public void D4TileIsBlack()
    {
        tile = board.GetTile("d4");
        Assert.AreEqual(Color.BLACK, tile.color);
    }

    [Test]
    public void E4TileIsWhite()
    {
        tile = board.GetTile("e4");
        Assert.AreEqual(Color.WHITE, tile.color);
    }

    [Test]
    public void IncorrectTileNotation()
    {
        AssertIncorrectTileNotation("");
        AssertIncorrectTileNotation("a");
        AssertIncorrectTileNotation("z-4");
        AssertIncorrectTileNotation("z9");
    }

    [Test]
    public void BoardHasCorrectNotation()
    {
        for (int i = 0; i < board.grid.GetLength(0); i++)
            for (int j = 0; j < board.grid.GetLength(1); j++)
                AssertBoardTileNotation(i, j);
    }

    private void AssertBoardTileNotation(int i, int j)
    {
        char letter = (char)(j + 65);
        string tileName = letter.ToString().ToLower() + (i + 1);
        tile = board.GetTile(tileName);
        Assert.AreEqual(board.grid[i, j], tile);
    }

    private void AssertIncorrectTileNotation(string notation)
    {
        Assert.Throws<IncorrectTileNotationException>(
            () => board.GetTile(notation)
        );
    }
}