using Chess.Core;
using Chess.Core.Pieces;

namespace Chess.GUI;

public class TerminalPieceDrawerVisitor : IPieceDrawerVisitor
{
    private Tile currentTile;
    private Piece currentPiece;
    private string filledPieceStr;
    private string emptiedPieceStr;

    public void VisitPawn(Piece piece)
    {
        filledPieceStr = "♟ ";
        emptiedPieceStr = "♙ ";

        DrawTilePiece(piece);
    }

    public void VisitRook(Piece piece)
    {
        filledPieceStr = "♜ ";
        emptiedPieceStr = "♖ ";

        DrawTilePiece(piece);
    }

    private void DrawTilePiece(Piece piece)
    {
        currentPiece = piece;
        currentTile = piece.currentTile;

        if (CurrentTileAndPieceColorsAre(Color.BLACK, Color.WHITE))
            DrawPiece(ConsoleColor.White, filledPieceStr);
        else if (CurrentTileAndPieceColorsAre(Color.WHITE, Color.WHITE))
            DrawPiece(ConsoleColor.Black, emptiedPieceStr);
        else if (CurrentTileAndPieceColorsAre(Color.BLACK, Color.BLACK))
            DrawPiece(ConsoleColor.White, emptiedPieceStr);
        else
            DrawPiece(ConsoleColor.Black, filledPieceStr);
    }

    private void DrawPiece(ConsoleColor foregroundColor, string pieceStr)
    {
        Console.ForegroundColor = foregroundColor;
        Console.Write(pieceStr);
    }

    private bool CurrentTileAndPieceColorsAre(Color tileColor, Color pieceColor)
        => currentTile.color == tileColor && 
            currentPiece.color == pieceColor;
}