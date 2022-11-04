namespace Chess.Core.Pieces;

public class Queen : DirectionalPiece
{
    public Queen(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) { }

    public override void UpdateHints()
    {
        base.UpdateHints();

        AddHintTilesInDirection(1, 1);
        AddHintTilesInDirection(1, -1);
        AddHintTilesInDirection(-1, -1);
        AddHintTilesInDirection(-1, 1);
    }
}