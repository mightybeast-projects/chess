using System.Numerics;

namespace Chess.Core.Pieces;

public class Knight : Piece
{
    protected override List<Vector2> legalMovesDirections => new List<Vector2>()
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

    public Knight(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitKnight(this);

    protected override IEnumerable<Tile> GetLegalMoves() =>
        legalMovesDirections.ConvertAll(direction =>
            GetLegalMove((int)direction.X, (int)direction.Y));

    protected override Tile GetLegalMove(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return null;

        Tile hintTile = board.grid[tile.i + i, tile.j + j];

        if (TileIsOccupiedByAlly(hintTile) ||
            KingIsUnderCheckAfterMoveOn(hintTile))
            return null;

        return hintTile;
    }

    protected override IEnumerable<Tile> GetTilesUnderAttack() =>
        legalMovesDirections.ConvertAll(direction =>
            GetTileUnderAttack((int)direction.X, (int)direction.Y));

    protected override Tile GetTileUnderAttack(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return null;

        return board.grid[tile.i + i, tile.j + j];
    }
}