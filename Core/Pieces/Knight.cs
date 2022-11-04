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
        TryToAddHintTile(2, -1);
        TryToAddHintTile(2, 1);
    }

    private void AddRightLHintTiles()
    {
        TryToAddHintTile(1, 2);
        TryToAddHintTile(-1, 2);
    }

    private void AddBottomLHintTiles()
    {
        TryToAddHintTile(-2, -1);
        TryToAddHintTile(-2, 1);
    }

    private void AddLeftLHintTiles()
    {
        TryToAddHintTile(1, -2);
        TryToAddHintTile(-1, -2);
    }

    protected override void AddHintTile(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (hintTile.isEmpty || HintTileIsOccupiedByEnemy())
            hintTiles.Add(hintTile);
    }
}