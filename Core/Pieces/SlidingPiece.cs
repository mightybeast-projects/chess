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
        if (HintTileIsBeyondTheBoard(currentTile.i + i, currentTile.j + j))
            return;

        hintTile = GetClampedHintTile(currentTile.i + i, currentTile.j + j);

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