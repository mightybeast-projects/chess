namespace Chess.Core.Pieces;

public class Queen : SlidingPiece
{
    public Queen(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        visitor.VisitQueen(this);
    }

    public override void UpdateLegalMoves()
    {
        base.UpdateLegalMoves();

        AddLegalMovesInDirection(1, 1);
        AddLegalMovesInDirection(1, -1);
        AddLegalMovesInDirection(-1, -1);
        AddLegalMovesInDirection(-1, 1);

        AddLegalMovesInDirection(1, 0);
        AddLegalMovesInDirection(-1, 0);
        AddLegalMovesInDirection(0, 1);
        AddLegalMovesInDirection(0, -1);
    }
}