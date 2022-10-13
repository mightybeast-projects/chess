namespace Chess.Core;

public class Tile
{
    public Piece piece { get; private set; }
    public Color color { get; }
    public string notation { get; private set; }
    public bool isEmpty => piece is null;

    public Tile(int i, int j, Color color)
    {
        ParseNotation(i, j);
        this.color = color;
    }

    public void SetPiece(Piece piece)
    {
        this.piece = piece;
    }

    private void ParseNotation(int i, int j)
    {
        char letter = (char)(j + 65);
        int number = i + 1;
        notation = letter.ToString().ToLower() + number;
    }

    public override string? ToString()
    {
        return notation;
    }
}