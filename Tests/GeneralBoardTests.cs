using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class GeneralBoardTests : BoardSetUp
{
    private Color evenColor;
    private Color oddColor;
    private int i;
    private int j;

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
    public void BoardSetupIsCorrect()
    {
        board.SetUp();
        Assert.AreEqual(16, board.pieces.Count);

        AssertPawnRow(2);
        AssertPawnRow(7);
    }

    [Test]
    public void BoardTileColorsAreCorrect()
    {
        for (int i = 0; i < board.grid.GetLength(0); i++)
            AssertLine(i);
    }

    private void AssertPawnRow(int rowIndex)
    {
        for (int i = 0; i < board.grid.GetLength(0); i++)
            AssertPawnInRow(i, rowIndex);
    }

    private void AssertPawnInRow(int letterIndex, int rowIndex)
    {
        char letter = (char)(letterIndex+ 65);
        string tileName = letter.ToString().ToLower() + rowIndex;
        tile = board.GetTile(tileName);
        Assert.AreEqual(typeof(Pawn), tile.piece.GetType());
        Assert.IsFalse(tile.isEmpty);
    }

    private void AssertLine(int i)
    {
        this.i = i;

        if (i % 2 == 0)
            AssertLine(Color.BLACK, Color.WHITE);
        else
            AssertLine(Color.WHITE, Color.BLACK);
    }

    private void AssertLine(Color evenColor, Color oddColor)
    {
        this.evenColor = evenColor;
        this.oddColor = oddColor;
        
        for (int j = 0; j < board.grid.GetLength(1); j++)
            AssertPosition(j);
    }

    private void AssertPosition(int j)
    {
        this.j = j;

        if (j % 2 == 0)
            color = evenColor;
        else
            color = oddColor;

        AssertExpectedColor(i, j);
    }

    private void AssertExpectedColor(int i, int j) => 
        Assert.AreEqual(color, board.grid[i, j].color);
}