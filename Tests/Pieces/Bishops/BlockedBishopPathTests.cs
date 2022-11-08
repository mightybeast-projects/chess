using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Bishops;

[TestFixture]
class BlockedBishopPathTests : PieceTestDataBuilder
{
    [TestCase(
        new string[] { "c3", "c5", "e3" },
        "f6", Color.WHITE,
        "d4",
        new string[] { "e5" }
    )]

    [TestCase(
        new string[] { "c3", "c5", "e3" },
        "f6", Color.BLACK,
        "d4",
        new string[] { "e5", "f6" }
    )]

    [TestCase(
        new string[] { "e5", "c5", "e3" },
        "b2", Color.WHITE,
        "d4",
        new string[] { "c3" }
    )]

    [TestCase(
        new string[] { "e5", "c5", "e3" },
        "b2", Color.BLACK,
        "d4",
        new string[] { "c3", "b2" }
    )]

    [TestCase(
        new string[] { "e5", "c3", "e3" },
        "b6", Color.WHITE,
        "d4",
        new string[] { "c5" }
    )]

    [TestCase(
        new string[] { "e5", "c3", "e3" },
        "b6", Color.BLACK,
        "d4",
        new string[] { "b6", "c5" }
    )]

    [TestCase(
        new string[] { "e5", "c3", "c5" },
        "f2", Color.WHITE,
        "d4",
        new string[] { "e3" }
    )]

    [TestCase(
        new string[] { "e5", "c3", "c5" },
        "f2", Color.BLACK,
        "d4",
        new string[] { "e3", "f2" }
    )]

    [Test]
    public void BishopHasCorrectHintTilesWhilePathIsBlocked(
        string[] pawnsPos,
        string blockerPawnPos, Color blockerPawnColor,
        string bishopPos,
        string[] hintTiles)
    {
        foreach (string pawnPos in pawnsPos)
            CreateAndAddPiece(typeof(Pawn), pawnPos, Color.WHITE);

        CreateAndAddPiece(typeof(Pawn), blockerPawnPos, blockerPawnColor);
        CreateAndAddPiece(typeof(Bishop), bishopPos, Color.WHITE);

        AssertPieceHintTiles(hintTiles);
    }
}