namespace Chess.Core;

public class Piece
{
    public Tile tile;
    public Board board { get; set; }
    public Color color;

    public Piece(Tile tile, Color color)
    {
        this.tile = tile;
        this.color = color;

        tile.isEmpty = false;
    }

    public void Move(string tileName)
    {
        tile.isEmpty = true;
        tile = board.GetTile(tileName);
        tile.isEmpty = false;
    }
}