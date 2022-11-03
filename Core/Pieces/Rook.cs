namespace Chess.Core.Pieces;

public class Rook : DirectionalPiece
{
    public Rook(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor)
    {
        visitor.VisitRook(this);
    }

    public override void UpdateHints()
    {
        base.UpdateHints();

        AddHintTilesInDirection(1, 0);
        AddHintTilesInDirection(-1, 0);
        AddHintTilesInDirection(0, 1);
        AddHintTilesInDirection(0, -1);
    }
}