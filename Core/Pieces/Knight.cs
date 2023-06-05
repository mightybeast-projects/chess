namespace Chess.Core.Pieces;

public class Knight : Piece
{
    public Knight(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitKnight(this);

    protected override void UpdateLegalMoves()
    {
        base.UpdateLegalMoves();

        AddTopLegalMoves();
        AddRightLegalMoves();
        AddBottomLegalMoves();
        AddLeftLegalMoves();
    }

    private void AddTopLegalMoves()
    {
        AddLegalMove(2, -1);
        AddLegalMove(2, 1);
    }

    private void AddRightLegalMoves()
    {
        AddLegalMove(1, 2);
        AddLegalMove(-1, 2);
    }

    private void AddBottomLegalMoves()
    {
        AddLegalMove(-2, -1);
        AddLegalMove(-2, 1);
    }

    private void AddLeftLegalMoves()
    {
        AddLegalMove(1, -2);
        AddLegalMove(-1, -2);
    }

    protected override void AddLegalMove(int i, int j)
    {
        if (currentTile.i + i < 0 ||
            currentTile.i + i > board.grid.GetLength(0) - 1 ||
            currentTile.j + j < 0 ||
            currentTile.j + j  > board.grid.GetLength(0) - 1)
                return;

        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (hintTile.isEmpty || HintTileIsOccupiedByEnemy())
            _legalMoves.Add(hintTile);
    }
}