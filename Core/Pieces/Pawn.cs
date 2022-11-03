using Chess.Core;
using Chess.Core.Pieces;

public class Pawn : Piece
{
    private bool pathBlocked;

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

        AddHintTile(1, 0);

        if (!pathBlocked && currentTile.i == 1)
            AddHintTile(2, 0);
    }

    private void UpdateBlackPawnHints()
    {
        AddCaptureHintTile(-1, -1);
        AddCaptureHintTile(-1, 1);

        AddHintTile(-1, 0);

        if (!pathBlocked && currentTile.i == 6)
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

    private void AddHintTile(int i, int j)
    {
        try { TryToGetHintTile(i, j); }
        catch (IndexOutOfRangeException) { return; }
    }

    private void TryToGetHintTile(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (!hintTile.isEmpty)
            pathBlocked = true;
        else
            hintTiles.Add(hintTile);
    }
}