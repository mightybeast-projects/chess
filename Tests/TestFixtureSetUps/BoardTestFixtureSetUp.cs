using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.TestFixtureSetUps;

[TestFixture]
internal class BoardTestFixtureSetUp
{
    protected Board board;

    [SetUp]
    public void SetUp() => board = new Board();
}