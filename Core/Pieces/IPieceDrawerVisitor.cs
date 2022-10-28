namespace Chess.Core.Pieces;

public interface IPieceDrawerVisitor
{
    void VisitPawn(Piece piece);
    void VisitRook(Piece piece);
}