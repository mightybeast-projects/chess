using Chess.Core;
using Chess.Core.Pieces;
using Chess.GUI;

public class TerminalDrawer
{
    private Board board;
    private IPieceDrawerVisitor terminalPieceDrawerVisitor;
    private Piece? hintPiece;
    private Tile currentTile;
    private ConsoleColor bgColor;
    private int tileColorIndex;

    public TerminalDrawer(Board board)
    {
        this.board = board;
        terminalPieceDrawerVisitor = new TerminalPieceDrawerVisitor();
    }

    public void Draw()
    {
        Console.Clear();

        for (int i = board.grid.GetLength(0) - 1; i >= 0; i--)
            DisplayBoardLine(i);
        
        DisableHints();
        Console.WriteLine("Waiting for input...");
    }

    public void EnableHintsForPiece(Piece piece)
    {
        hintPiece = piece;
    }

    private void DisableHints()
    {
        hintPiece = null;
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

        ChooseBackgroundColor();

        if (currentTile.isEmpty)
            Console.Write("  ");
        else
            currentTile.piece.Accept(terminalPieceDrawerVisitor);
    }

    private void ChooseBackgroundColor()
    {
        tileColorIndex = (int) currentTile.color;

        if (hintPiece != null && hintPiece.hintTiles.Contains(currentTile))
            bgColor = ConsoleColor.DarkGreen;
        else
            bgColor =
                tileColorIndex == 0 ? ConsoleColor.Black : ConsoleColor.White;

        Console.BackgroundColor = bgColor;
    }

    private bool IndexIsZero(int i) => i == 0;
}