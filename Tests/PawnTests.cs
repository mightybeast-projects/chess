using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests;

[TestFixture]
class PawnTests : BoardSetUp
{
    [Test]
    public void PawnInitialization()
    {
        CreateAndAddPiece(typeof(Pawn), "d4", Color.WHITE);
        AssertPiece();
    }
}