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
            DispayPiece(ConsoleColor.White, "♟ ");
        else if (CurrentTileAndPieceColorsAre(Color.WHITE, Color.WHITE))
            DispayPiece(ConsoleColor.Black, "♙ ");
        else if (CurrentTileAndPieceColorsAre(Color.BLACK, Color.BLACK))
            DispayPiece(ConsoleColor.White, "♙ ");
        else
            DispayPiece(ConsoleColor.Black, "♟ ");
    }

    private void DispayPiece(ConsoleColor foregroundColor, string pawnStr)
    {
        Console.ForegroundColor = foregroundColor;
        Console.Write(pawnStr);
    }

    private bool CurrentTileAndPieceColorsAre(Color tileColor, Color pieceColor)
        => currentTile.color == tileColor && 
            currentPiece.color == pieceColor;
}