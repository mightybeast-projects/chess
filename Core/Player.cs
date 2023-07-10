using Chess.Core.Pieces;

namespace Chess.Core;

public class Player
{
    public readonly Board board;
    public readonly Color color;
    public King king =>
        color == Color.WHITE ? board.whiteKing : board.blackKing;

    public Player(Board board, Color color)
    {
        this.board = board;
        this.color = color;
    }
}