namespace Chess.Core;

public class Tile
{
    public Piece piece;
    public Color color => _color;
    public string notation => _notation;
    public bool isEmpty => piece is null;

    private Color _color;
    private string _notation;

    public Tile(int i, int j, Color tileColor)
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