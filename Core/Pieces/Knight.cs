namespace Chess.Core.Pieces;

public class Knight : Piece
{
    public Knight(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitKnight(this);

    protected override void UpdateLegalMoves()
    {
        base.UpdateLegalMoves();

        AddLegalMove(2, -1);
        AddLegalMove(2, 1);
        
        AddLegalMove(1, 2);
        AddLegalMove(-1, 2);
        
        AddLegalMove(-2, -1);
        AddLegalMove(-2, 1);
        
        AddLegalMove(1, -2);
        AddLegalMove(-1, -2);
    }

    protected override void AddLegalMove(int i, int j)
    {
        if (HintTileIsBeyondTheBoard(currentTile.i + i, currentTile.j + j))
            return;

        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (hintTile.isEmpty || HintTileIsOccupiedByEnemy())
            _legalMoves.Add(hintTile);
    }
}