using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

internal abstract class PieceTest<TPiece> : PieceTestDataBuilder
    where TPiece : Piece
{
    protected abstract Color pieceColor { get; }

    [Test]
    public void PieceInitialization()
    {
        CreateAndAddPiece(typeof(TPiece), "d4", pieceColor);

        AssertPiece();
    }

    public virtual void PieceHasCorrectLegalMoves_InGeneralCases(
        string piecePosition,
        string[] legalMoves)
    {
        CreateAndAddPiece(typeof(TPiece), piecePosition, pieceColor);

        AssertPieceLegalMoves(legalMoves);
    }

    public virtual void PieceHasCorrectLegalMoves_InEdgeCases(
        Color blockerPawnsColor,
        string[] blockerPawnsPos,
        string piecePos,
        string[] legalMoves)
    {
        foreach (string pawnPos in blockerPawnsPos)
            CreateAndAddPiece(typeof(Pawn), pawnPos, blockerPawnsColor);
        CreateAndAddPiece(typeof(TPiece), piecePos, pieceColor);

        AssertPieceLegalMoves(legalMoves);
    }
}