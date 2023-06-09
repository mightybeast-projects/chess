using Chess.Core.Pieces;

namespace Chess.Core;

public class Tile
{
    public readonly Color color;
    public readonly int i;
    public readonly int j;
    public readonly string notation;
    public Piece piece { get; internal set; }
    public bool isEmpty => piece is null;

    public Tile(int i, int j, Color color)
    {
        this.i = i;
        this.j = j;
        this.color = color;

        char letter = (char)(j + 65);
        int number = i + 1;
        notation = letter.ToString().ToLower() + number;
    }

    public override string ToString() => notation;
}