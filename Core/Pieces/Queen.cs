namespace Chess.Core.Pieces;

public class Queen : SlidingPiece
{
    public Queen(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitQueen(this);

    internal override void UpdateLegalMoves()
    {
        legalMovesList = new List<Tile>();

        AddDiagonalLegalMoves();
        AddAxisLegalMoves();
    }

    private void AddDiagonalLegalMoves()
    {
        AddLegalMovesInDirection(1, 1);
        AddLegalMovesInDirection(1, -1);
        AddLegalMovesInDirection(-1, -1);
        AddLegalMovesInDirection(-1, 1);
    }

    private void AddAxisLegalMoves()
    {
        AddLegalMovesInDirection(1, 0);
        AddLegalMovesInDirection(-1, 0);
        AddLegalMovesInDirection(0, 1);
        AddLegalMovesInDirection(0, -1);
    }
}