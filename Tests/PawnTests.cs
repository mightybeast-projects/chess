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

    [Test]
    public void WhitePawnMovement()
    {
        CreateAndAddPiece(typeof(Pawn), "a2", Color.WHITE);
        _tile = _board.GetTile("a3");
        
        Assert.Contains(_tile, _piece.hints);
    }
}