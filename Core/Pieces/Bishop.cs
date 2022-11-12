namespace Chess.Core.Pieces;

public class Bishop : SlidingPiece
{
    public Bishop(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        visitor.VisitBishop(this);
    }

    protected override void UpdateLegalMoves()
    {
        base.UpdateLegalMoves();

        AddLegalMovesInDirection(1, 1);
        AddLegalMovesInDirection(1, -1);
        AddLegalMovesInDirection(-1, -1);
        AddLegalMovesInDirection(-1, 1);
    }
}