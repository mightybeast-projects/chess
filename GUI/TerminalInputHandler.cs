using Chess.Core;
using Chess.Core.Pieces;

public class TerminalInputHandler
{
    private TerminalDrawer drawer;
    private Board board;
    private Piece chosenPiece;
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
        
        if (input != null)
            HandleChosenPiece();

        drawer.Draw();
    }

    private void HandleChosenPiece()
    {
        if (input.Length == 0) return;

        chosenPiece = board.GetTile(input.Substring(0, 2)).piece;

        if (input.Length == 2 || InputHaveHintCommand())
            drawer.EnableHintsForPiece(chosenPiece);
        else if (InputHaveMoveCommand())
            chosenPiece.Move(input.Substring(6, 2));
    }

    private void HandleException(Exception e)
    {
        Console.Clear();
        drawer.Draw();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(e.Message);
        Console.ResetColor();
    }

    private bool InputHaveMoveCommand() 
        => input.Length == 8 && input[4] == 'm';

    private bool InputHaveHintCommand()
        => input.Length == 5 && input[4] == 'h';
}