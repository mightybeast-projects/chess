using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

abstract class PieceTest<TPiece> : PieceTestDataBuilder
{
    [Test]
    public void PieceInitialization()
    {
        CreateAndAddPiece(typeof(TPiece), "d4", Core.Color.WHITE);

        AssertPiece();
    }

    [Test, TestCaseSource("generalCases")]
    public virtual void PieceAtPositionHasCorrectHintTiles(
        string piecePosition,
        string[] hintTiles)
    {
        CreateAndAddPiece(typeof(TPiece), piecePosition, Color.WHITE);

        AssertPieceHintTiles(hintTiles);
    }

    [Test, TestCaseSource("blockedPathCases")]
    public void PieceAtPostionHasCorrectHintTilesWhilePathIsBlocked(
        Color blockerPawnsColor, string[] blockerPawnsPos,
        string piecePos, string[] hintTiles)
    {
        foreach (string pawnPos in blockerPawnsPos)
            CreateAndAddPiece(typeof(Pawn), pawnPos, blockerPawnsColor);
        CreateAndAddPiece(typeof(TPiece), piecePos, Color.WHITE);

        AssertPieceHintTiles(hintTiles);
    }
}