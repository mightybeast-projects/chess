namespace Chess.Core.Exceptions;

public class IncorrectTileNotationException : Exception
{
    public IncorrectTileNotationException()
        : base("Given notation is incorrect") { }
}