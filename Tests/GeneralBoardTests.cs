using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class GeneralBoardTests : BoardSetUp
{
    [Test]
    public void TileInitialization()
    {
        Assert.IsTrue(tile.isEmpty);
        Assert.IsNull(tile.piece);
    }

    [Test]
    public void BoardGridInitialization()
    {
        Assert.IsNotNull(board.grid);
    }

    [Test]
    public void BoardGridLength()
    {
        Assert.AreEqual(8, board.grid.GetLength(0));
        Assert.AreEqual(8, board.grid.GetLength(1));
    }

    [Test]
    public void BoardGridIsTileMatrix()
    {
        Assert.AreEqual(typeof(Tile), board.grid[0, 0].GetType());
    }

    [Test]
    public void ZeroZeroTileIsBlack()
    {
        Assert.AreEqual(Color.BLACK, board.grid[0, 0].color);
    }

    [Test]
    public void ZeroOneTileIsWhite()
    {
        Assert.AreEqual(Color.WHITE, board.grid[0, 1].color);
    }

    [Test]
    public void ZeroSevenTileIsWhite()
    {
        Assert.AreEqual(Color.WHITE, board.grid[0, 7].color);
    }

    [Test]
    public void OneZeroTileIsWhite()
    {
        Assert.AreEqual(Color.WHITE, board.grid[1, 0].color);
    }

    [Test]
    public void FullBoardNotationIsCorrect()
    {
        for (int i = 0; i < board.grid.GetLength(0); i++)
        {
            if (i % 2 == 0)
                AssertPairedLine(i);
            else
                AssertNonPairedLine(i);
        }
    }

    private void AssertPairedLine(int lineIndex)
    {
        for (int i = 0; i < board.grid.GetLength(0); i++)
        {
            if (i % 2 == 0)
                color = Color.BLACK;
            else
                color = Color.WHITE;

            AssertExpectedColor(lineIndex, i);
        }
    }

    private void AssertNonPairedLine(int lineIndex)
    {
        for (int i = 0; i < board.grid.GetLength(0); i++)
        {
            if (i % 2 == 0)
                color = Color.WHITE;
            else
                color = Color.BLACK;

            AssertExpectedColor(lineIndex, i);
        }
    }

    private void AssertExpectedColor(int i, int j) => 
        Assert.AreEqual(color, board.grid[i, j].color);
}