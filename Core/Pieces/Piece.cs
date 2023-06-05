using Chess.Core.Exceptions;

namespace Chess.Core.Pieces;

public abstract class Piece
{
    public readonly Color color;
    public Tile currentTile { get; protected set; }
    public Board board { get; private set; }
    public List<Tile> legalMoves {
        get
        {
            UpdateLegalMoves();
            return _legalMoves;
        }
        protected set => _legalMoves = value;
    }

    protected List<Tile> _legalMoves;
    protected Tile hintTile;

    private Tile targetTile;

    public Piece(Tile tile, Color color)
    {
        this.currentTile = tile;
        this.color = color;

        tile.SetPiece(this);
    }

    public abstract void Accept(IPieceDrawerVisitor visitor);

    protected virtual void UpdateLegalMoves() =>
        _legalMoves = new List<Tile>();

    public void SetBoard(Board board)
    {
        this.board = board;
        UpdateLegalMoves();
    }

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
        currentTile.SetPiece(null!);
        currentTile = targetTile;
        currentTile.SetPiece(this);
    }

    protected Tile GetClampedHintTile(int i, int j)
    {
        int clampedI = Math.Clamp(i, 0, board.grid.GetLength(0) - 1);
        int clampedJ = Math.Clamp(j, 0, board.grid.GetLength(0) - 1);

        return board.grid[clampedI, clampedJ];
    }

    protected bool HintTileIsBeyondTheBoard(int i, int j) =>
        i < 0 || i > board.grid.GetLength(0) - 1 ||
        j < 0 || j  > board.grid.GetLength(0) - 1;

    protected bool HintTileIsOccupiedByEnemy() =>
        !hintTile.isEmpty && hintTile.piece.color != color;
}