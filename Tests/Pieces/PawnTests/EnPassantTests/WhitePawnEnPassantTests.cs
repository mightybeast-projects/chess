using Chess.Core;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.PawnTests.EnPassantTests;

[TestFixture]
internal class WhitePawnEnPassantTests : BoardTestFixtureSetUp
{
    private Pawn whitePawn;
    private Pawn a7blackPawn;
    private Pawn c7blackPawn;


    [Test]
    public void WhitePawn_HasEnPassantLegalMove()
    {
        AddPawns();

        a7blackPawn.Move("a5");

        Assert.That(whitePawn.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("a6"),
            board.GetTile("b6")
        }));

        c7blackPawn.Move("c5");

        Assert.That(whitePawn.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("b6"),
            board.GetTile("c6")
        }));
    }

    [Test]
    public void WhitePawn_DoesNotHaveEnPassantLegalMove_IfLastMovedPieceIsNotPawn()
    {
        AddPawns();

        Knight blackKnight = new Knight(board.GetTile("d7"), Color.BLACK);

        board.AddPiece(blackKnight);

        c7blackPawn.Move("c5");
        blackKnight.Move("e5");

        AssertLegalMovesDoesNotHaveEnPassant();
    }

    [Test]
    public void WhitePawn_DoesNotHaveEnPassantLegalMove_IfPieceIsNotPawn()
    {
        AddPawns();

        Knight blackKnight = new Knight(board.GetTile("d7"), Color.BLACK);

        board.AddPiece(blackKnight);

        blackKnight.Move("c5");

        AssertLegalMovesDoesNotHaveEnPassant();
    }

    [Test]
    public void WhitePawn_DoesNotHaveEnPassantLegalMove_IfEnemyPawnDidNotMoveTwoTilesAtATime()
    {
        AddPawns();

        c7blackPawn.Move("c6");
        c7blackPawn.Move("c5");

        AssertLegalMovesDoesNotHaveEnPassant();
    }

    private void AddPawns()
    {
        whitePawn = new Pawn(board.GetTile("b5"), Color.WHITE);
        a7blackPawn = new Pawn(board.GetTile("a7"), Color.BLACK);
        c7blackPawn = new Pawn(board.GetTile("c7"), Color.BLACK);

        board.AddPiece(whitePawn);
        board.AddPiece(a7blackPawn);
        board.AddPiece(c7blackPawn);
    }

    private void AssertLegalMovesDoesNotHaveEnPassant() =>
        Assert.That(whitePawn.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("b6")
        }));
}