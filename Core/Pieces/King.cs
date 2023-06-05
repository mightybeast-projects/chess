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
        AddLegalMove(1, -1);
        AddLegalMove(1, 1);
        AddLegalMove(-1, 1);
        AddLegalMove(-1, -1);
    }

    private void AddAxisLegalMoves()
    {
        AddLegalMove(1, 0);
        AddLegalMove(0, 1);
        AddLegalMove(-1, 0);
        AddLegalMove(0, -1);
    }

    protected override void AddLegalMove(int i, int j)
    {
        if (currentTile.i + i < 0 ||
            currentTile.i + i > board.grid.GetLength(0) - 1 ||
            currentTile.j + j < 0 ||
            currentTile.j + j  > board.grid.GetLength(0) - 1)
                return;

        int clampedI = Math.Clamp(currentTile.i + i, 0, board.grid.GetLength(0) - 1);
        int clampedJ = Math.Clamp(currentTile.j + j, 0, board.grid.GetLength(0) - 1);

        hintTile = board.grid[clampedI, clampedJ];

        if (hintTile.isEmpty || HintTileIsOccupiedByEnemy())
            _legalMoves.Add(hintTile);
    }
}