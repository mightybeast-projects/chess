namespace Chess.Core;

public class Tile
{
    public TileColor color;
    public string notation;
    public bool isEmpty = true;

    public Tile(int i, int j)
    {
        char letter = (char) (j + 65);
        int number = i + 1;
        notation = letter.ToString().ToLower() + number;
    }
}