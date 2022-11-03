namespace Chess.Core.Pieces;

public class Knight : Piece
{
    public Knight(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        visitor.VisitKnight(this);
    }

    public override void UpdateHints()
    {
        base.UpdateHints();

        AddTopLHintTiles();
        AddRightLHintTiles();
        AddBottomLHintTiles();
        AddLeftLHintTiles();
    }

    private void AddTopLHintTiles()
    {
        AddHintTile(2, -1);
        AddHintTile(2, 1);
    }

    private void AddRightLHintTiles()
    {
        AddHintTile(1, 2);
        AddHintTile(-1, 2);
    }

    private void AddBottomLHintTiles()
    {
        AddHintTile(-2, -1);
        AddHintTile(-2, 1);
    }

    private void AddLeftLHintTiles()
    {
        AddHintTile(1, -2);
        AddHintTile(-1, -2);
    }

    private void AddHintTile(int i, int j)
    {
        try { TryToGetHintTile(i, j); }
        catch (IndexOutOfRangeException) { return; }
    }

    private void TryToGetHintTile(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];
        
        if (hintTile.isEmpty || HintTileIsOccupiedByEnemy())
            hintTiles.Add(hintTile);
    }
}