namespace Chess.Core.Pieces;

public class Queen : DirectionalPiece
{
    public Queen(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        visitor.VisitQueen(this);
    }

    public override void UpdateHints()
    {
        base.UpdateHints();

        AddHintTilesInDirection(1, 1);
        AddHintTilesInDirection(1, -1);
        AddHintTilesInDirection(-1, -1);
        AddHintTilesInDirection(-1, 1);

        AddHintTilesInDirection(1, 0);
        AddHintTilesInDirection(-1, 0);
        AddHintTilesInDirection(0, 1);
        AddHintTilesInDirection(0, -1);
    }
}