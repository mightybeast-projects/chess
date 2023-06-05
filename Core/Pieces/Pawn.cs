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
        if (currentTile.i + i < 0 ||
            currentTile.i + i > board.grid.GetLength(0) - 1 ||
            currentTile.j + j < 0 ||
            currentTile.j + j  > board.grid.GetLength(0) - 1)
                return;

        int clampedI = Math.Clamp(currentTile.i + i, 0, board.grid.GetLength(0) - 1);
        int clampedJ = Math.Clamp(currentTile.j + j, 0, board.grid.GetLength(0) - 1);

        hintTile = board.grid[clampedI, clampedJ];

        if (HintTileIsOccupiedByEnemy())
            _legalMoves.Add(hintTile);
    }

    protected override void AddLegalMove(int i, int j)
    {
        if (currentTile.i + i < 0 ||
            currentTile.i + i > board.grid.GetLength(0) - 1 ||
            currentTile.j + j < 0 ||
            currentTile.j + j  > board.grid.GetLength(0) - 1)
                return;

        int clampedI = Math.Clamp(currentTile.i + i, 0, board.grid.GetLength(0) - 1);
        int clampedJ = Math.Clamp(currentTile.j + j, 0, board.grid.GetLength(0) - 1);

        hintTile = board.grid[clampedI, clampedJ];

        if (!hintTile.isEmpty)
            pathBlocked = true;
        else
            _legalMoves.Add(hintTile);
    }
}