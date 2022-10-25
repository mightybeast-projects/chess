namespace Chess.Core.Pieces;

public class Rook : Piece
{
    public Rook(Tile tile, Color color) : base(tile, color) { }

    public override void UpdateHints()
    {
        base.UpdateHints();

        for (int i = currentTile.i + 1; i < board.grid.GetLength(0); i++)
        {
            Tile hintTile = board.grid[i, currentTile.j];
            if (!hintTile.isEmpty) break;
            hintTiles.Add(hintTile);
        }

        for (int i = currentTile.i - 1; i >= 0; i--)
        {
            Tile hintTile = board.grid[i, currentTile.j];
            if (!hintTile.isEmpty) break;
            hintTiles.Add(hintTile);
        }
    }
}