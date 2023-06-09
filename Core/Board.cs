using Chess.Core.Exceptions;
using Chess.Core.Pieces;

namespace Chess.Core;

public class Board
{
    public readonly Tile[,] grid;
    public List<Piece> whitePieces => piecesDirector.whitePieces;
    public List<Piece> blackPieces => piecesDirector.blackPieces;
    public Piece lastMovedPiece { get; internal set; }

    internal King whiteKing => whitePieces.OfType<King>().FirstOrDefault();
    internal King blackKing => blackPieces.OfType<King>().FirstOrDefault();

    private readonly PiecesDirector piecesDirector;

    public Board()
    {
        grid = new Tile[8, 8];
        piecesDirector = new PiecesDirector(this);

        InitializeGrid();
    }

    public void SetUp() => piecesDirector.SetupPieces();

    public void AddPiece(Piece piece) => piecesDirector.AddPiece(piece);

    public void RemovePiece(Piece piece) => piecesDirector.RemovePiece(piece);

    public Tile GetTile(string tileNotation)
    {
        try { return ParseTileName(tileNotation); }
        catch (Exception) { throw new IncorrectTileNotationException(); }
    }

    public bool Contains(Piece piece)
    {
        if (piece.color == Color.WHITE)
            return whitePieces.Contains(piece);

        return blackPieces.Contains(piece);
    }

    public bool LastMovedPieceIsAPawnAvailableForPromotion() =>
        lastMovedPiece is not null &&
        lastMovedPiece.GetType() == typeof(Pawn) &&
        ((Pawn)lastMovedPiece).IsAvailableForPromotion();

    internal Tile GetClampedTile(int i, int j)
    {
        int clampedI = Math.Clamp(i, 0, grid.GetLength(0) - 1);
        int clampedJ = Math.Clamp(j, 0, grid.GetLength(0) - 1);

        return grid[clampedI, clampedJ];
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

        if (RowOrColIsOddWhileOtherIsNot(i, j))
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

    internal bool TileIndexesAreBeyondTheBoard(int i, int j) =>
        i < 0 || i > grid.GetLength(0) - 1 ||
        j < 0 || j > grid.GetLength(0) - 1;

    private bool RowOrColIsOddWhileOtherIsNot(int i, int j) =>
        j % 2 == 0 && i % 2 > 0 ||
        j % 2 > 0 && i % 2 == 0;
}