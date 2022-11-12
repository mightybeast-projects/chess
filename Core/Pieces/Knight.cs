namespace Chess.Core.Pieces;

public class Knight : Piece
{
    public Knight(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        visitor.VisitKnight(this);
    }

    public override void UpdateLegalMoves()
    {
        base.UpdateLegalMoves();

        AddTopLHintTiles();
        AddRightLHintTiles();
        AddBottomLHintTiles();
        AddLeftLHintTiles();
    }

    private void AddTopLHintTiles()
    {
        TryToAddLegalMove(2, -1);
        TryToAddLegalMove(2, 1);
    }

    private void AddRightLHintTiles()
    {
        TryToAddLegalMove(1, 2);
        TryToAddLegalMove(-1, 2);
    }

    private void AddBottomLHintTiles()
    {
        TryToAddLegalMove(-2, -1);
        TryToAddLegalMove(-2, 1);
    }

    private void AddLeftLHintTiles()
    {
        TryToAddLegalMove(1, -2);
        TryToAddLegalMove(-1, -2);
    }

    protected override void AddLegalMove(int i, int j)
    {
        hintTile = board.grid[currentTile.i + i, currentTile.j + j];

        if (hintTile.isEmpty || HintTileIsOccupiedByEnemy())
            legalMoves.Add(hintTile);
    }
}