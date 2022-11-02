namespace Chess.Core.Pieces;

public class Bishop : Piece
{
    private bool pathBlocked;
    private int maxEdgeIndex;

    public Bishop(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        throw new NotImplementedException();
    }

    public override void UpdateHints()
    {
        base.UpdateHints();

        AddTopRightDiagonalHintTiles();
        AddBottomLeftDiagonalHintTiles();
    }

    private void AddTopRightDiagonalHintTiles()
    {
        pathBlocked = false;
        maxEdgeIndex = Math.Max(currentTile.i, currentTile.j);

        for (int i = 1; i < board.grid.GetLength(1) - maxEdgeIndex; i++)
            if (!pathBlocked)
                AddHintTile(i, i);
    }

    private void AddBottomLeftDiagonalHintTiles()
    {
        pathBlocked = false;

        for (int i = -1; i > -board.grid.GetLength(1); i--)
            if (!pathBlocked)
                AddHintTile(i, i);
    }

    private void AddHintTile(int i, int j)
    {
        try { TryToGetHintTile(i, j); }
        catch (Exception) { return; }
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