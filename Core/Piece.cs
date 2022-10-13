namespace Chess.Core;

public class Piece
{
    public Board board { get; private set; }
    public List<Tile> hints { get; protected set; }
    public Tile tile { get; protected set; }
    public Color color { get; }

    private Tile _targetTile;
    
    public Piece(Tile tile, Color color)
    {
        this.tile = tile;
        this.color = color;

        tile.SetPiece(this);
    }

    public virtual void UpdateHints()
    {
        hints = new List<Tile>();
    }

    public void SetBoard(Board board)
    {
        this.board = board;
        UpdateHints();
    }

    public void Move(string tileName)
    {
        _targetTile = board.GetTile(tileName);

        try
        {
            HandleOccupiedTile();
        }
        catch (NullReferenceException)
        {
            ChangeCurrentPosition();
        }
    }

    private void HandleOccupiedTile()
    {
        CheckTargetTile();
        board.pieces.Remove(_targetTile.piece);
        ChangeCurrentPosition();
    }

    private void ChangeCurrentPosition()
    {
        tile.SetPiece(null!);
        tile = _targetTile;
        tile.SetPiece(this);
    }

    private void CheckTargetTile()
    {
        if (_targetTile.piece.color == color)
            throw new OccupiedByAllyException();
    }
}