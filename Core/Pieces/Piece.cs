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
            return legalMovesField;
        }
        protected set => legalMovesField = value;
    }

    protected List<Tile> legalMovesField;
    protected Tile hintTile;

    private Tile targetTile;

    public Piece(Tile tile, Color color)
    {
        this.currentTile = tile;
        this.color = color;

        tile.SetPiece(this);
    }

    public abstract void Accept(IPieceDrawerVisitor visitor);

    protected virtual void UpdateLegalMoves()
    {
        legalMovesField = new List<Tile>();
    }

    public void SetBoard(Board board)
    {
        this.board = board;
        UpdateLegalMoves();
    }

    public void Move(string tileName)
    {
        targetTile = board.GetTile(tileName);

        if (legalMovesField.Contains(targetTile))
            HandlePositionChange();
        else
            throw new IllegalMoveException();

        UpdateLegalMoves();
    }

    protected void TryToAddLegalMove(int i, int j)
    {
        try { AddLegalMove(i, j); }
        catch (IndexOutOfRangeException) { return; }
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

    protected bool HintTileIsOccupiedByEnemy() 
        => !hintTile.isEmpty && hintTile.piece.color != color;
}