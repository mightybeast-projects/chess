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

        return piece;
    }

    public void SetupPieces()
    {
        SetupPieces(Color.WHITE, 1, 0);
        SetupPieces(Color.BLACK, 6, 7);
    }

    private void SetupPieces(
        Color color,
        int pawnRowIndex,
        int pieceRowIndex)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
            AddPiece(new Pawn(grid[pawnRowIndex, i], color));

        AddPiece(new Rook(grid[pieceRowIndex, 0], color));
        AddPiece(new Knight(grid[pieceRowIndex, 1], color));
        AddPiece(new Bishop(grid[pieceRowIndex, 2], color));
        AddPiece(new Queen(grid[pieceRowIndex, 3], color));
        AddPiece(new King(grid[pieceRowIndex, 4], color));
        AddPiece(new Bishop(grid[pieceRowIndex, 5], color));
        AddPiece(new Knight(grid[pieceRowIndex, 6], color));
        AddPiece(new Rook(grid[pieceRowIndex, 7], color));        
    }
}