using Chess.Core;
using Chess.Core.Pieces;
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

    public abstract void PieceHasCorrectLegalMoves(string piecePosition, string[] legalMoves);

    [Test, TestCaseSource("blockedPathCases")]
    public void PieceHasCorrectLegalMovesWhilePathIsBlocked(
        Color blockerPawnsColor, string[] blockerPawnsPos,
        string piecePos, string[] legalMoves)
    {
        foreach (string pawnPos in blockerPawnsPos)
            CreateAndAddPiece(typeof(Pawn), pawnPos, blockerPawnsColor);
        CreateAndAddPiece(typeof(TPiece), piecePos, pieceColor);

        AssertPieceLegalMoves(legalMoves);
    }
}