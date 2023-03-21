using Chess.Core;
using Chess.Core.Pieces;
using Chess.GUI;
using Chess.GUI.Drawer;

public class Terminal
{
    private TerminalDrawerFacade drawer;
    private TerminalInputHandler inputHandler;
    private Board board;

    public void Run()
    {
        board = new Board();
        drawer = new TerminalDrawerFacade(board);
        inputHandler = new TerminalInputHandler(board, drawer);

        board.SetUp();
        drawer.Draw();

        while (true)
            inputHandler.GetInput();
    }
}