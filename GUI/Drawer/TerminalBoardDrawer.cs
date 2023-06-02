using Chess.Core;
using Chess.Core.Pieces;

namespace Chess.GUI.Drawer;

public class TerminalBoardDrawer
{
    public Piece hintPiece;

    private IPieceDrawerVisitor pieceDrawerVisitor;
    private TerminalDrawerDecorator drawerDecorator;
    private Board board;
    private Tile currentTile;
    private ConsoleColor bgColor;
    private int tileColorIndex;

    public TerminalBoardDrawer(Board board)
    {
        this.board = board;

        pieceDrawerVisitor = new TerminalPieceDrawerVisitor();
        drawerDecorator = new TerminalDrawerDecorator(board);
    }

    public void DrawBoard()
    {
        Console.Clear();

        for (int i = board.grid.GetLength(0) - 1; i >= 0; i--)
            DrawBoardRow(i);
        
        DisableHints();
    }

    private void DrawBoardRow(int i)
    {
        if (i == 7)
            drawerDecorator.DrawLetterLine();

        for (int j = 0; j < board.grid.GetLength(1); j++)
            HandleGridPosition(i, j);

        Console.WriteLine();

        if (i == 0)
            drawerDecorator.DrawLetterLine();
    }

    private void HandleGridPosition(int i, int j)
    {
        if (j == 0)
            drawerDecorator.DrawNumber(i);
        
        DrawTile(i, j);

        if (j == 7)
            drawerDecorator.DrawNumber(i);
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

    private void DisableHints()
    {
        hintPiece = null;
    }

    private bool CurrentTileIsAHint() 
        => hintPiece != null && hintPiece.legalMoves.Contains(currentTile);
}