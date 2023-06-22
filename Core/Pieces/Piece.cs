using Chess.Core.Exceptions;

namespace Chess.Core.Pieces;

public abstract class Piece
{
    public readonly Color color;

    public Tile tile { get; protected set; }
    public Board board { get; internal set; }
    public List<Tile> tilesUnderAttack =>
        GetTilesUnderAttack().Where(tile => tile != null).ToList();
    public List<Tile> legalMoves
    {
        get
        {
            UpdateLegalMoves();
            return legalMovesList;
        }
    }

    protected List<Tile> legalMovesList;

    private Tile targetTile;

    public Piece(Tile tile, Color color)
    {
        this.tile = tile;
        this.color = color;

        this.tile.SetPiece(this);
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

    protected abstract void UpdateLegalMoves();

    protected abstract void AddLegalMove(int i, int j);

    protected virtual IEnumerable<Tile> GetTilesUnderAttack() { return null; }

    protected virtual Tile GetTileUnderAttack(int i, int j) { return null; }

    private void HandlePositionChange()
    {
        if (!targetTile.isEmpty)
            board.RemovePiece(targetTile.piece);

        ChangeCurrentPosition();
    }

    private void ChangeCurrentPosition()
    {
        tile.SetPiece(null!);
        tile = targetTile;
        tile.SetPiece(this);
    }

    protected bool TileIsOccupiedByEnemy(Tile tile) =>
        !tile.isEmpty && tile.piece.color != color;

    private King GetAllyKing() =>
        color == Color.WHITE ? board.whiteKing : board.blackKing;
}