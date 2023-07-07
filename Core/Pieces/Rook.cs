using System.Numerics;

namespace Chess.Core.Pieces;

public class Rook : SlidingPiece
{
    protected override List<Vector2> legalMovesDirections => new List<Vector2>()
    {
        new Vector2(1, 0),
        new Vector2(-1, 0),
        new Vector2(0, 1),
        new Vector2(0, -1)
    };

    public Rook(Tile tile, Color color) : base(tile, color) { }

    public override void Accept(IPieceDrawerVisitor visitor) =>
        visitor.VisitRook(this);
}