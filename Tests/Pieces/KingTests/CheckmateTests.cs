using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.KingTests;

[TestFixture]
public class CheckmateTests
{
    [Test]
    public void WhiteKing_IsCheckmated()
    {
        Board board = new Board();

        King whiteKing = new King(board.GetTile("h1"), Color.WHITE);

        board.AddPiece(whiteKing);
        board.AddPiece(new Pawn(board.GetTile("h2"), Color.WHITE));

        board.AddPiece(new King(board.GetTile("b8"), Color.BLACK));
        board.AddPiece(new Bishop(board.GetTile("e4"), Color.BLACK));
        board.AddPiece(new Rook(board.GetTile("g6"), Color.BLACK));

        Assert.IsTrue(whiteKing.isCheckmated);
    }

    [Test]
    public void FoolsMate()
    {
        Game game = new Game();

        game.Start();

        game.HandlePlayerMove("f2", "f3");
        game.HandlePlayerMove("e7", "e5");
        game.HandlePlayerMove("g2", "g4");
        game.HandlePlayerMove("d8", "h4");

        Assert.IsTrue(game.board.whiteKing.isCheckmated);
    }
}