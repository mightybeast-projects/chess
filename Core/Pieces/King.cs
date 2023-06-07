namespace Chess.Core.Pieces;

public class King : Piece
{
    public King(Board board, Tile tile, Color color) :
        base(board, tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitKing(this);

    protected override void UpdateLegalMoves()
    {
        base.UpdateLegalMoves();

        AddDiagonalLegalMoves();
        AddAxisLegalMoves();
    }

    private void AddDiagonalLegalMoves()
    {
        AddLegalMove(1, -1);
        AddLegalMove(1, 1);
        AddLegalMove(-1, 1);
        AddLegalMove(-1, -1);
    }

    private void AddAxisLegalMoves()
    {
        AddLegalMove(1, 0);
        AddLegalMove(0, 1);
        AddLegalMove(-1, 0);
        AddLegalMove(0, -1);
    }

    protected override void AddLegalMove(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return;
    
        Tile hintTile = board.GetClampedTile(tile.i + i, tile.j + j);

        if (hintTile.isEmpty || TileIsOccupiedByEnemy(hintTile))
            legalMoves.Add(hintTile);
    }
}