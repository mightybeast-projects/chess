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

    public void AddPiece(Piece piece) => pieces.Add(piece);

    public void SetupPieces()
    {
        SetUpPieces(Color.WHITE, 1, 0);
        SetUpPieces(Color.BLACK, 6, 7);
    }

    private void SetUpPieces(Color color, int pawnRowIndex, int pieceRowIndex)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
            AddPiece(new Pawn(board, grid[pawnRowIndex, i], color));

        AddPiece(new Rook(board, grid[pieceRowIndex, 0], color));
        AddPiece(new Knight(board, grid[pieceRowIndex, 1], color));
        AddPiece(new Bishop(board, grid[pieceRowIndex, 2], color));
        AddPiece(new Queen(board, grid[pieceRowIndex, 3], color));
        AddPiece(new King(board, grid[pieceRowIndex, 4], color));
        AddPiece(new Bishop(board, grid[pieceRowIndex, 5], color));
        AddPiece(new Knight(board, grid[pieceRowIndex, 6], color));
        AddPiece(new Rook(board, grid[pieceRowIndex, 7], color));
    }
}