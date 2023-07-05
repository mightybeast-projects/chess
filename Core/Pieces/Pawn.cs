using System.Numerics;
using System.Reflection;
using Chess.Core.Exceptions;

namespace Chess.Core.Pieces;

public class Pawn : Piece
{
    internal bool hasMovedTwoTiles;

    private int colorMultiplier => color == Color.WHITE ? 1 : -1;
    private bool pathBlocked;

    public Pawn(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitPawn(this);

    public void Promote(Type pieceType)
    {
        if (!IsAvailableForPromotion() ||
            pieceType == typeof(Pawn) ||
            pieceType == typeof(King))
            throw new CannotPromotePawnException();

        Tile pawnTile = tile;
        Board pawnBoard = board;

        board.RemovePiece(this);

        Type[] ctorTypes = new[] {
            typeof(Tile), typeof(Color)
        };
        object[] ctorArgs = new object[] {
            pawnTile, color
        };

        ConstructorInfo ctor = pieceType.GetConstructor(ctorTypes);
        object pieceObj = ctor?.Invoke(ctorArgs);
        Piece newPiece = (Piece)pieceObj!;

        pawnBoard.AddPiece(newPiece);
        newPiece.board.lastMovedPiece = newPiece;
    }

    internal bool IsAvailableForPromotion() =>
        color == Color.WHITE ? tile.i == 7 : tile.i == 0;

    protected override void HandlePositionChange()
    {
        Tile originalTile = tile;

        base.HandlePositionChange();

        if (Math.Abs(originalTile.i - tile.i) == 2)
            hasMovedTwoTiles = true;
    }

    protected override IEnumerable<Tile> GetLegalMoves()
    {
        List<Tile> pawnHints = new List<Tile>();

        pawnHints.Add(GetLegalMove(colorMultiplier, 0));

        if (CanMoveTwoTiles())
            pawnHints.Add(GetLegalMove(colorMultiplier * 2, 0));

        pawnHints.AddRange(GetCaptureLegalMoves());

        if (NeighbourPawnIsCapturableEnPassant(0, 1))
            pawnHints.Add(GetTileUnderAttack(colorMultiplier, 1));
        if (NeighbourPawnIsCapturableEnPassant(0, -1))
            pawnHints.Add(GetTileUnderAttack(colorMultiplier, -1));

        return pawnHints;
    }

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

    protected override IEnumerable<Tile> GetTilesUnderAttack() => new Tile[]
    {
        GetTileUnderAttack(colorMultiplier, -1),
        GetTileUnderAttack(colorMultiplier, 1)
    };

    protected override Tile GetTileUnderAttack(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return null;

        return board.grid[tile.i + i, tile.j + j];
    }

    private IEnumerable<Tile> GetCaptureLegalMoves() =>
        tilesUnderAttack.ConvertAll(tile =>
            TileIsOccupiedByEnemy(tile) ? tile : null);

    private bool NeighbourPawnIsCapturableEnPassant(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return false;

        Piece piece = board.grid[tile.i + i, tile.j + j].piece;

        return piece is not null &&
            board.lastMovedPiece == piece &&
            piece.GetType() == typeof(Pawn) &&
            ((Pawn)piece).hasMovedTwoTiles;
    }

    private bool CanMoveTwoTiles() =>
        !pathBlocked && (color == Color.WHITE ? tile.i == 1 : tile.i == 6);
}