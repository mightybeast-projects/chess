using System.Numerics;
using Chess.Core.Exceptions;

namespace Chess.Core.Pieces;

public abstract class Piece
{
    public readonly Color color;
    public Tile tile { get; internal set; }
    public Board board { get; internal set; }
    public bool hasMoved { get; private set; }
    public List<Tile> legalMoves =>
        GetLegalMoves().Where(tile => tile != null).ToList();
    public List<Tile> tilesUnderAttack =>
        GetTilesUnderAttack().Where(tile => tile != null).ToList();

    protected abstract List<Vector2> legalMovesDirections { get; }

    private Tile targetTile;

    public Piece(Tile tile, Color color)
    {
        this.tile = tile;
        this.color = color;

        this.tile.piece = this;
    }

    public abstract void Accept(IPieceDrawerVisitor visitor);

    internal void Move(string tileName)
    {
        targetTile = board.GetTile(tileName);

        if (legalMoves.Contains(targetTile))
            HandlePositionChange();
        else
            throw new IllegalMoveException();

        hasMoved = true;
    }

    internal void ChangeTile(Tile tile)
    {
        this.tile.piece = null;
        this.tile = tile;
        this.tile.piece = this;
    }

    protected abstract IEnumerable<Tile> GetLegalMoves();

    protected abstract Tile GetLegalMove(int i, int j);

    protected abstract IEnumerable<Tile> GetTilesUnderAttack();

    protected abstract Tile GetTileUnderAttack(int i, int j);

    protected virtual void HandlePositionChange()
    {
        if (!targetTile.isEmpty)
            board.RemovePiece(targetTile.piece);

        ChangeTile(targetTile);

        board.lastMovedPiece = this;
    }

    protected bool KingIsUnderCheckAfterMoveOn(Tile tile)
    {
        if (GetAllyKing() is null)
            return false;

        bool allyKingIsChecked = GetAllyKing().isChecked;

        if (!allyKingIsChecked)
            return false;

        Tile originalTile = this.tile;

        Piece enemyPiece = null;
        if (TileIsOccupiedByEnemy(tile))
        {
            enemyPiece = tile.piece;
            board.RemovePiece(enemyPiece);
        }

        ChangeTile(tile);

        allyKingIsChecked = GetAllyKing().isChecked;

        ChangeTile(originalTile);
        if (enemyPiece is not null)
        {
            tile.piece = enemyPiece;
            board.AddPiece(enemyPiece);
        }

        return allyKingIsChecked;
    }

    protected bool TileIsOccupiedByEnemy(Tile tile) =>
        !tile.isEmpty && tile.piece.color != color;

    protected bool TileIsOccupiedByAlly(Tile tile) =>
        !tile.isEmpty && tile.piece.color == color;

    private King GetAllyKing() =>
        color == Color.WHITE ? board.whiteKing : board.blackKing;
}