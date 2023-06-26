using System.Numerics;
namespace Chess.Core.Pieces;

public class King : Piece
{
    public bool isChecked => CheckForCheck();
    public bool isCheckmated => CheckForCheckmate();
    public bool isInStalemate => CheckForStalemate();

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

    private List<CastlingMoveData> castlingMovesDatas =>
        new List<CastlingMoveData>()
        {
            new CastlingMoveData()
            {
                rookPositionStr = "h1",
                passingTiles = new[] { "f1", "g1" },
                destinationTileStr = "g1"
            },
            new CastlingMoveData()
            {
                rookPositionStr = "a1",
                passingTiles = new[] { "d1", "c1", "b1" },
                destinationTileStr = "b1"
            }
        };

    public King(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitKing(this);

    protected override IEnumerable<Tile> GetLegalMoves() =>
        tilesDirections
        .ConvertAll(direction =>
            GetLegalMove((int)direction.X, (int)direction.Y))
        .Union(GetCastlingMoves());

    protected override Tile GetLegalMove(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return null;

        Tile hintTile = board.grid[tile.i + i, tile.j + j];

        if (TileIsOccupiedByAlly(hintTile) || TileIsUnderAttack(hintTile))
            return null;

        return hintTile;
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

    private List<Tile> GetCastlingMoves()
    {
        if (hasMoved || isChecked)
            return new List<Tile>();

        return castlingMovesDatas.ConvertAll(data => GetCastlingMove(data));
    }

    private Tile GetCastlingMove(CastlingMoveData castlingMoveData)
    {
        Tile rookTile = board.GetTile(castlingMoveData.rookPositionStr);
        Piece rook = rookTile.piece;

        if (rook is null ||
            rook.GetType() != typeof(Rook) ||
            rook.hasMoved ||
            castlingMoveData.passingTiles
                .Any(tile => TileIsNotPassable(board.GetTile(tile))))
            return null;

        return board.GetTile(castlingMoveData.destinationTileStr);
    }

    private bool CheckForCheck()
    {
        foreach (Piece enemyPiece in GetEnemyPieces())
            foreach (Tile move in enemyPiece.tilesUnderAttack)
                if (tile == move)
                    return true;

        return false;
    }

    private bool CheckForCheckmate()
    {
        if (!isChecked)
            return false;

        return AllyPiecesDoNotHaveAnyLegalMoves();
    }

    private bool CheckForStalemate()
    {
        if (isChecked)
            return false;

        return AllyPiecesDoNotHaveAnyLegalMoves();
    }

    private bool TileIsUnderAttack(Tile tile)
    {
        foreach (Piece piece in GetEnemyPieces())
            if (piece.tilesUnderAttack.Contains(tile))
                return true;

        return false;
    }

    private bool AllyPiecesDoNotHaveAnyLegalMoves()
    {
        foreach (Piece allyPiece in GetAllyPieces())
            if (allyPiece.legalMoves.Count > 0)
                return false;

        return true;
    }

    private List<Piece> GetEnemyPieces() =>
        color == Color.WHITE ? board.blackPieces : board.whitePieces;

    private List<Piece> GetAllyPieces() =>
        color == Color.WHITE ? board.whitePieces : board.blackPieces;

    private bool TileIsNotPassable(Tile tile) =>
        !tile.isEmpty || TileIsUnderAttack(tile);

    private struct CastlingMoveData
    {
        internal string rookPositionStr;
        internal string[] passingTiles;
        internal string destinationTileStr;
    }
}