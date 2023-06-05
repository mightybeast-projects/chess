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
        if (HintTileIsBeyondTheBoard(currentTile.i + i, currentTile.j + j))
            return;
    
        hintTile = GetClampedHintTile(currentTile.i + i, currentTile.j + j);

        if (hintTile.isEmpty || HintTileIsOccupiedByEnemy())
            _legalMoves.Add(hintTile);
    }
}