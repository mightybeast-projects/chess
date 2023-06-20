using Chess.Core.Exceptions;

namespace Chess.Core.Pieces;

public abstract class Piece
{
    public readonly Color color;

    public Tile tile { get; protected set; }
    public Board board { get; internal set; }
    public List<Tile> LegalMoves
    {
        get
        {
            UpdateLegalMoves();
            return legalMoves;
        }
    }

    protected List<Tile> legalMoves;

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

        if (LegalMoves.Contains(targetTile))
            HandlePositionChange();
        else
            throw new IllegalMoveException();
    }

    internal abstract void UpdateLegalMoves();

    protected abstract void AddLegalMove(int i, int j);

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
}