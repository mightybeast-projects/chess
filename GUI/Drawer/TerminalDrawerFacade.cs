using Chess.Core;
using Chess.Core.Pieces;

namespace Chess.GUI.Drawer;

public class TerminalDrawerFacade
{
    private TerminalBoardDrawer boardDrawer;

    public TerminalDrawerFacade(Board board) =>
        boardDrawer = new TerminalBoardDrawer(board);

    public void Draw()
    {
        if (OperatingSystem.IsWindows())
            Console.OutputEncoding = System.Text.Encoding.Unicode;

        boardDrawer.DrawBoard();

        Console.WriteLine("Waiting for input...");
    }

    public void EnableHintsForPiece(Piece piece) =>
        boardDrawer.hintPiece = piece;
}