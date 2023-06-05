using Chess.Core;
using Chess.Core.Pieces;

public class Pawn : Piece
{
    private bool pathBlocked;

    public Pawn(Tile tile, Color color) : base (tile, color) { }

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

        if (!pathBlocked && currentTile.i == pawnRowIndex)
            AddLegalMove(colorMultiplier * 2, 0);
    }

    private void AddCaptureLegalMove(int i, int j)
    {
        if (HintTileIsBeyondTheBoard(currentTile.i + i, currentTile.j + j))
            return;

        hintTile = GetClampedHintTile(currentTile.i + i, currentTile.j + j);

        if (HintTileIsOccupiedByEnemy())
            _legalMoves.Add(hintTile);
    }

    protected override void AddLegalMove(int i, int j)
    {
        if (HintTileIsBeyondTheBoard(currentTile.i + i, currentTile.j + j))
            return;

        hintTile = GetClampedHintTile(currentTile.i + i, currentTile.j + j);

        if (!hintTile.isEmpty)
            pathBlocked = true;
        else
            _legalMoves.Add(hintTile);
    }
}