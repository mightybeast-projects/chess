namespace Chess.Core.Pieces;

public class Rook : Piece
{
    private Tile hintTile;
    private bool pathBlocked;

    public Rook(Tile tile, Color color) : base(tile, color) { }

    public override void UpdateHints()
    {
        base.UpdateHints();

        AddUpperVerticalHints();
        AddLowerVerticalHints();
    }

    private void AddUpperVerticalHints()
    {
        pathBlocked = false;

        for (int i = currentTile.i + 1; i < board.grid.GetLength(0); i++)
            if (!pathBlocked)
                AddVerticalHintTile(i);
    }

    private void AddLowerVerticalHints()
    {
        pathBlocked = false;

        for (int i = currentTile.i - 1; i >= 0; i--)
            if (!pathBlocked)
                AddVerticalHintTile(i);
    }

    private void AddVerticalHintTile(int i)
    {
        hintTile = board.grid[i, currentTile.j];
        if (!hintTile.isEmpty)
            pathBlocked = true;
        else
            hintTiles.Add(hintTile);
    }
}