namespace Chess.Core;

public class Piece
{
    public Board board
    {
        get => _board;
        set
        {
            _board = value;
            AddHints();
        }
    }
    public List<Tile> hints => _hints;
    public Tile tile { get; private set; }
    public Color color;

    protected Board _board;
    protected List<Tile> _hints;
    private Tile _targetTile;
    
    public Piece(Tile tile, Color color)
    {
        _hints = new List<Tile>();
        this.tile = tile;
        this.color = color;

        tile.piece = this;
    }

    public void Move(string tileName)
    {
        _targetTile = _board.GetTile(tileName);

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
        _board.pieces.Remove(_targetTile.piece);
        ChangeCurrentPosition();
    }

    private void ChangeCurrentPosition()
    {
        tile.piece = null!;
        tile = _targetTile;
        tile.piece = this;
    }

    private void CheckTargetTile()
    {
        if (_targetTile.piece.color == color)
            throw new OccupiedByAllyException();
    }
}