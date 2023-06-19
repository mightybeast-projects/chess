namespace chess.Core.Exceptions;

internal class CannotMoveEnemyPieceException : Exception
{
    public CannotMoveEnemyPieceException()
        : base("Cannot move enemy piece.") { }
}