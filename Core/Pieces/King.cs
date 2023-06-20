namespace Chess.Core.Pieces;

public class King : Piece
{
    public bool isChecked => CheckForCheck();

    public King(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitKing(this);

    protected override void UpdateLegalMoves()
    {
        legalMovesList = new List<Tile>();

        AddDiagonalLegalMoves();
        AddAxisLegalMoves();
    }

    protected override void AddLegalMove(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return;

        Tile hintTile = board.GetClampedTile(tile.i + i, tile.j + j);

        if (hintTile.isEmpty || TileIsOccupiedByEnemy(hintTile))
            legalMovesList.Add(hintTile);
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

    private bool CheckForCheck()
    {
        List<Piece> enemyPieces =
            (color == Color.WHITE) ? board.blackPieces : board.whitePieces;

        foreach (Piece enemyPiece in enemyPieces.Skip(1))
            foreach (Tile move in enemyPiece.legalMoves)
                if (tile == move)
                    return true;
        return false;
    }
}