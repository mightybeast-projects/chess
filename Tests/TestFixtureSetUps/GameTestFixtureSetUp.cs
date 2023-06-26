using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.TestFixtureSetUps;

[TestFixture]
public class GameTestFixtureSetUp
{
    protected Game game;

    [SetUp]
    public void SetUp()
    {
        game = new Game();

        game.Start();
    }
}