namespace Chess.Core.Exceptions;

class IllegalMoveException : Exception
{
    public IllegalMoveException()
        : base("Illegal move for chosen piece.") { }
}