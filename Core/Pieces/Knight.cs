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
        TryToAddLegalMove(2, -1);
        TryToAddLegalMove(2, 1);
    }

    private void AddRightLegalMoves()
    {
        TryToAddLegalMove(1, 2);
        TryToAddLegalMove(-1, 2);
    }

    private void AddBottomLegalMoves()
    {
        TryToAddLegalMove(-2, -1);
        TryToAddLegalMove(-2, 1);
    }

    private void AddLeftLegalMoves()
    {
        TryToAddLegalMove(1, -2);
        TryToAddLegalMove(-1, -2);
    }

    protected override void AddLegalMove(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (hintTile.isEmpty || HintTileIsOccupiedByEnemy())
            legalMovesField.Add(hintTile);
    }
}