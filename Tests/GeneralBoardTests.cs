using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class GeneralBoardTests : BoardSetUp
{
    private Color _expectedColor;

    [Test]
    public void BoardGridInitialization()
    {
        Assert.IsNotNull(_board.grid);
    }

    [Test]
    public void BoardGridLength()
    {
        Assert.AreEqual(8, _board.grid.GetLength(0));
        Assert.AreEqual(8, _board.grid.GetLength(1));
    }

    [Test]
    public void BoardGridIsTileMatrix()
    {
        Assert.AreEqual(typeof(Tile), _board.grid[0, 0].GetType());
    }

    [Test]
    public void ZeroZeroTileIsBlack()
    {
        Assert.AreEqual(Color.BLACK, _board.grid[0, 0].color);
    }

    [Test]
    public void ZeroOneTileIsWhite()
    {
        Assert.AreEqual(Color.WHITE, _board.grid[0, 1].color);
    }

    [Test]
    public void ZeroSevenTileIsWhite()
    {
        Assert.AreEqual(Color.WHITE, _board.grid[0, 7].color);
    }

    [Test]
    public void OneZeroTileIsWhite()
    {
        Assert.AreEqual(Color.WHITE, _board.grid[1, 0].color);
    }

    [Test]
    public void FullBoardTest()
    {
        for (int i = 0; i < _board.grid.GetLength(0); i++)
        {
            if (i % 2 == 0)
                AssertPairedLine(i);
            else
                AssertNonPairedLine(i);
        }
    }

    private void AssertPairedLine(int lineIndex)
    {
        for (int i = 0; i < _board.grid.GetLength(0); i++)
        {
            if (i % 2 == 0)
                _expectedColor = Color.BLACK;
            else
                _expectedColor = Color.WHITE;

            AssertExpectedColor(lineIndex, i);
        }
    }

    private void AssertNonPairedLine(int lineIndex)
    {
        for (int i = 0; i < _board.grid.GetLength(0); i++)
        {
            if (i % 2 == 0)
                _expectedColor = Color.WHITE;
            else
                _expectedColor = Color.BLACK;

            AssertExpectedColor(lineIndex, i);
        }
    }

    private void AssertExpectedColor(int i, int j) => 
        Assert.AreEqual(_expectedColor, _board.grid[i, j].color);
}