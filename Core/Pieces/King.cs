namespace Chess.Core.Pieces;

public class King : Piece
{
    public King(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        visitor.VisitKing(this);
    }

    public override void UpdateHints()
    {
        base.UpdateHints();

        TryToAddHintTile(1, -1);
        TryToAddHintTile(1, 1);
        TryToAddHintTile(-1, 1);
        TryToAddHintTile(-1, -1);

        TryToAddHintTile(1, 0);
        TryToAddHintTile(0, 1);
        TryToAddHintTile(-1, 0);
        TryToAddHintTile(0, -1);
    }

    protected override void AddHintTile(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (hintTile.isEmpty || HintTileIsOccupiedByEnemy())
            hintTiles.Add(hintTile);
    }
}