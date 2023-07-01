namespace Chess.Core.Exceptions;

internal class CannotPromotePawnException : Exception
{
    public CannotPromotePawnException()
         : base("Chosen pawn cannot be promoted to chosen piece.") { }
}