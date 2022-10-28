namespace Chess.Core.Pieces;

public class Bishop : Piece
{
    private bool pathBlocked;

    public Bishop(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        throw new NotImplementedException();
    }

    public override void UpdateHints()
    {
        base.UpdateHints();
        
        AddTopLeftDiagonalHintTiles();
    }

    private void AddTopLeftDiagonalHintTiles()
    {
        pathBlocked = false;

        for (int i = currentTile.i + 1; i < board.grid.GetLength(0); i++)
            if (!pathBlocked)
                AddHintTile(i, i);
    }

    private void AddHintTile(int i, int j)
    {
        hintTile = board.grid[i, j];

        if (!hintTile.isEmpty)
            pathBlocked = true;
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