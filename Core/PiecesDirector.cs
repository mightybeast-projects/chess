using Chess.Core.Pieces;

namespace Chess.Core;

public class PiecesDirector
{
    private Board board;
    private Tile[,] grid;

    public PiecesDirector(Board board)
    {
        this.board = board;
        grid = board.grid;
    }

    public void SetupPieces()
    {
        SetupWhitePieces();
        SetupBlackPieces();
    }

    private void SetupWhitePieces()
    {
        for (int i = 0; i < grid.GetLength(0); i++)
            AddPiece(new Pawn(grid[1, i], Color.WHITE));

        AddPiece(new Rook(grid[0, 0], Color.WHITE));
        AddPiece(new Rook(grid[0, 7], Color.WHITE));

        AddPiece(new Knight(grid[0, 1], Color.WHITE));
        AddPiece(new Knight(grid[0, 6], Color.WHITE));

        AddPiece(new Bishop(grid[0, 2], Color.WHITE));
        AddPiece(new Bishop(grid[0, 5], Color.WHITE));
    }

    private void SetupBlackPieces()
    {
        for (int i = 0; i < grid.GetLength(0); i++)
            AddPiece(new Pawn(grid[6, i], Color.BLACK));

        AddPiece(new Rook(grid[7, 0], Color.BLACK));
        AddPiece(new Rook(grid[7, 7], Color.BLACK));

        AddPiece(new Knight(grid[7, 1], Color.BLACK));
        AddPiece(new Knight(grid[7, 6], Color.BLACK));

        AddPiece(new Bishop(grid[7, 2], Color.BLACK));
        AddPiece(new Bishop(grid[7, 5], Color.BLACK));
    }

    private void AddPiece(Piece piece)
    {
        board.AddPiece(piece);
    }
}