using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

abstract class PieceTest<TPiece> : PieceTestDataBuilder
{
    protected abstract Color pieceColor { get; }

    [Test]
    public void PieceInitialization()
    {
        CreateAndAddPiece(typeof(TPiece), "d4", pieceColor);

        AssertPiece();
    }

    [Test, TestCaseSource("generalCases")]
    public void PieceAtPositionHasCorrectHintTiles(
        string piecePosition,
        string[] hintTiles)
    {
        CreateAndAddPiece(typeof(TPiece), piecePosition, pieceColor);

        AssertPieceHintTiles(hintTiles);
    }

    [Test, TestCaseSource("blockedPathCases")]
    public void PieceAtPostionHasCorrectHintTilesWhilePathIsBlocked(
        Color blockerPawnsColor, string[] blockerPawnsPos,
        string piecePos, string[] hintTiles)
    {
        foreach (string pawnPos in blockerPawnsPos)
            CreateAndAddPiece(typeof(Pawn), pawnPos, blockerPawnsColor);
        CreateAndAddPiece(typeof(TPiece), piecePos, pieceColor);

        AssertPieceHintTiles(hintTiles);
    }
}