namespace Chess.Core.Exceptions;

internal class IncorrectTileNotationException : Exception
{
    public IncorrectTileNotationException()
        : base("Given notation is incorrect") { }
}