using Chess.Core;
using Chess.Core.Pieces;

namespace Chess.GUI.Drawer;

public class TerminalDrawerFacade
{
    private TerminalDrawerDecorator decorator;
    private TerminalBoardDrawer boardDrawer;
    private Game game;

    public TerminalDrawerFacade(Game game)
    {
        this.game = game;

        decorator = new TerminalDrawerDecorator(game);
        boardDrawer = new TerminalBoardDrawer(game.board, decorator);
    }

    public void Draw()
    {
        if (OperatingSystem.IsWindows())
            Console.OutputEncoding = System.Text.Encoding.Unicode;

        boardDrawer.DrawBoard();

        decorator.DrawCurrentPlayerInfo();
    }

    public void EnableHintsForPiece(Piece piece) =>
        boardDrawer.hintPiece = piece;
}