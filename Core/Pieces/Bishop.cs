namespace Chess.Core.Pieces;

public class Bishop : Piece
{
    private bool pathBlocked;

    public Bishop(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        visitor.VisitBishop(this);
    }

    public override void UpdateHints()
    {
        base.UpdateHints();

        AddHintTilesInDirection(1, 1);
        AddHintTilesInDirection(1, -1);
        AddHintTilesInDirection(-1, -1);
        AddHintTilesInDirection(-1, 1);
    }

    private void AddHintTilesInDirection(int x, int y)
    {
        pathBlocked = false;

        for (int i = 1; i < board.grid.GetLength(0); i++)
            if (!pathBlocked)
                AddHintTile(x * i, y * i);
    }

    private void AddHintTile(int i, int j)
    {
        try { TryToGetHintTile(i, j); }
        catch (IndexOutOfRangeException) { pathBlocked = true; }
    }

    private void TryToGetHintTile(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (!hintTile.isEmpty)
            HandleOccupiedTile();
        else
            hintTiles.Add(hintTile);
    }

    private void HandleOccupiedTile()
    {
        if (HintTileIsOccupiedByEnemy())
            hintTiles.Add(hintTile);
        
        pathBlocked = true;
    }
}