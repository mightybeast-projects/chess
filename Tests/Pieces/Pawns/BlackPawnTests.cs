using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Pawns;

[TestFixture]
class BlackPawnTests : PawnSetUp, IPawnTest
{
    [Test]
    public void PawnInitialization()
    {
        CreateAndAddPiece(typeof(Pawn), "e5", Color.BLACK);
        AssertPiece();
    }

    [Test]
    public void PawnHasOneHintTile()
    {
        CreateAndAssertPawnHintTiles("d5", new string[] { "d4" });
        CreateAndAssertPawnHintTiles("e5", new string[] { "e4" });
    }

    [Test]
    public void PawnHasTwoHintTiles()
    {
        CreateAndAssertPawnHintTiles("d7", new string[] { "d6", "d5" });
        CreateAndAssertPawnHintTiles("e7", new string[] { "e6", "e5" });
    }

    public void PawnHasNoHintsWhenPathBlocked()
    {
        throw new NotImplementedException();
    }

    public void PawnHasOneHintTileAndOneCapture()
    {
        throw new NotImplementedException();
    }

    public void PawnHasOneHintTileAndTwoCaptures()
    {
        throw new NotImplementedException();
    }

    protected override void CreateAndAssertPawnHintTiles(
        string startingPosition,
        string[] hints)
    {
        _color = Color.BLACK;
        base.CreateAndAssertPawnHintTiles(startingPosition, hints);
    }
}