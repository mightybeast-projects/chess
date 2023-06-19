using Chess.Core;
using Chess.GUI;
using Chess.GUI.Drawer;

public class Terminal
{
    private TerminalDrawerFacade drawer;
    private TerminalInputHandler inputHandler;
    private Game game;

    public void Run()
    {
        game = new Game();
        drawer = new TerminalDrawerFacade(game);
        inputHandler = new TerminalInputHandler(game, drawer);

        game.Start();
        drawer.Draw();

        while (true)
            inputHandler.GetInput();
    }
}