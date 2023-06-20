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
        piece.board = board;

        if (piece.color == Color.WHITE)
            whitePieces.Add(piece);
        else
            blackPieces.Add(piece);
    }

    internal void RemovePiece(Piece piece)
    {
        piece.board = null;

        if (piece.color == Color.WHITE)
            whitePieces.Remove(piece);
        else
            blackPieces.Remove(piece);
    }

    internal void SetupPieces()
    {
        SetUpPieces(Color.WHITE, 1, 0);
        SetUpPieces(Color.BLACK, 6, 7);
    }

    private void SetUpPieces(Color color, int pawnRowIndex, int pieceRowIndex)
    {
        AddPiece(new King(grid[pieceRowIndex, 4], color));

        for (int i = 0; i < grid.GetLength(0); i++)
            AddPiece(new Pawn(grid[pawnRowIndex, i], color));

        AddPiece(new Rook(grid[pieceRowIndex, 0], color));
        AddPiece(new Knight(grid[pieceRowIndex, 1], color));
        AddPiece(new Bishop(grid[pieceRowIndex, 2], color));
        AddPiece(new Queen(grid[pieceRowIndex, 3], color));
        AddPiece(new Bishop(grid[pieceRowIndex, 5], color));
        AddPiece(new Knight(grid[pieceRowIndex, 6], color));
        AddPiece(new Rook(grid[pieceRowIndex, 7], color));
    }
}