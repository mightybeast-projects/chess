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

        return
            new List<Tile>()
            .Append(GetCastlingMove("h1", new[] { "f1", "g1" }, "g1"))
            .ToList();
    }

    private Tile GetCastlingMove(
        string rookPositionStr,
        string[] passingTiles,
        string destinationTileStr)
    {
        Tile kingSideRookTile = board.GetTile(rookPositionStr);
        Piece kingSideRook = kingSideRookTile.piece;

        if (kingSideRook is null ||
            kingSideRook.GetType() != typeof(Rook) ||
            kingSideRook.hasMoved ||
            passingTiles.Any(tile => TileIsNotPassable(board.GetTile(tile))))
            return null;

        return board.GetTile(destinationTileStr);
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
}