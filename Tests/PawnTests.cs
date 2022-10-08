using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class PawnTests : BoardSetUp
{
    private Pawn _pawn;

    [SetUp]
    public override void SetUp()
    {
        base.SetUp();
        _pawn = new Pawn();
    }

    [Test]
    public void PawnInitializationTest()
    {
        Assert.NotNull(_pawn);
    }

    [Test]
    public void AddPawnToBoardTest()
    {
        _pawn = _board.AddPawn("a1");
        Assert.AreEqual(_board.grid[0, 0], _pawn.tile);
        _pawn = _board.AddPawn("b1");
        Assert.AreEqual(_board.grid[0, 1], _pawn.tile);
    }
}