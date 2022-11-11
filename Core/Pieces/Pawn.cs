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
            UpdatePawnHints(1, 1);
        else
            UpdatePawnHints(-1, 6);
    }

    private void UpdatePawnHints(int colorMultiplier, int pawnRowIndex)
    {
        TryToAddCaptureHintTile(colorMultiplier * 1, -1);
        TryToAddCaptureHintTile(colorMultiplier * 1, 1);

        TryToAddHintTile(colorMultiplier * 1, 0);

        if (!pathBlocked && currentTile.i == pawnRowIndex)
            TryToAddHintTile(colorMultiplier * 2, 0);
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