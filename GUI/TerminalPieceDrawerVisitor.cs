using Chess.Core;
using Chess.Core.Pieces;

namespace Chess.GUI;

public class TerminalPieceDrawerVisitor : IPieceDrawerVisitor
{
    private Tile currentTile;
    private Piece currentPiece;

    public void VisitPawn(Piece piece)
    {
        DisplayTilePiece(piece);
    }

    public void VisitRook(Piece piece)
    {
        DisplayTilePiece(piece);
    }

    private void DisplayTilePiece(Piece piece)
    {
        currentPiece = piece;
        currentTile = piece.currentTile;

        if (CurrentTileAndPieceColorsAre(Color.BLACK, Color.WHITE))
            DispayPawn(ConsoleColor.White, "♟ ");
        else if (CurrentTileAndPieceColorsAre(Color.WHITE, Color.WHITE))
            DispayPawn(ConsoleColor.Black, "♙ ");
        else if (CurrentTileAndPieceColorsAre(Color.BLACK, Color.BLACK))
            DispayPawn(ConsoleColor.White, "♙ ");
        else
            DispayPawn(ConsoleColor.Black, "♟ ");
    }

    private void DispayPawn(ConsoleColor consoleColor, string pawnStr)
    {
        Console.ForegroundColor = consoleColor;
        Console.Write(pawnStr);
    }

    private bool CurrentTileAndPieceColorsAre(Color tileColor, Color pieceColor)
        => currentTile.color == tileColor && 
            currentPiece.color == pieceColor;
}