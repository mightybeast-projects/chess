using Chess.Core.Exceptions;

namespace Chess.Core.Pieces;

public abstract class Piece
{
    public readonly Board board;
    public readonly Color color;
    public Tile tile { get; protected set; }
    
    public List<Tile> legalMoves
    {
        get
        {
            UpdateLegalMoves();
            return _legalMoves;
        }
        protected set => _legalMoves = value;
    }

    protected List<Tile> _legalMoves;

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

    protected Tile GetClampedTile(int i, int j)
    {
        int clampedI = Math.Clamp(i, 0, board.grid.GetLength(0) - 1);
        int clampedJ = Math.Clamp(j, 0, board.grid.GetLength(0) - 1);

        return board.grid[clampedI, clampedJ];
    }

    protected bool TileIndexesAreBeyondTheBoard(int i, int j) =>
        i < 0 || i > board.grid.GetLength(0) - 1 ||
        j < 0 || j  > board.grid.GetLength(0) - 1;

    protected bool TileIsOccupiedByEnemy(Tile tile) =>
        !tile.isEmpty && tile.piece.color != color;
}