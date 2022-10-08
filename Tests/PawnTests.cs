using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class PawnTests : BoardSetUp
{
    [Test]
    public void PawnInitializationTest()
    {
        Pawn pawn = new Pawn();
        Assert.NotNull(pawn);
    }

    [Test]
    public void AddPawnToBoardTest()
    {
        Pawn pawn = _board.AddPawn("a1");
        Assert.AreEqual(_board.grid[0, 0], pawn.tile);
        pawn = _board.AddPawn("b1");
        Assert.AreEqual(_board.grid[0, 1], pawn.tile);
    }
}