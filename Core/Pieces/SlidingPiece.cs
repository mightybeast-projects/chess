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
                TryToAddLegalMove(x * i, y * i);
    }

    private new void TryToAddLegalMove(int i, int j)
    {
        try { AddLegalMove(i, j); }
        catch (IndexOutOfRangeException) { pathBlocked = true; }
    }

    protected override void AddLegalMove(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

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