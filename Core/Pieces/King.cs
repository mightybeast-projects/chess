namespace Chess.Core.Pieces;

public class King : Piece
{
    public King(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitKing(this);

    protected override void UpdateLegalMoves()
    {
        base.UpdateLegalMoves();

        AddDiagonalLegalMoves();
        AddAxisLegalMoves();
    }

    private void AddDiagonalLegalMoves()
    {
        TryToAddLegalMove(1, -1);
        TryToAddLegalMove(1, 1);
        TryToAddLegalMove(-1, 1);
        TryToAddLegalMove(-1, -1);
    }

    private void AddAxisLegalMoves()
    {
        TryToAddLegalMove(1, 0);
        TryToAddLegalMove(0, 1);
        TryToAddLegalMove(-1, 0);
        TryToAddLegalMove(0, -1);
    }

    protected override void AddLegalMove(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (hintTile.isEmpty || HintTileIsOccupiedByEnemy())
            _legalMoves.Add(hintTile);
    }
}