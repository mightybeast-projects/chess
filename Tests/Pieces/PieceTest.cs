using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

internal abstract class PieceTest<TPiece> : BoardTestDataBuilder
    where TPiece : Piece
{
    protected abstract Color pieceColor { get; }

    [Test]
    public void PieceInitialization()
    {
        Type pieceType = typeof(TPiece);
        string tileNotation = "d4";

        Piece piece = CreatePiece(pieceType, tileNotation, pieceColor);

        AssertPiece(piece, tileNotation);
    }

    public virtual void PieceHasCorrectLegalMoves_InGeneralCases(
        string piecePosition,
        string[] legalMoves)
    {
        Piece piece = CreatePiece(typeof(TPiece), piecePosition, pieceColor);

        AssertPieceLegalMoves(piece, legalMoves);
    }

    public virtual void PieceHasCorrectLegalMoves_InEdgeCases(
        Color blockerPawnsColor,
        string[] blockerPawnsPos,
        string piecePos,
        string[] legalMoves)
    {
        foreach (string pawnPos in blockerPawnsPos)
            CreatePiece(typeof(Pawn), pawnPos, blockerPawnsColor);
        Piece piece = CreatePiece(typeof(TPiece), piecePos, pieceColor);

        AssertPieceLegalMoves(piece, legalMoves);
    }

    private void AssertPiece(Piece piece, string tileNotation)
    {
        Tile pieceTile = board.GetTile(tileNotation);

        Assert.AreEqual(board, piece.board);
        Assert.AreEqual(pieceTile, piece.tile);
        Assert.AreEqual(pieceTile.piece, piece);
        Assert.AreEqual(pieceColor, piece.color);
        Assert.IsFalse(pieceTile.isEmpty);
        if (piece.color == Color.WHITE)
            Assert.IsTrue(board.whitePieces.Contains(piece));
        else
            Assert.IsTrue(board.blackPieces.Contains(piece));
    }

    protected void AssertPieceLegalMoves(Piece piece, string[] legalMoves)
    {
        string[] pieceLegalMoves = new string[piece.legalMoves.Count];
        for (int i = 0; i < piece.legalMoves.Count; i++)
            pieceLegalMoves[i] = piece.legalMoves[i].notation;

        Assert.That(legalMoves, Is.SubsetOf(pieceLegalMoves));
        Assert.AreEqual(legalMoves.Length, pieceLegalMoves.Length);
    }
}