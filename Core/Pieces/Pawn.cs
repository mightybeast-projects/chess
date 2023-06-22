namespace Chess.Core.Pieces;

public class Pawn : Piece
{
    private bool pathBlocked;

    public Pawn(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitPawn(this);

    protected override void UpdateLegalMoves()
    {
        legalMovesList = new List<Tile>();

        if (color == Color.WHITE)
            UpdatePawnHints(1, 1);
        else
            UpdatePawnHints(-1, 6);
    }

    protected override void AddLegalMove(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return;

        Tile hintTile = board.grid[tile.i + i, tile.j + j];

        if (!hintTile.isEmpty)
            pathBlocked = true;
        else
            legalMovesList.Add(hintTile);
    }

    protected override IEnumerable<Tile> GetTilesUnderAttack() =>
        color == Color.WHITE ?
            GetPawnTilesUnderAttack(1) :
            GetPawnTilesUnderAttack(-1);

    protected override Tile GetTileUnderAttack(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return null;

        return board.grid[tile.i + i, tile.j + j];
    }

    private void UpdatePawnHints(int colorMultiplier, int pawnRowIndex)
    {
        AddLegalMove(colorMultiplier, 0);

        if (!pathBlocked && tile.i == pawnRowIndex)
            AddLegalMove(colorMultiplier * 2, 0);

        AddCaptureLegalMoves();
    }

    private void AddCaptureLegalMoves()
    {
        foreach (Tile tile in tilesUnderAttack)
            if (TileIsOccupiedByEnemy(tile))
                legalMovesList.Add(tile);
    }

    private IEnumerable<Tile> GetPawnTilesUnderAttack(int colorMultiplier) =>
    new Tile[]
    {
        GetTileUnderAttack(colorMultiplier, -1),
        GetTileUnderAttack(colorMultiplier, 1)
    };
}