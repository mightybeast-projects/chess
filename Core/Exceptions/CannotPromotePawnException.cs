namespace Chess.Core.Exceptions;

internal class CannotPromotePawnException : Exception
{
    public CannotPromotePawnException()
         : base("Cannot promote chosen pawn.") { }
}