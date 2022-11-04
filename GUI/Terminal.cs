using Chess.Core;
using Chess.Core.Pieces;

public class Terminal
{
    private TerminalDrawer drawer;
    private TerminalInputHandler inputHandler;
    private Board board;

    public void Run()
    {
        board = new Board();
        drawer = new TerminalDrawer(board);
        inputHandler = new TerminalInputHandler(board, drawer);

        board.SetUp();
        drawer.Draw();

        while (true)
            inputHandler.GetInput();
    }
}