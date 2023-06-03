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

    public abstract void PieceHasCorrectLegalMoves(
        string piecePosition,
        string[] legalMoves);

    public abstract void PieceHasCorrectLegalMovesWhilePathIsBlocked(
        Color blockerPawnsColor,
        string[] blockerPawnsPos,
        string piecePos,
        string[] legalMoves);
}