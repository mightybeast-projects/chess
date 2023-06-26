namespace Chess.Core.Pieces;

public class Pawn : Piece
{
    private bool pathBlocked;

    public Pawn(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitPawn(this);

    protected override IEnumerable<Tile> GetLegalMoves() =>
        color == Color.WHITE ?
            GetPawnHints(1) :
            GetPawnHints(-1);

    protected override Tile GetLegalMove(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return null;

        Tile hintTile = board.grid[tile.i + i, tile.j + j];

        if (!hintTile.isEmpty)
        {
            pathBlocked = true;
            return null;
        }

        if (KingIsUnderCheckAfterMoveOn(hintTile))
            return null;

        return hintTile;
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

    private IEnumerable<Tile> GetPawnHints(int colorMultiplier)
    {
        List<Tile> pawnHints = new List<Tile>();

        pawnHints.Add(GetLegalMove(colorMultiplier, 0));

        if (!pathBlocked && !hasMoved)
            pawnHints.Add(GetLegalMove(colorMultiplier * 2, 0));

        pawnHints.AddRange(GetCaptureLegalMoves());

        return pawnHints;
    }

    private IEnumerable<Tile> GetCaptureLegalMoves() =>
        tilesUnderAttack.ConvertAll(tile =>
            TileIsOccupiedByEnemy(tile) ? tile : null);

    private IEnumerable<Tile> GetPawnTilesUnderAttack(int colorMultiplier) =>
    new Tile[]
    {
        GetTileUnderAttack(colorMultiplier, -1),
        GetTileUnderAttack(colorMultiplier, 1)
    };
}