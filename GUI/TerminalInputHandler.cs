using Chess.Core;

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
        Console.Clear();
        drawer.EnableHintsForPiece(board.GetTile(input).piece);
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