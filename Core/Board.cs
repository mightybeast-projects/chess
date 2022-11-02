using Chess.Core.Exceptions;
using Chess.Core.Pieces;

namespace Chess.Core;

public class Board
{
    public readonly Tile[,] grid;
    public readonly List<Piece> pieces;

    public Board()
    {
        grid = new Tile[8, 8];
        pieces = new List<Piece>();

        InitializeGrid();
    }

    public Tile GetTile(string tileName)
    {
        try { return ParseTileName(tileName); }
        catch (Exception) { throw new IncorrectTileNotationException(); }
    }

    public void SetUp()
    {
        SetupWhitePieces();
        SetupBlackPieces();
    }

    public Piece AddPiece(Piece piece)
    {
        piece.SetBoard(this);
        pieces.Add(piece);
        UpdatePiecesHints();
        return piece;
    }

    public void UpdatePiecesHints()
    {
        foreach (Piece p in pieces)
            p.UpdateHints();
    }

    private void InitializeGrid()
    {
        for (int i = 0; i < grid.GetLength(0); i++)
            for (int j = 0; j < grid.GetLength(1); j++)
                InitiializeTile(i, j);
    }

    private void InitiializeTile(int i, int j)
    {
        Color chosenColor;

        if (j % 2 == 0 && i % 2 == 0)
            chosenColor = Color.BLACK;
        else if (j % 2 == 0 && i % 2 > 0)
            chosenColor = Color.WHITE;
        else if (i % 2 == 0)
            chosenColor = Color.WHITE;
        else
            chosenColor = Color.BLACK;

        Tile tile = new Tile(i, j, chosenColor);
        grid[i, j] = tile;
    }

    private Tile ParseTileName(string tileName)
    {
        int symbolIndex = ((int)char.ToUpper(tileName[0])) - 64;
        int numberIndex = tileName[1] - '0';
        return grid[numberIndex - 1, symbolIndex - 1];
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
}