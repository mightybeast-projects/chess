using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Queens;

[TestFixture]
class BlockedPathTets : PieceSetUp
{
    [Test]
    public void QueenHasBlockedDiagonals()
    {
        AddPawns(Color.WHITE, "c4", "e4", "d5", "d3");
        AddPawns(Color.WHITE, "b6", "f6", "b2", "f2");

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c5", "e5", "c3", "e3" });
    }

    [Test]
    public void QueenHasCapturesOnDiagonals()
    {
        AddPawns(Color.WHITE, "c4", "e4", "d5", "d3");
        AddPawns(Color.BLACK, "b6", "f6", "b2", "f2");

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] {
            "c5", "e5", "c3", "e3",
            "b6", "f6", "b2", "f2"
        });
    }

    [Test]
    public void QueenHasBlockedAxises()
    {
        AddPawns(Color.WHITE, "c5", "e5", "c3", "e3");
        AddPawns(Color.WHITE, "b4", "f4", "d6", "d2");

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "d5", "d3", "c4", "e4" });
    }

    [Test]
    public void QueenHasCapturesOnAxises()
    {
        AddPawns(Color.WHITE, "c5", "e5", "c3", "e3");
        AddPawns(Color.BLACK, "b4", "f4", "d6", "d2");

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] {
            "d5", "d3", "c4", "e4",
            "b4", "f4", "d6", "d2"
        });
    }

    private void AddPawns(Color color, params string[] positions)
    {
        foreach (string position in positions)
            CreateAndAddPiece(typeof(Pawn), position, color);
    }
}