using Chess.Core;
using Chess.Core.Pieces;

public class Pawn : Piece
{
    private Tile hintTile;

    public Pawn(Tile tile, Color color) : base (tile, color) { }

    public override void UpdateHints()
    {
        base.UpdateHints();

        if (color == Color.WHITE)
            UpdateWhitePawnHints();
        else
            UpdateBlackPawnHints();
    }

    private void UpdateWhitePawnHints()
    {
        AddNeighbourCaptureHintTile(1, -1);
        AddNeighbourCaptureHintTile(1, 1);

        if (!AddNeighbourHintTile(1, 0)) return;

        if (currentTile.i == 1)
            AddNeighbourHintTile(2, 0);
    }

    private void UpdateBlackPawnHints()
    {
        AddNeighbourCaptureHintTile(-1, -1);
        AddNeighbourCaptureHintTile(-1, 1);

        if (!AddNeighbourHintTile(-1, 0)) return;

        if (currentTile.i == 6)
            AddNeighbourHintTile(-2, 0);
    }

    private void AddNeighbourCaptureHintTile(int i, int j)
    {
        try { TryGettingNeighbourCaptureHintTile(i, j); }
        catch (IndexOutOfRangeException) { return; }
    }

    private void TryGettingNeighbourCaptureHintTile(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];
        if (!hintTile.isEmpty && hintTile.piece.color != color)
            hints.Add(hintTile);
    }

    private bool AddNeighbourHintTile(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];
        if (hintTile.isEmpty)
        {
            hints.Add(hintTile);
            return true;
        }
        return false;
    }
}