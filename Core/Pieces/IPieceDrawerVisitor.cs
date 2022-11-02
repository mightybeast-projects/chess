namespace Chess.Core.Pieces;

public interface IPieceDrawerVisitor
{
    void VisitPawn(Piece piece);
    void VisitRook(Piece piece);
    void VisitKnight(Piece piece);
    void VisitBishop(Piece piece);
}