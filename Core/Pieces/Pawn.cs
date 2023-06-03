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
        TryToAddCaptureLegalMove(colorMultiplier * 1, -1);
        TryToAddCaptureLegalMove(colorMultiplier * 1, 1);

        TryToAddLegalMove(colorMultiplier * 1, 0);

        if (!pathBlocked && currentTile.i == pawnRowIndex)
            TryToAddLegalMove(colorMultiplier * 2, 0);
    }

    private void TryToAddCaptureLegalMove(int i, int j)
    {
        try { AddCaptureLegalMove(i, j); }
        catch (IndexOutOfRangeException) { return; }
    }

    private void AddCaptureLegalMove(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (HintTileIsOccupiedByEnemy())
            legalMovesField.Add(hintTile);
    }

    protected override void AddLegalMove(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (!hintTile.isEmpty)
            pathBlocked = true;
        else
            legalMovesField.Add(hintTile);
    }
}