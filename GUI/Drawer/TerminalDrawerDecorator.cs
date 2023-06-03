using Chess.Core;

namespace Chess.GUI.Drawer;

public class TerminalDrawerDecorator
{
    private Board board;

    public TerminalDrawerDecorator(Board board) => this.board = board;

    public void DrawNumber(int i)
    {
        Console.ResetColor();
        Console.Write(" " + Math.Abs(-1 - i) + " ");
    }

    public void DrawLetterLine()
    {
        Console.ResetColor();

        for (int i = 0; i < board.grid.GetLength(0) + 1; i++)
            HandleLetterLinePosition(i);

        Console.WriteLine();
    }

    private void HandleLetterLinePosition(int i)
    {
        if (i == 0)
            Console.Write("  ");
        else
            DrawLetter(i);
    }

    private void DrawLetter(int i)
    {
        char letter = (char)(i - 1 + 65);
        Console.Write(" " + letter.ToString().ToLower());
    }
}