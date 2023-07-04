using Chess.Core;
using Chess.Core.Exceptions;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.GameTests;

[TestFixture]
internal class CustomGameTests : BoardTestFixtureSetUp
{
    [Test]
    public void CustomGameSetUp_IsCorrect()
    {
        Game game = new Game(board, Color.BLACK);

        Assert.AreEqual(game.board, board);
        Assert.AreEqual(game.currentPlayer.color, Color.BLACK);
    }

    [Test]
    public void Game_DoesNotSwitchCurrentPlayer_OnAvailablePawnPromotion()
    {
        Game game = new Game(board, Color.WHITE);
        Pawn pawn = new Pawn(board.GetTile("a7"), Color.WHITE);

        board.AddPiece(pawn);

        game.HandlePlayerMove("a7", "a8");

        Assert.AreEqual(Color.WHITE, game.currentPlayer.color);
    }

    [Test]
    public void LastMovedPiece_IsNotAPawn_AvailableForPromotion()
    {
        Game game = new Game(board, Color.WHITE);
        Pawn whitePawn = new Pawn(board.GetTile("a6"), Color.WHITE);
        King blackKing = new King(board.GetTile("h8"), Color.BLACK);

        board.AddPiece(whitePawn);
        board.AddPiece(blackKing);

        game.HandlePlayerMove("a6", "a7");

        Assert.IsFalse(
            game.board.LastMovedPieceIsAPawnAvailableForPromotion()
        );

        game.HandlePlayerMove("h8", "h7");

        Assert.IsFalse(
            game.board.LastMovedPieceIsAPawnAvailableForPromotion()
        );
    }

    [Test]
    public void Player_CanPromote_MovedPawn_AvailableForPromotion()
    {
        Game game = new Game(board, Color.WHITE);
        Pawn pawn = new Pawn(board.GetTile("a7"), Color.WHITE);

        board.AddPiece(pawn);

        game.HandlePlayerMove("a7", "a8");

        Assert.DoesNotThrow(() => game.PromoteMovedPawnTo(typeof(Queen)));
        Assert.AreEqual(Color.BLACK, game.currentPlayer.color);
    }

    [Test]
    public void Player_CannotPromote_MovedPawn()
    {
        Game game = new Game(board, Color.WHITE);
        Pawn pawn = new Pawn(board.GetTile("a6"), Color.WHITE);

        board.AddPiece(pawn);

        game.HandlePlayerMove("a6", "a7");

        Assert.Throws<CannotPromotePawnException>(
            () => game.PromoteMovedPawnTo(typeof(Queen))
        );
    }

    [Test]
    public void Players_CannotMoveAnyPieces_IfMovedPawn_IsAvailableForPromotion()
    {
        Game game = new Game(board, Color.WHITE);
        King whiteKing = new King(board.GetTile("a1"), Color.WHITE);
        King blackKing = new King(board.GetTile("h8"), Color.BLACK);
        Pawn whitePawn = new Pawn(board.GetTile("a7"), Color.WHITE);

        board.AddPiece(whiteKing);
        board.AddPiece(blackKing);
        board.AddPiece(whitePawn);

        game.HandlePlayerMove("a7", "a8");

        Assert.Throws<MovedPawnIsAvailableForPromotionException>(
            () => game.HandlePlayerMove("h8", "h7")
        );
        Assert.Throws<MovedPawnIsAvailableForPromotionException>(
            () => game.HandlePlayerMove("a1", "a2")
        );
    }
}