using Chess.Core.Pieces;

namespace Chess.Core;

public class PiecesDirector
{
    public readonly List<Piece> pieces;

    private Board board;
    private Tile[,] grid;

    public PiecesDirector(Board board)
    {
        pieces = new List<Piece>();
        this.board = board;
        grid = board.grid;
    }

    public Piece AddPiece(Piece piece)
    {
        piece.SetBoard(board);
        pieces.Add(piece);
        UpdatePiecesHints();

        return piece;
    }

    public void UpdatePiecesHints()
    {
        foreach (Piece p in pieces)
            p.UpdateHints();
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

        AddPiece(new Queen(grid[0, 3], Color.WHITE));

        AddPiece(new King(grid[0, 4], Color.WHITE));
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

        AddPiece(new Queen(grid[7, 3], Color.BLACK));

        AddPiece(new King(grid[7, 4], Color.BLACK));
    }
}