namespace Chess.Core.Pieces;

public abstract class DirectionalPiece : Piece
{
    private bool pathBlocked;

    protected DirectionalPiece(Tile tile, Color color) 
        : base(tile, color) { }

    protected void AddHintTilesInDirection(int x, int y)
    {
        pathBlocked = false;

        for (int i = 1; i < board.grid.GetLength(0); i++)
            if (!pathBlocked)
                TryToAddHintTile(x * i, y * i);
    }

    private new void TryToAddHintTile(int i, int j)
    {
        try { AddHintTile(i, j); }
        catch (IndexOutOfRangeException) { pathBlocked = true; }
    }

    protected override void AddHintTile(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (!hintTile.isEmpty)
            HandleOccupiedHintTile();
        else
            hintTiles.Add(hintTile);
    }

    private void HandleOccupiedHintTile()
    {
        if (HintTileIsOccupiedByEnemy())
            hintTiles.Add(hintTile);
        
        pathBlocked = true;
    }
}