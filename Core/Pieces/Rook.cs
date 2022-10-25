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
        AddRightSideHorizontalHints();
    }

    private void AddRightSideHorizontalHints()
    {
        pathBlocked = false;

        for (int j = currentTile.j + 1; j < board.grid.GetLength(0); j++)
            if (!pathBlocked)
                AddHorizontalHintTile(j);
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
            HandleOccupiedTile();
        else
            hintTiles.Add(hintTile);
    }

    private void AddHorizontalHintTile(int j)
    {
        hintTile = board.grid[currentTile.i, j];
        if (!hintTile.isEmpty)
            HandleOccupiedTile();
        else
            hintTiles.Add(hintTile);
    }

    private void HandleOccupiedTile()
    {
        if (hintTile.piece.color == color)
            pathBlocked = true;
        else
            AddEnemyPieceToCapture();
    }

    private void AddEnemyPieceToCapture()
    {
        hintTiles.Add(hintTile);
        pathBlocked = true;
    }
}