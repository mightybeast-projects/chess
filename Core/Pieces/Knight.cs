namespace Chess.Core.Pieces;

public class Knight : Piece
{
    public Knight(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        throw new NotImplementedException();
    }

    public override void UpdateHints()
    {
        base.UpdateHints();

        AddHintTile(2, -1);
        AddHintTile(2, 1);

        AddHintTile(1, 2);
        AddHintTile(-1, 2);

        AddHintTile(-2, -1);
        AddHintTile(-2, 1);

        AddHintTile(1, -2);
        AddHintTile(-1, -2);
    }

    private void AddHintTile(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];
        if (hintTile.isEmpty)
            hintTiles.Add(hintTile);
    }
}