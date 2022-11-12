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
    public void PieceAtPositionHasCorrectLegalMoves(
        string piecePosition,
        string[] legalMoves)
    {
        CreateAndAddPiece(typeof(TPiece), piecePosition, pieceColor);

        AssertPieceLegalMoves(legalMoves);
    }

    [Test, TestCaseSource("blockedPathCases")]
    public void PieceAtPostionHasCorrectLegalMovesWhilePathIsBlocked(
        Color blockerPawnsColor, string[] blockerPawnsPos,
        string piecePos, string[] legalMoves)
    {
        foreach (string pawnPos in blockerPawnsPos)
            CreateAndAddPiece(typeof(Pawn), pawnPos, blockerPawnsColor);
        CreateAndAddPiece(typeof(TPiece), piecePos, pieceColor);

        AssertPieceLegalMoves(legalMoves);
    }
}