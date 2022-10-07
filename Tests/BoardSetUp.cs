using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class BoardSetUp
{
    protected Board _board;

    [SetUp]
    public void SetUp()
    {
        _board = new Board();
    }
}