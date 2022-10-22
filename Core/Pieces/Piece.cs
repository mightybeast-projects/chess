namespace Chess.Core.Pieces;

public class Piece
{
    public readonly Color color;
    public List<Tile> hintTiles { get; protected set; }
    public Tile currentTile { get; protected set; }
    public Board board { get; private set; }

    private Tile targetTile;

    public Piece(Tile tile, Color color)
    {
        this.currentTile = tile;
        this.color = color;

        tile.SetPiece(this);
    }

    public virtual void UpdateHints()
    {
        hintTiles = new List<Tile>();
    }

    public void SetBoard(Board board)
    {
        this.board = board;
        UpdateHints();
    }

    public void Move(string tileName)
    {
        targetTile = board.GetTile(tileName);

        if (hintTiles.Contains(targetTile))
            HandlePositionChange();
        else
            throw new WrongMoveException();

        UpdateHints();
    }

    private void HandlePositionChange()
    {
        if (targetTile.isEmpty)
            ChangeCurrentPosition();
        else
            HandleOccupiedPosition();
    }

    private void HandleOccupiedPosition()
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
}