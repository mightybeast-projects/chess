using Chess.Core;
using Chess.Core.Exceptions;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
internal class BoardNotationTests : BoardTestFixtureSetUp
{
    [Test]
    public void Board_ContainsTile() => AssertTileNotation(0, 0);

    [TestCaseSource(nameof(correctTileNotationCases))]
    public string Tile_HasCorrectNotation(int i, int j) =>
        board.grid[i, j].notation;

    [TestCaseSource(nameof(incorrectTileNotationCases))]
    public void Tile_HasIncorrectNotation(string tileStr) =>
        AssertIncorrectTileNotation(tileStr);

    [Test]
    public void Board_HasCorrectNotation()
    {
        for (int i = 0; i < board.grid.GetLength(0); i++)
            for (int j = 0; j < board.grid.GetLength(1); j++)
                AssertTileNotation(i, j);
    }

    private void AssertTileNotation(int i, int j)
    {
        char letter = (char)(j + 65);
        string tileName = letter.ToString().ToLower() + (i + 1);
        Tile tile = board.GetTile(tileName);

        Assert.AreEqual(board.grid[i, j], tile);
    }

    private void AssertIncorrectTileNotation(string notation) =>
        Assert.Throws<IncorrectTileNotationException>(
            () => board.GetTile(notation)
        );

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