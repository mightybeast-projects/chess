using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
public class PawnTests
{
    [Test]
    public void InitializationTest()
    {
        Pawn pawn = new Pawn();
        Assert.NotNull(pawn);
    }
}