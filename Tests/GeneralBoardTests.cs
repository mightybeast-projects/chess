using Chess.Core;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
internal class GeneralBoardTests : BoardTestFixtureSetUp
{
    private Color evenColor;
    private Color oddColor;
    private int i;

    [Test]
    public void TileInitialization()
    {
        Tile tile = new Tile(0, 0, Color.BLACK);

        Assert.IsTrue(tile.isEmpty);
        Assert.IsNull(tile.piece);
    }

    [Test]
    public void BoardGridInitialization() => Assert.IsNotNull(board.grid);

    [Test]
    public void Board_IsEightByEightSquare()
    {
        Assert.AreEqual(8, board.grid.GetLength(0));
        Assert.AreEqual(8, board.grid.GetLength(1));
    }

    [Test(ExpectedResult = typeof(Tile))]
    public Type BoardGrid_IsTileMatrix() => board.grid[0, 0].GetType();

    [Test, TestCaseSource(nameof(tileColorCases))]
    public Color Tile_HasCorrectColor(int i, int j) => board.grid[i, j].color;

    [Test]
    public void Board_ColorsAreCorrect()
    {
        for (int i = 0; i < board.grid.GetLength(0); i++)
            AssertLine(i);
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
        Color color;

        if (j % 2 == 0)
            color = evenColor;
        else
            color = oddColor;

        Assert.AreEqual(color, board.grid[i, j].color);
    }

    private static TestCaseData[] tileColorCases =
    {
        new TestCaseData(0, 0).Returns(Color.BLACK),
        new TestCaseData(0, 1).Returns(Color.WHITE),
        new TestCaseData(1, 0).Returns(Color.WHITE),
        new TestCaseData(7, 0).Returns(Color.WHITE),
        new TestCaseData(6, 0).Returns(Color.BLACK),
        new TestCaseData(7, 1).Returns(Color.BLACK),
    };
}