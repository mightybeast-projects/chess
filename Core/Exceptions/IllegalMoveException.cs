namespace Chess.Core.Exceptions;

internal class IllegalMoveException : Exception
{
    public IllegalMoveException()
        : base("Illegal move for chosen piece.") { }
}