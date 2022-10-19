using Chess.Core;

public class Terminal
{
    private Board board;

    public void Run()
    {
        board = new Board();

        for (int i = board.grid.GetLength(0) - 1; i >= 0; i--)
            DisplayBoardLine(i);
    }

    private void DisplayBoardLine(int i)
    {
        for (int j = 0; j < board.grid.GetLength(1) + 1; j++)
            HandleGridPosition(i, j);

        Console.WriteLine();

        if (IndexIsZero(i))
            DisplayLetterLine();
    }

    private void DisplayLetterLine()
    {
        Console.ResetColor();

        for (int i = 0; i < board.grid.GetLength(0) + 1; i++)
            HandleLetterLinePosition(i);
    }

    private void HandleGridPosition(int i, int j)
    {
        if (IndexIsZero(j))
            DisplayNumber(i);
        else
            DisplayTile(i, j - 1);
    }

    private void HandleLetterLinePosition(int i)
    {
        if (IndexIsZero(i))
            Console.Write("  ");
        else
            DisplayLetter(i);
    }

    private void DisplayNumber(int i)
    {
        Console.ResetColor();
        Console.Write(Math.Abs(-1 - i) + " ");
    }

    private void DisplayLetter(int i)
    {
        char letter = (char)(i - 1 + 65);
        Console.Write(letter.ToString().ToLower() + " ");
    }

    private void DisplayTile(int i, int j)
    {
        Tile tile = board.grid[i, j];
        int tileColor = (int)tile.color;
        ConsoleColor consoleColor = tileColor == 0 ?
            ConsoleColor.Black : ConsoleColor.White;
        Console.BackgroundColor = consoleColor;
        Console.Write("  ");
    }

    private bool IndexIsZero(int i) => i == 0;

    private void Tmp()
    {
        Console.WriteLine();

        //White on black
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("♟ ");

        //White on white
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("♙ ");

        //Black on black
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("♙ ");

        //Black on white
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("♟ ");
    }
}