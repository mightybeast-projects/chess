using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

abstract class PieceTest : PieceTestDataBuilder
{
    [Test]
    public abstract void PieceInitialization();

    public abstract void PieceHasCorrectLegalMoves_InGeneralCases(
        string piecePosition,
        string[] legalMoves);

    public abstract void PieceHasCorrectLegalMoves_InEdgeCases(
        Color blockerPawnsColor,
        string[] blockerPawnsPos,
        string piecePos,
        string[] legalMoves);
}