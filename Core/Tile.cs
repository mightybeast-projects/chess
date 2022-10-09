namespace Chess.Core;

public class Tile
{
    public TileColor color => _color;
    public string notation => _notation;
    public bool isEmpty = true;

    private TileColor _color;
    private string _notation;

    public Tile(int i, int j, TileColor tileColor)
    {
        char letter = (char) (j + 65);
        int number = i + 1;
        _notation = letter.ToString().ToLower() + number;
        _color = tileColor;
    }

    public override string? ToString()
    {
        return notation;
    }
}