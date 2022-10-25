namespace Chess.Core.Pieces;

public class Rook : Piece
{
    public Rook(Tile tile, Color color) : base(tile, color) { }

    public override void UpdateHints()
    {
        base.UpdateHints();

        for (int i = currentTile.i + 1; i < board.grid.GetLength(0); i++)
        {
            hintTiles.Add(board.grid[i, currentTile.j]);
        }
    }
}