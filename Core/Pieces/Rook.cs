namespace Chess.Core.Pieces;

public class Rook : SlidingPiece
{
    public Rook(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitRook(this);

    internal override void UpdateLegalMoves()
    {
        legalMovesList = new List<Tile>();

        AddLegalMovesInDirection(1, 0);
        AddLegalMovesInDirection(-1, 0);
        AddLegalMovesInDirection(0, 1);
        AddLegalMovesInDirection(0, -1);
    }
}