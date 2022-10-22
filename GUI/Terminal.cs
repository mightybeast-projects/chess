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

    private void BoardPositionSample()
    {
        Piece c5pawn = new Pawn(board.GetTile("c5"), Color.BLACK);
        Piece d4pawn = new Pawn(board.GetTile("d4"), Color.WHITE);
        Piece e5pawn = new Pawn(board.GetTile("e5"), Color.BLACK);
        board.AddPiece(c5pawn);
        board.AddPiece(d4pawn);
        board.AddPiece(e5pawn);
    }
}