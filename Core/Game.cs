namespace Chess.Core;

public class Game
{
    public readonly Board board;
    public Player currentPlayer;

    internal Player whitePlayer;
    internal Player blackPlayer;

    public Game()
    {
        board = new Board();
        whitePlayer = new Player(Color.WHITE);
        blackPlayer = new Player(Color.BLACK);
    }

    public void Start()
    {
        board.SetUp();
        currentPlayer = whitePlayer;
    }
}