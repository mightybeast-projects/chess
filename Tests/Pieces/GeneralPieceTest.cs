using Chess.Core;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

abstract class GeneralPieceTest : PieceTestDataBuilder
{
    protected abstract Type pieceType { get; }

    [Test]
    public void PieceInitialization()
    {
        CreateAndAddPiece(pieceType, "d4", Core.Color.WHITE);

        AssertPiece();
    }

    [Test, TestCaseSource("cases")]
    public virtual void PieceAtPositionHasCorrectHintTiles(
        string piecePosition,
        string[] hintTiles)
    {
        CreateAndAddPiece(pieceType, piecePosition, Color.WHITE);

        AssertPieceHintTiles(hintTiles);
    }
}