using Chess.Core;
using Chess.Core.Pieces;

public class Terminal
{
    private TerminalDrawer drawer;
    private Board board;
    private string input;

    public void Run()
    {
        board = new Board();
        drawer = new TerminalDrawer(board);

        board.SetUp();
        
        drawer.Draw();

        while (true) 
            RunGame();
    }

    private void RunGame()
    {
        try { HandleInput(); }
        catch (Exception e) { HandleException(e); }
    }

    private void HandleInput()
    {
        input = Console.ReadLine()!;
        Console.Clear();
        drawer.SetHintPiece(board.GetTile(input).piece);
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

    private void BoardPositionSmaple()
    {
        Piece c5pawn = new Pawn(board.GetTile("c5"), Color.BLACK);
        Piece d4pawn = new Pawn(board.GetTile("d4"), Color.WHITE);
        Piece e5pawn = new Pawn(board.GetTile("e5"), Color.BLACK);
        board.AddPiece(c5pawn);
        board.AddPiece(d4pawn);
        board.AddPiece(e5pawn);
    }
}