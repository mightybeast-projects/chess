using Chess.Core;

class Pawn : Piece
{
    public Pawn(Tile tile, Color color) : base (tile, color) { }

    public override void UpdateHints()
    {
        base.UpdateHints();

        AddNewHintTileWithIndex(1, 0);
        if (hints.Count == 0) return;

        if (currentTile.i == 1)
            AddNewHintTileWithIndex(2, 0);
    }

    private void AddNewHintTileWithIndex(int i, int j)
    {
        Tile hintTile = board.grid[currentTile.i + i, currentTile.j];
        if (hintTile.isEmpty)
            hints.Add(hintTile);
    }
}