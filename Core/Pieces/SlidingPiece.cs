using System.Numerics;

namespace Chess.Core.Pieces;

public abstract class SlidingPiece : Piece
{
    protected abstract List<Vector2> tilesDirections { get; }

    private bool pathBlocked;

    public SlidingPiece(Tile tile, Color color) : base(tile, color) { }

    protected override void UpdateLegalMoves()
    {
        legalMovesList = new List<Tile>();

        foreach (Vector2 direction in tilesDirections)
            AddLegalMovesInDirection((int)direction.X, (int)direction.Y);
    }

    protected void AddLegalMovesInDirection(int x, int y)
    {
        pathBlocked = false;

        for (int i = 1; i < board.grid.GetLength(0); i++)
            if (!pathBlocked)
                AddLegalMove(x * i, y * i);
    }

    protected override void AddLegalMove(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return;

        Tile hintTile = board.GetClampedTile(tile.i + i, tile.j + j);

        if (!hintTile.isEmpty)
            HandleOccupiedHintTile(hintTile);
        else
            legalMovesList.Add(hintTile);
    }

    private void HandleOccupiedHintTile(Tile hintTile)
    {
        if (TileIsOccupiedByEnemy(hintTile))
            legalMovesList.Add(hintTile);

        pathBlocked = true;
    }
}