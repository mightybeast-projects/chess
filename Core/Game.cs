using chess.Core.Exceptions;
using Chess.Core.Pieces;

namespace Chess.Core;

public class Game
{
    public readonly Board board;
    public Player currentPlayer;

    internal Player whitePlayer;
    internal Player blackPlayer;
    internal King whiteKing => (King)board.whitePieces[0];
    internal King blackKing => (King)board.blackPieces[0];

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
        Piece piece = board.GetTile(piecePosition).piece!;

        if (piece is null)
            return;

        if (piece.color != currentPlayer.color)
            throw new CannotMoveEnemyPieceException();

        piece.Move(targetPosition);

        if (currentPlayer.color == Color.WHITE)
            CheckForCheck(board.whitePieces, blackKing);
        else
            CheckForCheck(board.blackPieces, whiteKing);

        if (currentPlayer == whitePlayer)
            currentPlayer = blackPlayer;
        else
            currentPlayer = whitePlayer;
    }

    public void CheckForCheck(List<Piece> pieces, King enemyKing)
    {
        foreach (Piece blackPiece in pieces)
        {
            foreach (Tile move in blackPiece.legalMoves)
            {
                if (enemyKing.tile == move)
                {
                    enemyKing.isChecked = true;
                    return;
                }
            }
        }
    }
}