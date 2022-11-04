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
        CreateAndAddPiece(typeof(Pawn), "b6", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "f6", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "b2", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "f2", Color.WHITE);

        BlockQueenAxises();

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "c5", "e5", "c3", "e3" });
    }

    [Test]
    public void QueenHasCapturesOnDiagonals()
    {
        CreateAndAddPiece(typeof(Pawn), "b6", Color.BLACK);
        CreateAndAddPiece(typeof(Pawn), "f6", Color.BLACK);
        CreateAndAddPiece(typeof(Pawn), "b2", Color.BLACK);
        CreateAndAddPiece(typeof(Pawn), "f2", Color.BLACK);

        BlockQueenAxises();

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] {
            "c5", "e5", "c3", "e3",
            "b6", "f6", "b2", "f2"
        });
    }

    [Test]
    public void QueenHasBlockedAxises()
    {
        BlockQueenDiagonals();

        CreateAndAddPiece(typeof(Pawn), "b4", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "f4", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "d6", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "d2", Color.WHITE);

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] { "d5", "d3", "c4", "e4" });
    }

    [Test]
    public void QueenHasCapturesOnAxises()
    {
        BlockQueenDiagonals();

        CreateAndAddPiece(typeof(Pawn), "b4", Color.BLACK);
        CreateAndAddPiece(typeof(Pawn), "f4", Color.BLACK);
        CreateAndAddPiece(typeof(Pawn), "d6", Color.BLACK);
        CreateAndAddPiece(typeof(Pawn), "d2", Color.BLACK);

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] {
            "d5", "d3", "c4", "e4",
            "b4", "f4", "d6", "d2"
        });
    }

    private void BlockQueenAxises()
    {
        CreateAndAddPiece(typeof(Pawn), "c4", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "e4", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "d5", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "d3", Color.WHITE);
    }

    private void BlockQueenDiagonals()
    {
        CreateAndAddPiece(typeof(Pawn), "c5", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "e5", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "c3", Color.WHITE);
        CreateAndAddPiece(typeof(Pawn), "e3", Color.WHITE);
    }
}