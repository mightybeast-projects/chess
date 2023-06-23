using System.Numerics;

namespace Chess.Core.Pieces;

public abstract class SlidingPiece : Piece
{
    protected abstract List<Vector2> tilesDirections { get; }

    private bool pathBlocked;

    public SlidingPiece(Tile tile, Color color) : base(tile, color) { }

    protected override IEnumerable<Tile> GetLegalMoves() =>
        tilesDirections.SelectMany(direction =>
            GetLegalMovesInDirection((int)direction.X, (int)direction.Y));

    protected override Tile GetLegalMove(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return null;

        Tile hintTile = board.GetClampedTile(tile.i + i, tile.j + j);

        if (!hintTile.isEmpty)
            pathBlocked = true;

        if (TileIsOccupiedByAlly(hintTile) ||
            KingIsUnderCheckAfterMoveOn(hintTile))
            return null;

        return hintTile;
    }

    protected override IEnumerable<Tile> GetTilesUnderAttack() =>
        tilesDirections.SelectMany(direction =>
            GetTilesUnderAttackInDirection((int)direction.X, (int)direction.Y));

    protected override Tile GetTileUnderAttack(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return null;

        Tile hintTile = board.GetClampedTile(tile.i + i, tile.j + j);

        if (!hintTile.isEmpty)
            pathBlocked = true;

        return hintTile;
    }

    private IEnumerable<Tile> GetLegalMovesInDirection(int x, int y)
    {
        List<Tile> legalMovesInDirection = new List<Tile>();

        pathBlocked = false;

        for (int i = 1; i < board.grid.GetLength(0); i++)
            if (!pathBlocked)
                legalMovesInDirection.Add(GetLegalMove(x * i, y * i));

        return legalMovesInDirection;
    }

    private IEnumerable<Tile> GetTilesUnderAttackInDirection(int x, int y)
    {
        List<Tile> tilesUnderAttackInDirection = new List<Tile>();

        pathBlocked = false;

        for (int i = 1; i < board.grid.GetLength(0); i++)
            if (!pathBlocked)
                tilesUnderAttackInDirection.Add(
                    GetTileUnderAttack(x * i, y * i)
                );

        return tilesUnderAttackInDirection;
    }
}