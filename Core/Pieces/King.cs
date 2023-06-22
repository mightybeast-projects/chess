using System.Numerics;
namespace Chess.Core.Pieces;

public class King : Piece
{
    public bool isChecked => CheckForCheck();

    private List<Vector2> tilesDirections => new List<Vector2>()
    {
        new Vector2(1, -1),
        new Vector2(1, 1),
        new Vector2(-1, 1),
        new Vector2(-1, -1),
        new Vector2(1, 0),
        new Vector2(0, 1),
        new Vector2(-1, 0),
        new Vector2(0, -1),
    };

    public King(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitKing(this);

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

        Tile hintTile = board.GetClampedTile(tile.i + i, tile.j + j);

        if (TileIsOccupiedByAlly(hintTile) || TileIsUnderAttack(hintTile))
            return;

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

    private bool CheckForCheck()
    {
        foreach (Piece enemyPiece in GetEnemyPieces())
            foreach (Tile move in enemyPiece.tilesUnderAttack)
                if (tile == move)
                    return true;
        return false;
    }

    private bool TileIsUnderAttack(Tile tile)
    {
        foreach (Piece piece in GetEnemyPieces())
            if (piece.tilesUnderAttack.Contains(tile))
                return true;

        return false;
    }

    private bool TileIsOccupiedByAlly(Tile tile) =>
        !tile.isEmpty && tile.piece.color == color;

    private List<Piece> GetEnemyPieces() =>
        color == Color.WHITE ? board.blackPieces : board.whitePieces;
}