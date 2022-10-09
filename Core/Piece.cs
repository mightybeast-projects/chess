namespace Chess.Core;

public class Piece
{
    public Tile tile;
    public Board board;

    public Piece(Board board, Tile tile)
    {
        this.board = board;
        this.tile = tile;
    }

    public void Move(string tileName)
    {

    }
}