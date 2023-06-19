using Chess.Core.Pieces;

namespace Chess.Core;

internal class PiecesDirector
{
    internal readonly List<Piece> whitePieces;
    internal readonly List<Piece> blackPieces;

    private Board board;
    private Tile[,] grid;

    internal PiecesDirector(Board board)
    {
        whitePieces = new List<Piece>();
        blackPieces = new List<Piece>();
        this.board = board;
        grid = board.grid;
    }

    internal void AddPiece(Piece piece)
    {
        if (piece.color == Color.WHITE)
            whitePieces.Add(piece);
        else
            blackPieces.Add(piece);
    }

    internal void SetupPieces()
    {
        SetUpPieces(Color.WHITE, 1, 0);
        SetUpPieces(Color.BLACK, 6, 7);
    }

    private void SetUpPieces(Color color, int pawnRowIndex, int pieceRowIndex)
    {
        AddPiece(new King(board, grid[pieceRowIndex, 4], color));

        for (int i = 0; i < grid.GetLength(0); i++)
            AddPiece(new Pawn(board, grid[pawnRowIndex, i], color));

        AddPiece(new Rook(board, grid[pieceRowIndex, 0], color));
        AddPiece(new Knight(board, grid[pieceRowIndex, 1], color));
        AddPiece(new Bishop(board, grid[pieceRowIndex, 2], color));
        AddPiece(new Queen(board, grid[pieceRowIndex, 3], color));
        AddPiece(new Bishop(board, grid[pieceRowIndex, 5], color));
        AddPiece(new Knight(board, grid[pieceRowIndex, 6], color));
        AddPiece(new Rook(board, grid[pieceRowIndex, 7], color));
    }
}