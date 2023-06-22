using System.Numerics;

namespace Chess.Core.Pieces;

public class Bishop : SlidingPiece
{
    protected override List<Vector2> tilesDirections => new List<Vector2>()
    {
        new Vector2(1, 1),
        new Vector2(1, -1),
        new Vector2(-1, -1),
        new Vector2(-1, 1)
    };

    public Bishop(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitBishop(this);
}