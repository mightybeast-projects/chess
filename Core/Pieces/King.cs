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
        foreach (Piece enemyPiece in GetEnemyPieces().Skip(1))
            foreach (Tile move in enemyPiece.legalMoves)
                if (tile == move)
                    return true;
        return false;
    }

    private bool TileIsUnderAttack(Tile tile)
    {
        if (breakLegalMoveCycle)
            return false;

        breakLegalMoveCycle = true;

        Piece enemyPiece = null;
        if (TileIsOccupiedByEnemy(tile))
        {
            enemyPiece = tile.piece;
            board.RemovePiece(tile.piece);
        }

        bool tileIsUnderAttack = false;
        Pawn pawn = new Pawn(tile, color);
        board.AddPiece(pawn);

        foreach (Piece piece in GetEnemyPieces())
        {
            if (piece.legalMoves.Contains(tile))
            {
                tileIsUnderAttack = true;
                break;
            }
        }

        board.RemovePiece(pawn);
        if (enemyPiece is not null)
            board.AddPiece(enemyPiece);

        breakLegalMoveCycle = false;

        return tileIsUnderAttack;
    }

    private bool TileIsOccupiedByAlly(Tile tile) =>
        !tile.isEmpty && tile.piece.color == color;

    private List<Piece> GetEnemyPieces() =>
        color == Color.WHITE ? board.blackPieces : board.whitePieces;
}