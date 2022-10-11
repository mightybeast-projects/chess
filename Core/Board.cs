using Chess.Core.Exceptions;

namespace Chess.Core;

public class Board
{
    public Tile[,] grid => _grid;

    private Tile[,] _grid;

    public Board()
    {
        InitializeGrid();
    }

    public Tile GetTile(string tileName)
    {
        try { return ParseTileName(tileName); }
        catch (Exception) { throw new IncorrectTileNotationException(); }
    }

    public Piece AddPiece(Piece piece)
    {
        piece.board = this;
        return piece;
    }

    private void InitializeGrid()
    {
        _grid = new Tile[8, 8];

        for (int i = 0; i < _grid.GetLength(0); i++)
            for (int j = 0; j < _grid.GetLength(1); j++)
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
        _grid[i, j] = tile;
    }

    private Tile ParseTileName(string tileName)
    {
        int symbolIndex = ((int)char.ToUpper(tileName[0])) - 64;
        int numberIndex = tileName[1] - '0';
        return _grid[numberIndex - 1, symbolIndex - 1];
    }
}