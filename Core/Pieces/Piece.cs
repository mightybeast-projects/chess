using Chess.Core.Exceptions;

namespace Chess.Core.Pieces;

public abstract class Piece
{
    public readonly Color color;

    public Tile tile { get; protected set; }
    public Board board { get; internal set; }
    public List<Tile> legalMoves =>
        GetLegalMoves().Where(tile => tile != null).ToList();
    public List<Tile> tilesUnderAttack =>
        GetTilesUnderAttack().Where(tile => tile != null).ToList();

    private Tile targetTile;

    public Piece(Tile tile, Color color)
    {
        this.tile = tile;
        this.color = color;

        this.tile.piece = this;
    }

    public abstract void Accept(IPieceDrawerVisitor visitor);

    public void Move(string tileName)
    {
        targetTile = board.GetTile(tileName);

        if (legalMoves.Contains(targetTile))
            HandlePositionChange();
        else
            throw new IllegalMoveException();
    }

    protected abstract IEnumerable<Tile> GetLegalMoves();

    protected abstract Tile GetLegalMove(int i, int j);

    protected abstract IEnumerable<Tile> GetTilesUnderAttack();

    protected abstract Tile GetTileUnderAttack(int i, int j);

    protected virtual void HandlePositionChange()
    {
        if (!targetTile.isEmpty)
            board.RemovePiece(targetTile.piece);

        ChangeCurrentPosition(targetTile);
    }

    protected bool KingIsUnderCheckAfterMoveOn(Tile tile)
    {
        King allyKing = GetAllyKing();

        if (allyKing is null || !allyKing.isChecked)
            return false;

        Tile originalTile = this.tile;

        Piece enemyPiece = null;
        if (tile.piece is not null)
        {
            enemyPiece = tile.piece;
            board.RemovePiece(enemyPiece);
        }

        ChangeCurrentPosition(tile);

        bool kingIsUnderCheck = GetAllyKing().isChecked;

        ChangeCurrentPosition(originalTile);
        if (enemyPiece is not null)
        {
            tile.piece = enemyPiece;
            board.AddPiece(enemyPiece);
        }

        return kingIsUnderCheck;
    }

    private void ChangeCurrentPosition(Tile targetTile)
    {
        tile.piece = null;
        tile = targetTile;
        tile.piece = this;
    }

    protected bool TileIsOccupiedByEnemy(Tile tile) =>
        !tile.isEmpty && tile.piece.color != color;

    private King GetAllyKing() =>
        color == Color.WHITE ? board.whiteKing : board.blackKing;
}