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

        CreateAndAddPiece(typeof(Queen), "d4", Color.WHITE);

        AssertPieceHintTiles(new string[] {
            "c5", "e5", "c3", "e3",
            "b6", "f6", "b2", "f2"
        });
    }
}