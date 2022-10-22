using Chess.Core;
using Chess.Core.Pieces;

public class TerminalInputHandler
{
    private TerminalDrawer drawer;
    private Board board;
    private string input;

    public TerminalInputHandler(Board board, TerminalDrawer drawer)
    {
        this.board = board;
        this.drawer = drawer;
    }

    public void GetInput()
    {
        try { HandleInput(); }
        catch (Exception e) { HandleException(e); }
    }

    private void HandleInput()
    {
        input = Console.ReadLine()!;
        
        if (input.Length == 2 || (input.Length == 5 && input[4] == 'h'))
            drawer.EnableHintsForPiece(board.GetTile(input).piece);
        else if (input.Length == 8 && input[4] == 'm')
        {
            Piece chosenPiece = board.GetTile(input.Substring(0, 2)).piece;
            chosenPiece.Move(input.Substring(6, 2));
            drawer.DisableHints();
        }

        Console.Clear();
        drawer.Draw();
    }

    private void HandleException(Exception e)
    {
        Console.Clear();
        drawer.Draw();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(e.Message);
        Console.ResetColor();
    }
}