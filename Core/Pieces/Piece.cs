using Chess.Core.Exceptions;

namespace Chess.Core.Pieces;

public abstract class Piece
{
    public readonly Board board;
    public readonly Color color;
    public List<Tile> legalMoves => _legalMoves;
    public Tile tile { get; protected set; }

    private List<Tile> _legalMoves;
    private Tile targetTile;

    public Piece(Board board, Tile tile, Color color)
    {
        this.board = board;
        this.tile = tile;
        this.color = color;

        this.tile.SetPiece(this);
        UpdateLegalMoves();
    }

    public abstract void Accept(IPieceDrawerVisitor visitor);

    protected virtual void UpdateLegalMoves() => _legalMoves = new List<Tile>();

    public void Move(string tileName)
    {
        targetTile = board.GetTile(tileName);

        if (_legalMoves.Contains(targetTile))
            HandlePositionChange();
        else
            throw new IllegalMoveException();

        UpdateLegalMoves();
    }

    protected abstract void AddLegalMove(int i, int j);

    private void HandlePositionChange()
    {
        if (targetTile.isEmpty)
            ChangeCurrentPosition();
        else
            HandleOccupiedTargetTile();
    }

    private void HandleOccupiedTargetTile()
    {
        board.pieces.Remove(targetTile.piece);
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