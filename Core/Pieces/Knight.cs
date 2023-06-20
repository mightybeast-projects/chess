namespace Chess.Core.Pieces;

public class Knight : Piece
{
    public Knight(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitKnight(this);

    internal override void UpdateLegalMoves()
    {
        base.UpdateLegalMoves();

        AddLegalMove(2, -1);
        AddLegalMove(2, 1);

        AddLegalMove(1, 2);
        AddLegalMove(-1, 2);

        AddLegalMove(-2, -1);
        AddLegalMove(-2, 1);

        AddLegalMove(1, -2);
        AddLegalMove(-1, -2);
    }

    protected override void AddLegalMove(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return;

        Tile hintTile = board.grid[tile.i + i, tile.j + j];

        if (hintTile.isEmpty || TileIsOccupiedByEnemy(hintTile))
            legalMovesList.Add(hintTile);
    }
}