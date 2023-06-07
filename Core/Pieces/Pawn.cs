using Chess.Core;
using Chess.Core.Pieces;

public class Pawn : Piece
{
    private bool pathBlocked;

    public Pawn(Board board, Tile tile, Color color) :
        base(board, tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitPawn(this);

    protected override void UpdateLegalMoves()
    {
        base.UpdateLegalMoves();

        if (color == Color.WHITE)
            UpdatePawnHints(1, 1);
        else
            UpdatePawnHints(-1, 6);
    }

    private void UpdatePawnHints(int colorMultiplier, int pawnRowIndex)
    {
        AddCaptureLegalMove(colorMultiplier * 1, -1);
        AddCaptureLegalMove(colorMultiplier * 1, 1);

        AddLegalMove(colorMultiplier * 1, 0);

        if (!pathBlocked && tile.i == pawnRowIndex)
            AddLegalMove(colorMultiplier * 2, 0);
    }

    private void AddCaptureLegalMove(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return;

        Tile hintTile = board.GetClampedTile(tile.i + i, tile.j + j);

        if (TileIsOccupiedByEnemy(hintTile))
            legalMoves.Add(hintTile);
    }

    protected override void AddLegalMove(int i, int j)
    {
        if (board.TileIndexesAreBeyondTheBoard(tile.i + i, tile.j + j))
            return;

        Tile hintTile = board.GetClampedTile(tile.i + i, tile.j + j);

        if (!hintTile.isEmpty)
            pathBlocked = true;
        else
            legalMoves.Add(hintTile);
    }
}