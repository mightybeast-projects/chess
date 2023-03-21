using Chess.Core;
using Chess.Core.Exceptions;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class BoardNotationTests : BoardTestDataBuilder
{
    private char letter;
    private string tileName;

    [Test]
    public void TileIsInBoardGrid() => AssertBoardTileNotation(0, 0);

    [Test, TestCaseSource(nameof(tileColorCases))]
    public Color TestTileColor(string tileStr) => 
        board.GetTile(tileStr).color;

    [Test, TestCaseSource(nameof(correctTileNotationCases))]
    public string BoardTileHasCorrectNotation(int i, int j) =>
        board.grid[i, j].notation;

    [Test, TestCaseSource(nameof(incorrectTileNotationCases))]
    public void TileHasIncorrectNotation(string tileStr) =>
        AssertIncorrectTileNotation(tileStr);

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

    private void AssertIncorrectTileNotation(string notation) =>
        Assert.Throws<IncorrectTileNotationException>(
            () => board.GetTile(notation)
        );

    private static TestCaseData[] tileColorCases =
    {
        new TestCaseData("d4").Returns(Color.BLACK),
        new TestCaseData("c3").Returns(Color.BLACK),
        new TestCaseData("e4").Returns(Color.WHITE),
        new TestCaseData("d3").Returns(Color.WHITE)
    };

    private static TestCaseData[] correctTileNotationCases =
    {
        new TestCaseData(0, 0).Returns("a1"),
        new TestCaseData(0, 7).Returns("h1"),
        new TestCaseData(3, 3).Returns("d4")
    };

    private static TestCaseData[] incorrectTileNotationCases =
    {
        new TestCaseData(""),
        new TestCaseData("a"),
        new TestCaseData("z-4"),
        new TestCaseData("z9"),
    };
}