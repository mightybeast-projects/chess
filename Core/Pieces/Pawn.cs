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
        TryToAddCaptureHintTile(1, -1);
        TryToAddCaptureHintTile(1, 1);

        TryToAddHintTile(1, 0);

        if (!pathBlocked && currentTile.i == 1)
            TryToAddHintTile(2, 0);
    }

    private void UpdateBlackPawnHints()
    {
        TryToAddCaptureHintTile(-1, -1);
        TryToAddCaptureHintTile(-1, 1);

        TryToAddHintTile(-1, 0);

        if (!pathBlocked && currentTile.i == 6)
            TryToAddHintTile(-2, 0);
    }

    private void TryToAddCaptureHintTile(int i, int j)
    {
        try { AddCaptureHintTile(i, j); }
        catch (IndexOutOfRangeException) { return; }
    }

    private void AddCaptureHintTile(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (HintTileIsOccupiedByEnemy())
            hintTiles.Add(hintTile);
    }

    protected override void AddHintTile(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (!hintTile.isEmpty)
            pathBlocked = true;
        else
            hintTiles.Add(hintTile);
    }
}