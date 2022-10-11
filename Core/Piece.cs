namespace Chess.Core;

public class Piece
{
    public Tile tile;
    public Board board { get; set; }
    public Color color;

    private Tile _targetTile;

    public Piece(Tile tile, Color color)
    {
        this.tile = tile;
        this.color = color;

        tile.piece = this;
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