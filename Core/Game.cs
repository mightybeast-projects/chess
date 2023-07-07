using Chess.Core.Exceptions;
using Chess.Core.Pieces;

namespace Chess.Core;

public class Game
{
    public readonly Board board;
    public Player currentPlayer { get; private set; }

    internal readonly Player whitePlayer;
    internal readonly Player blackPlayer;

    public Game()
    {
        board = new Board();
        whitePlayer = new Player(Color.WHITE);
        blackPlayer = new Player(Color.BLACK);
    }

    public Game(Board board, Color currentPlayerColor)
    {
        this.board = board;
        whitePlayer = new Player(Color.WHITE);
        blackPlayer = new Player(Color.BLACK);
        currentPlayer = currentPlayerColor == Color.WHITE ?
            whitePlayer : blackPlayer;
    }

    public void Start()
    {
        board.SetUp();
        currentPlayer = whitePlayer;
    }

    public void HandlePlayerMove(string piecePosition, string targetPosition)
    {
        if (board.LastMovedPieceIsAPawnAvailableForPromotion())
            throw new MovedPawnIsAvailableForPromotionException();

        Piece piece = board.GetTile(piecePosition).piece;

        if (piece is null)
            return;

        if (piece.color != currentPlayer.color)
            throw new CannotMoveEnemyPieceException();

        piece.Move(targetPosition);

        if (!board.LastMovedPieceIsAPawnAvailableForPromotion())
            SwitchCurrentPlayer();
    }

    public void PromoteMovedPawnTo(Type promotionPieceType)
    {
        Tile pieceTile = board.lastMovedPiece.tile;

        ((Pawn)board.lastMovedPiece).Promote(promotionPieceType);

        SwitchCurrentPlayer();
    }

    private void SwitchCurrentPlayer()
    {
        if (currentPlayer == whitePlayer)
            currentPlayer = blackPlayer;
        else
            currentPlayer = whitePlayer;
    }
}