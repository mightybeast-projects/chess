class WrongMoveException : Exception
{
    public WrongMoveException()
        : base("Chosen piece cannot move to the given position.") { }
}