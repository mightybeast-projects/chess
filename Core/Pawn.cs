using Chess.Core;

class Pawn : Piece
{
    private Tile _hintTile;

    public Pawn(Tile tile, Color color) : base (tile, color) { }

    public override void UpdateHints()
    {
        base.UpdateHints();

        if (color == Color.WHITE)
        {
            AddNeighbourCaptureHintTile(1, -1);
            AddNeighbourCaptureHintTile(1, 1);

            if (!AddNeighbourHintTile(1, 0)) return;

            if (currentTile.i == 1)
                AddNeighbourHintTile(2, 0);
        }
        else
        {
            AddNeighbourHintTile(-1, 0);
            if (currentTile.i == 6)
                AddNeighbourHintTile(-2, 0);
        }
    }

    private void AddNeighbourCaptureHintTile(int i, int j)
    {
        try { TryGettingNeighbourCaptureHintTile(i, j); }
        catch (IndexOutOfRangeException) { return; }
    }

    private void TryGettingNeighbourCaptureHintTile(int i, int j)
    {
        _hintTile = board.grid[currentTile.i + i, currentTile.j + j];
        if (!_hintTile.isEmpty && _hintTile.piece.color != color)
            hints.Add(_hintTile);
    }

    private bool AddNeighbourHintTile(int i, int j)
    {
        _hintTile = board.grid[currentTile.i + i, currentTile.j + j];
        if (_hintTile.isEmpty)
        {
            hints.Add(_hintTile);
            return true;
        }
        return false;
    }
}