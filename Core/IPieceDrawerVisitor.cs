using Chess.Core.Pieces;

namespace Chess.Core;

public interface IPieceDrawerVisitor
{
    void VisitPawn(Piece piece);
    void VisitRook(Piece piece);
    void VisitKnight(Piece piece);
    void VisitBishop(Piece piece);
    void VisitQueen(Piece piece);
    void VisitKing(Piece piece);
}