using Chess.Core;
using Chess.Core.Exceptions;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class BoardNotationTests : BoardSetUp
{
    private char letter;
    private string tileName;

    [TestCase("a1", 0, 0)]
    [TestCase("h1", 0, 7)]
    [TestCase("d4", 3, 3)]
    [Test]
    public void BoardTileHasCorrectNotation(string tileStr, int i, int j)
    {
        Assert.AreEqual(tileStr, board.grid[i, j].notation);
    }

    [Test]
    public void TileIsInBoardGrid()
    {
        AssertBoardTileNotation(0, 0);
    }

    [TestCase("d4")]
    [Test]
    public void TileIsBlack(string tileStr)
    {
        tile = board.GetTile(tileStr);

        Assert.AreEqual(Color.BLACK, tile.color);
    }

    [TestCase("e4")]
    [Test]
    public void TileIsWhite(string tileStr)
    {
        tile = board.GetTile(tileStr);

        Assert.AreEqual(Color.WHITE, tile.color);
    }

    [TestCase("")]
    [TestCase("a")]
    [TestCase("z-4")]
    [TestCase("z9")]
    [Test]
    public void TileHasIncorrectNotation(string tileStr)
    {
        AssertIncorrectTileNotation(tileStr);
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
        letter = (char)(j + 65);
        tileName = letter.ToString().ToLower() + (i + 1);
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