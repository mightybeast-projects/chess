namespace Chess.Core.Pieces;

public class King : Piece
{
    public bool isChecked => CheckForCheck();
    private static bool breakLegalMoveCycle;

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
        if (breakLegalMoveCycle)
            return;

        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return;

        Tile hintTile = board.GetClampedTile(tile.i + i, tile.j + j);

        if (TileIsOccupiedByAlly(hintTile) || TileIsUnderAttack(hintTile))
            return;

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
        foreach (Piece enemyPiece in GetEnemyPieces().Skip(1))
            foreach (Tile move in enemyPiece.legalMoves)
                if (tile == move)
                    return true;
        return false;
    }

    private bool TileIsUnderAttack(Tile tile)
    {
        breakLegalMoveCycle = true;

        Piece enemyPiece = null;
        if (TileIsOccupiedByEnemy(tile))
        {
            enemyPiece = tile.piece;
            board.RemovePiece(tile.piece);
        }

        bool tileIsUnderAttack = false;
        Pawn pawn = new Pawn(tile, color);
        board.AddPiece(pawn);

        foreach (Piece piece in GetEnemyPieces())
        {
            if (piece.legalMoves.Contains(tile))
            {
                tileIsUnderAttack = true;
                break;
            }
        }

        board.RemovePiece(pawn);
        if (enemyPiece is not null)
            board.AddPiece(enemyPiece);

        breakLegalMoveCycle = false;

        return tileIsUnderAttack;
    }

    private bool TileIsOccupiedByAlly(Tile tile) =>
        !tile.isEmpty && tile.piece.color == color;

    private List<Piece> GetEnemyPieces() =>
        color == Color.WHITE ? board.blackPieces : board.whitePieces;
}