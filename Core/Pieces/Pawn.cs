using Chess.Core;
using Chess.Core.Pieces;

public class Pawn : Piece
{
    public Pawn(Tile tile, Color color) : base (tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        visitor.VisitPawn(this);
    }

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
        AddCaptureHintTile(1, -1);
        AddCaptureHintTile(1, 1);

        if (!AddHintTile(1, 0)) return;

        if (currentTile.i == 1)
            AddHintTile(2, 0);
    }

    private void UpdateBlackPawnHints()
    {
        AddCaptureHintTile(-1, -1);
        AddCaptureHintTile(-1, 1);

        if (!AddHintTile(-1, 0)) return;

        if (currentTile.i == 6)
            AddHintTile(-2, 0);
    }

    private void AddCaptureHintTile(int i, int j)
    {
        try { TryToGetCaptureHintTile(i, j); }
        catch (IndexOutOfRangeException) { return; }
    }

    private void TryToGetCaptureHintTile(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];
        if (HintTileIsOccupiedByEnemy())
            hintTiles.Add(hintTile);
    }

    private bool AddHintTile(int i, int j)
    {
        try { return GetTile(i, j); }
        catch (Exception) { return false; }
    }

    private bool GetTile(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];
        if (!hintTile.isEmpty)
            return false;
        hintTiles.Add(hintTile);
        return true;
    }
}