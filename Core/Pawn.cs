using Chess.Core;

class Pawn : Piece
{
    public Pawn(Tile tile, Color color) : 
        base (tile, color)
    {
        
    }

    protected override void AddHints()
    {
        Tile hintTile = board.GetTile("a3");
        hints.Add(hintTile);
    }
}