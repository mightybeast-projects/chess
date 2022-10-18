namespace Chess.Core;

public class Tile
{
    public readonly Color color;
    public readonly int i;
    public readonly int j;
    public Piece piece { get; private set; }
    public string notation { get; private set; }
    public bool isEmpty => piece is null;

    public Tile(int i, int j, Color color)
    {
        this.i = i;
        this.j = j;
        this.color = color;

        ParseNotation(i, j);
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