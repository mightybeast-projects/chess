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
        hints = new List<Tile>();
        this.tile = tile;
        this.color = color;

        tile.SetPiece(this);
    }

    public void SetBoard(Board board)
    {
        this.board = board;
        AddHints();
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

    protected virtual void AddHints() { }

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