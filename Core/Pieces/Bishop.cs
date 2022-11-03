namespace Chess.Core.Pieces;

public class Bishop : DirectionalPiece
{
    public Bishop(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        visitor.VisitBishop(this);
    }

    public override void UpdateHints()
    {
        base.UpdateHints();

        AddHintTilesInDirection(1, 1);
        AddHintTilesInDirection(1, -1);
        AddHintTilesInDirection(-1, -1);
        AddHintTilesInDirection(-1, 1);
    }
}