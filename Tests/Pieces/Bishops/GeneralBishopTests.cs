using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Bishops;

[TestFixture]
class GeneralBishopTests : PieceTestDataBuilder
{
    [Test]
    public void BishopInitialization()
    {
        CreateAndAddPiece(typeof(Bishop), "d4", Core.Color.WHITE);

        AssertPiece();
    }

    [TestCase(
        "a1", new string[] { "b2", "c3", "d4", "e5", "f6", "g7", "h8" }
    )]

    [TestCase(
        "a8", new string[] { "h1", "g2", "f3", "e4", "d5", "c6", "b7" }
    )]

    [TestCase(
        "h1", new string[] { "g2", "f3", "e4", "d5", "c6", "b7", "a8" }
    )]

    [TestCase(
        "h8", new string[] { "a1", "b2", "c3", "d4", "e5", "f6", "g7" }
    )]
    
    [TestCase(
        "d4",
        new string[] {
            "e5", "f6", "g7", "h8",
            "e3", "f2", "g1",
            "c3", "b2", "a1",
            "c5", "b6", "a7" }
    )]
    [Test]
    public void BishopAtPositionHasHintTiles(
        string bishopPosition,
        string[] hintTiles)
    {
        CreateAndAddPiece(typeof(Bishop), bishopPosition, Color.WHITE);

        AssertPieceHintTiles(hintTiles);
    }
}