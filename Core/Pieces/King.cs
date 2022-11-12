namespace Chess.Core.Pieces;

public class King : Piece
{
    public King(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        visitor.VisitKing(this);
    }

    public override void UpdateLegalMoves()
    {
        base.UpdateLegalMoves();

        TryToAddLegalMove(1, -1);
        TryToAddLegalMove(1, 1);
        TryToAddLegalMove(-1, 1);
        TryToAddLegalMove(-1, -1);

        TryToAddLegalMove(1, 0);
        TryToAddLegalMove(0, 1);
        TryToAddLegalMove(-1, 0);
        TryToAddLegalMove(0, -1);
    }

    protected override void AddLegalMove(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (hintTile.isEmpty || HintTileIsOccupiedByEnemy())
            legalMoves.Add(hintTile);
    }
}