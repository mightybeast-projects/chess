using Chess.Core;
using Chess.Core.Pieces;
using Chess.GUI.Drawer;

namespace Chess.GUI;

public class TerminalInputHandler
{
    private TerminalDrawerFacade drawer;
    private Game game;
    private Piece chosenPiece;
    private string input;

    public TerminalInputHandler(Game game, TerminalDrawerFacade drawer)
    {
        this.game = game;
        this.drawer = drawer;
    }

    public void GetInput()
    {
        try { HandleInput(); }
        catch (Exception e) { HandleException(e); }
    }

    private void HandleInput()
    {
        input = Console.ReadLine();
        
        if (input != null)
            HandleChosenPiece();

        drawer.Draw();
    }

    private void HandleChosenPiece()
    {
        if (input.Length == 0) return;

        chosenPiece = game.board.GetTile(input.Substring(0, 2)).piece;

        if (input.Length == 2 || InputIsHintCommand())
            drawer.EnableHintsForPiece(chosenPiece);
        else if (InputIsMoveCommand())
            game.HandlePlayerMove(input.Substring(0, 2), input.Substring(6, 2));
    }

    private void HandleException(Exception e)
    {
        Console.Clear();
        drawer.Draw();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(e.Message);
        Console.ResetColor();
    }

    private bool InputIsHintCommand() => input.Length == 5 && input[4] == 'h';

    private bool InputIsMoveCommand() => input.Length == 8 && input[4] == 'm';
}