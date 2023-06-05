namespace Chess.Core.Pieces;

public abstract class SlidingPiece : Piece
{
    private bool pathBlocked;

    protected SlidingPiece(Tile tile, Color color) : base(tile, color) { }

    protected void AddLegalMovesInDirection(int x, int y)
    {
        pathBlocked = false;

        for (int i = 1; i < board.grid.GetLength(0); i++)
            if (!pathBlocked)
                AddLegalMove(x * i, y * i);
    }

    protected override void AddLegalMove(int i, int j)
    {
        if (currentTile.i + i < 0 ||
            currentTile.i + i > board.grid.GetLength(0) - 1 ||
            currentTile.j + j < 0 ||
            currentTile.j + j  > board.grid.GetLength(0) - 1)
                return;

        int clampedI = Math.Clamp(currentTile.i + i, 0, board.grid.GetLength(0) - 1);
        int clampedJ = Math.Clamp(currentTile.j + j, 0, board.grid.GetLength(0) - 1);

        hintTile = board.grid[clampedI, clampedJ];

        if (!hintTile.isEmpty)
            HandleOccupiedHintTile();
        else
            _legalMoves.Add(hintTile);
    }

    private void HandleOccupiedHintTile()
    {
        if (HintTileIsOccupiedByEnemy())
            _legalMoves.Add(hintTile);
        
        pathBlocked = true;
    }
}