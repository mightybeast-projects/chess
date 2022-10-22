using Chess.Core;

public class Terminal
{
    private TerminalDrawer drawer;
    private Board board;

    public void Run()
    {
        board = new Board();
        drawer = new TerminalDrawer(board);

        board.SetUp();
        drawer.Draw();
    }
}