using System.Numerics;

namespace Chess.Core.Pieces;

public class Knight : Piece
{
    public Knight(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitKnight(this);

    private List<Vector2> tilesDirections => new List<Vector2>()
    {
        new Vector2(2, -1),
        new Vector2(2, 1),
        new Vector2(1, 2),
        new Vector2(-1, 2),
        new Vector2(-2, -1),
        new Vector2(-2, 1),
        new Vector2(1, -2),
        new Vector2(-1, -2),
    };

    protected override void UpdateLegalMoves()
    {
        legalMovesList = new List<Tile>();

        foreach (Vector2 direction in tilesDirections)
            AddLegalMove((int)direction.X, (int)direction.Y);
    }

    protected override void AddLegalMove(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return;

        Tile hintTile = board.grid[tile.i + i, tile.j + j];

        if (hintTile.isEmpty || TileIsOccupiedByEnemy(hintTile))
            legalMovesList.Add(hintTile);
    }

    protected override IEnumerable<Tile> GetTilesUnderAttack() =>
        tilesDirections.ConvertAll(direction =>
            GetTileUnderAttack((int)direction.X, (int)direction.Y));

    protected override Tile GetTileUnderAttack(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return null;

        return board.grid[tile.i + i, tile.j + j];
    }
}