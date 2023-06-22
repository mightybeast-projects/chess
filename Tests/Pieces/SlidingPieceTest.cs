using Chess.Core.Pieces;

namespace Chess.Tests.Pieces;

internal abstract class SlidingPieceTest<TSlidingPiece> : PieceTest<TSlidingPiece>
    where TSlidingPiece : SlidingPiece
{
    public virtual void SlidingPieceHasCorrectTilesUnderAttack(
        string piecePosition,
        string[] tilesUnderAttack,
        string[] blockerPawnsPos)
    {
        Piece slidingPiece =
            CreatePiece(typeof(TSlidingPiece), piecePosition, pieceColor);
        foreach (string pawnPos in blockerPawnsPos)
            CreatePiece(typeof(Pawn), pawnPos, pieceColor);

        AssertPieceTilesUnderAttack(slidingPiece, tilesUnderAttack);
    }
}