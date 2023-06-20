using chess.Core.Exceptions;
using Chess.Core.Pieces;

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

    public void HandlePlayerMove(string piecePosition, string targetPosition)
    {
        Piece piece = board.GetTile(piecePosition).piece;

        if (piece is null)
            return;

        if (piece.color != currentPlayer.color)
            throw new CannotMoveEnemyPieceException();

        piece.Move(targetPosition);

        if (currentPlayer == whitePlayer)
            currentPlayer = blackPlayer;
        else
            currentPlayer = whitePlayer;
    }
}