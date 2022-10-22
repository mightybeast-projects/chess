using Chess.Core;
using Chess.Core.Pieces;

public class TerminalDrawer
{
    private Board board;
    private Tile currentTile;
    private ConsoleColor bgColor;
    private Piece? hintPiece;

    public TerminalDrawer(Board board)
    {
        this.board = board;
    }

    public void Draw()
    {
        for (int i = board.grid.GetLength(0) - 1; i >= 0; i--)
            DisplayBoardLine(i);
        
        Console.WriteLine("Waiting for input...");
    }

    public void SetHintPiece(Piece piece)
    {
        hintPiece = piece;
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

        Console.WriteLine();
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
        currentTile = board.grid[i, j];
        int tileColor = (int)currentTile.color;

        if (hintPiece != null && hintPiece.hints.Contains(currentTile))
            bgColor = ConsoleColor.DarkGreen;
        else
            bgColor = 
                tileColor == 0 ? ConsoleColor.Black : ConsoleColor.White;
        
        Console.BackgroundColor = bgColor;

        if (currentTile.isEmpty)
            Console.Write("  ");
        else
            DisplayTilePiece();
    }

    private void DisplayTilePiece()
    {
        if (CurrentTileAndPieceColorsAre(Color.BLACK, Color.WHITE))
            DispayPawn(ConsoleColor.White, "♟ ");
        else if (CurrentTileAndPieceColorsAre(Color.WHITE, Color.WHITE))
            DispayPawn(ConsoleColor.Black, "♙ ");
        else if (CurrentTileAndPieceColorsAre(Color.BLACK, Color.BLACK))
            DispayPawn(ConsoleColor.White, "♙ ");
        else
            DispayPawn(ConsoleColor.Black, "♟ ");
    }

    private void DispayPawn(ConsoleColor consoleColor, string pawnStr)
    {
        Console.ForegroundColor = consoleColor;
        Console.Write(pawnStr);
    }

    private bool CurrentTileAndPieceColorsAre(Color tileColor, Color pieceColor)
        => currentTile.color == tileColor && 
            currentTile.piece.color == pieceColor;

    private bool IndexIsZero(int i) => i == 0;

    private void PieceDispaySample()
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