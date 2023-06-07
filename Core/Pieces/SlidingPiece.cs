namespace Chess.Core.Pieces;

public abstract class SlidingPiece : Piece
{
    private bool pathBlocked;

    public SlidingPiece(Board board, Tile tile, Color color) :
        base(board, tile, color) { }

    protected void AddLegalMovesInDirection(int x, int y)
    {
        pathBlocked = false;

        for (int i = 1; i < board.grid.GetLength(0); i++)
            if (!pathBlocked)
                AddLegalMove(x * i, y * i);
    }

    protected override void AddLegalMove(int i, int j)
    {
        if (TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return;

        Tile hintTile = GetClampedTile(tile.i + i, tile.j + j);

        if (!hintTile.isEmpty)
            HandleOccupiedHintTile(hintTile);
        else
            _legalMoves.Add(hintTile);
    }

    private void HandleOccupiedHintTile(Tile hintTile)
    {
        if (TileIsOccupiedByEnemy(hintTile))
            _legalMoves.Add(hintTile);
        
        pathBlocked = true;
    }
}