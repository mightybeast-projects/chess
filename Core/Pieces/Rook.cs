namespace Chess.Core.Pieces;

public class Rook : SlidingPiece
{
    public Rook(Board board, Tile tile, Color color) :
        base(board, tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitRook(this);

    protected override void UpdateLegalMoves()
    {
        base.UpdateLegalMoves();

        AddLegalMovesInDirection(1, 0);
        AddLegalMovesInDirection(-1, 0);
        AddLegalMovesInDirection(0, 1);
        AddLegalMovesInDirection(0, -1);
    }
}