using Chess.Core;
using Chess.Core.Pieces;
using Chess.GUI;

public class TerminalDrawer
{
    private Board board;
    private IPieceDrawerVisitor pieceDrawerVisitor;
    private Piece? hintPiece;
    private Tile currentTile;
    private ConsoleColor bgColor;
    private int tileColorIndex;

    public TerminalDrawer(Board board)
    {
        this.board = board;
        pieceDrawerVisitor = new TerminalPieceDrawerVisitor();
    }

    public void Draw()
    {
        Console.Clear();

        for (int i = board.grid.GetLength(0) - 1; i >= 0; i--)
            DrawBoardLine(i);
        
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

    private void DrawBoardLine(int i)
    {
        for (int j = 0; j < board.grid.GetLength(1) + 1; j++)
            HandleGridPosition(i, j);

        Console.WriteLine();

        if (IndexIsZero(i))
            DrawLetterLine();
    }

    private void DrawLetterLine()
    {
        Console.ResetColor();

        for (int i = 0; i < board.grid.GetLength(0) + 1; i++)
            HandleLetterLinePosition(i);

        Console.WriteLine();
    }

    private void HandleGridPosition(int i, int j)
    {
        if (IndexIsZero(j))
            DrawNumber(i);
        else
            DrawTile(i, j - 1);
    }

    private void HandleLetterLinePosition(int i)
    {
        if (IndexIsZero(i))
            Console.Write("  ");
        else
            DrawLetter(i);
    }

    private void DrawNumber(int i)
    {
        Console.ResetColor();
        Console.Write(Math.Abs(-1 - i) + " ");
    }

    private void DrawLetter(int i)
    {
        char letter = (char)(i - 1 + 65);
        Console.Write(letter.ToString().ToLower() + " ");
    }

    private void DrawTile(int i, int j)
    {
        currentTile = board.grid[i, j];

        ChooseBackgroundColor();

        if (currentTile.isEmpty)
            Console.Write("  ");
        else
            currentTile.piece.Accept(pieceDrawerVisitor);
    }

    private void ChooseBackgroundColor()
    {
        tileColorIndex = (int)currentTile.color;

        if (CurrentTileIsAHint())
            bgColor = ConsoleColor.DarkGreen;
        else
            ChooseSimpleTileColor();

        Console.BackgroundColor = bgColor;
    }

    private void ChooseSimpleTileColor()
    {
        if (tileColorIndex == 0)
            bgColor = ConsoleColor.Black;
        else
            bgColor = ConsoleColor.White;
    }

    private bool CurrentTileIsAHint() 
        => hintPiece != null && hintPiece.legalMoves.Contains(currentTile);

    private bool IndexIsZero(int i) => i == 0;
}