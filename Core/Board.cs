namespace Chess.Core;

public class Board
{
    public Tile[,] grid;

    public Board()
    {
        InitializeGrid();
    }

    internal Tile GetTile(string tileName)
    {
        int symbolIndex = ((int) char.ToUpper(tileName[0])) - 64; 
        int numberIndex = tileName[1] - '0';
        return grid[numberIndex - 1, symbolIndex - 1];
    }

    private void InitializeGrid()
    {
        grid = new Tile[8, 8];

        for (int i = 0; i < grid.GetLength(0); i++)
            for (int j = 0; j < grid.GetLength(1); j++)
                InitiializeTile(i, j);
    }

    private void InitiializeTile(int i, int j)
    {
        Tile tile = new Tile(i, j);

        if (j % 2 == 0 && i % 2 == 0)
            tile.color = TileColor.BLACK;
        else if (j % 2 == 0 && i % 2 > 0)
            tile.color = TileColor.WHITE;
        else if (i % 2 == 0)
            tile.color = TileColor.WHITE;
        else
            tile.color = TileColor.BLACK;

        grid[i, j] = tile;
    }
}