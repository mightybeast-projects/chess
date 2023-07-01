namespace Chess.Core.Exceptions;

internal class MovedPawnIsAvailableForPromotionException : Exception
{
    public MovedPawnIsAvailableForPromotionException()
        : base("Last moved piece is a pawn availbale for promotion. Pawn promotion is mandatory.") { }
}