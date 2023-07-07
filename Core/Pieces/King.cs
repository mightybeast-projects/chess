using System.Numerics;
namespace Chess.Core.Pieces;

public class King : Piece
{
    public bool isChecked => CheckForCheck();
    public bool isCheckmated => CheckForCheckmate();
    public bool isInStalemate => CheckForStalemate();

    protected override List<Vector2> legalMovesDirections => new List<Vector2>()
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

    private List<string[]> castlingMovesDatas => new List<string[]>()
    {
        new[] { "f" + colorK, "g" + colorK, "h" + colorK },
        new[] { "d" + colorK, "c" + colorK, "a" + colorK },
    };

    private int colorK => color == Color.WHITE ? 1 : 8;

    public King(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitKing(this);

    protected override IEnumerable<Tile> GetLegalMoves() =>
        legalMovesDirections
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
        legalMovesDirections.ConvertAll(direction =>
            GetTileUnderAttack((int)direction.X, (int)direction.Y));

    protected override Tile GetTileUnderAttack(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return null;

        return board.grid[tile.i + i, tile.j + j];
    }

    protected override void HandlePositionChange()
    {
        base.HandlePositionChange();

        CheckForCastlingMove();
    }

    private List<Tile> GetCastlingMoves()
    {
        if (hasMoved || isChecked)
            return new List<Tile>();

        return castlingMovesDatas.ConvertAll(data => GetCastlingMove(data));
    }

    private Tile GetCastlingMove(string[] data)
    {
        Piece piece = board.GetTile(data[2]).piece;

        if (RookCannotCastle(piece) || AnyTileIsNotPassableIn(data.SkipLast(1)))
            return null;

        return board.GetTile(data[1]);
    }

    private void CheckForCastlingMove()
    {
        if (hasMoved)
            return;

        string[] data =
            castlingMovesDatas.Find(data => data[1] == tile.notation);

        if (data is null)
            return;

        Tile rookOriginalTile = board.GetTile(data[2]);

        Piece rook = rookOriginalTile.piece;
        if (RookCannotCastle(rook))
            return;

        Tile rookTargetTile = board.GetTile(data[0]);
        rook.ChangeTile(rookTargetTile);
    }

    private bool CheckForCheck()
    {
        foreach (Piece enemyPiece in GetEnemyPieces())
            foreach (Tile tileUnderAttack in enemyPiece.tilesUnderAttack)
                if (tile == tileUnderAttack)
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

    private bool AnyTileIsNotPassableIn(IEnumerable<string> data) =>
        data.Any(tile => TileIsNotPassable(board.GetTile(tile)));

    private bool RookCannotCastle(Piece piece) =>
        piece is null ||
        piece.GetType() != typeof(Rook) ||
        piece.hasMoved;

    private bool TileIsNotPassable(Tile tile) =>
        !tile.isEmpty || TileIsUnderAttack(tile);
}