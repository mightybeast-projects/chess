namespace Chess.Core.Pieces;

public class Bishop : SlidingPiece
{
    public Bishop(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitBishop(this);

    internal override void UpdateLegalMoves()
    {
        legalMoves = new List<Tile>();

        AddLegalMovesInDirection(1, 1);
        AddLegalMovesInDirection(1, -1);
        AddLegalMovesInDirection(-1, -1);
        AddLegalMovesInDirection(-1, 1);
    }
}