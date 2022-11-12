namespace Chess.Core.Pieces;

public class Rook : SlidingPiece
{
    public Rook(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        visitor.VisitRook(this);
    }

    public override void UpdateLegalMoves()
    {
        base.UpdateLegalMoves();

        AddLegalMovesInDirection(1, 0);
        AddLegalMovesInDirection(-1, 0);
        AddLegalMovesInDirection(0, 1);
        AddLegalMovesInDirection(0, -1);
    }
}