using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

abstract class PieceTest : PieceTestDataBuilder
{
    protected abstract Type pieceType { get; }

    [Test]
    public void PieceInitialization()
    {
        CreateAndAddPiece(pieceType, "d4", Core.Color.WHITE);

        AssertPiece();
    }

    [Test, TestCaseSource("generalCases")]
    public virtual void PieceAtPositionHasCorrectHintTiles(
        string piecePosition,
        string[] hintTiles)
    {
        CreateAndAddPiece(pieceType, piecePosition, Color.WHITE);

        AssertPieceHintTiles(hintTiles);
    }

    [Test, TestCaseSource("blockedPathCases")]
    public void PieceAtPostionHasCorrectHintTilesWhilePathIsBlocked(
        Color blockerPawnsColor, string[] blockerPawnsPos,
        string piecePos, string[] hintTiles)
    {
        foreach (string pawnPos in blockerPawnsPos)
            CreateAndAddPiece(typeof(Pawn), pawnPos, blockerPawnsColor);
        CreateAndAddPiece(pieceType, piecePos, Color.WHITE);

        AssertPieceHintTiles(hintTiles);
    }
}