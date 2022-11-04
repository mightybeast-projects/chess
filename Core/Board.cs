using Chess.Core.Exceptions;
using Chess.Core.Pieces;

namespace Chess.Core;

public class Board
{
    public readonly Tile[,] grid;
    public List<Piece> pieces => piecesDirector.pieces;

    private readonly PiecesDirector piecesDirector;

    public Board()
    {
        grid = new Tile[8, 8];
        piecesDirector = new PiecesDirector(this);

        InitializeGrid();
    }

    public Tile GetTile(string tileName)
    {
        try { return ParseTileName(tileName); }
        catch (Exception) { throw new IncorrectTileNotationException(); }
    }

    public void SetUp()
    {
        piecesDirector.SetupPieces();
    }

    public Piece AddPiece(Piece piece)
    {
        return piecesDirector.AddPiece(piece);
    }

    public void Update()
    {
        piecesDirector.UpdatePiecesHints();
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
}