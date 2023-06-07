namespace Chess.Core.Pieces;

public class Bishop : SlidingPiece
{
    public Bishop(Board board, Tile tile, Color color) :
        base(board, tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitBishop(this);

    protected override void UpdateLegalMoves()
    {
        base.UpdateLegalMoves();

        AddLegalMovesInDirection(1, 1);
        AddLegalMovesInDirection(1, -1);
        AddLegalMovesInDirection(-1, -1);
        AddLegalMovesInDirection(-1, 1);
    }
}