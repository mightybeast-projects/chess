using Chess.Core;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.PawnTests.EnPassantTests;

[TestFixture]
internal class BlackPawnEnPassantTests : BoardTestFixtureSetUp
{
    private Pawn blackPawn;
    private Pawn f2whitePawn;
    private Pawn h2whitePawn;

    [Test]
    public void BlackPawn_HasEnPassantLegalMove()
    {
        AddPawns();

        f2whitePawn.Move("f4");

        Assert.That(blackPawn.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("f3"),
            board.GetTile("g3")
        }));

        h2whitePawn.Move("h4");

        Assert.That(blackPawn.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("g3"),
            board.GetTile("h3")
        }));
    }

    [Test]
    public void BlackPawn_DoesNotHaveEnPassantLegalMove_IfLastMovedPieceIsNotPawn()
    {
        AddPawns();

        Knight whiteKnight = new Knight(board.GetTile("e2"), Color.WHITE);

        board.AddPiece(whiteKnight);

        f2whitePawn.Move("f4");
        whiteKnight.Move("d4");

        AssertLegalMovesDoesNotHaveEnPassant();
    }

    [Test]
    public void BlackPawn_DoesNotHaveEnPassantLegalMove_IfPieceIsNotPawn()
    {
        AddPawns();

        Knight whiteKnight = new Knight(board.GetTile("e2"), Color.WHITE);

        board.AddPiece(whiteKnight);

        whiteKnight.Move("f4");

        AssertLegalMovesDoesNotHaveEnPassant();
    }

    [Test]
    public void WhitePawn_DoesNotHaveEnPassantLegalMove_IfEnemyPawnDidNotMoveTwoTilesAtATime()
    {
        AddPawns();

        f2whitePawn.Move("f3");
        f2whitePawn.Move("f4");

        AssertLegalMovesDoesNotHaveEnPassant();
    }

    private void AddPawns()
    {
        blackPawn = new Pawn(board.GetTile("g4"), Color.BLACK);
        f2whitePawn = new Pawn(board.GetTile("f2"), Color.WHITE);
        h2whitePawn = new Pawn(board.GetTile("h2"), Color.WHITE);

        board.AddPiece(blackPawn);
        board.AddPiece(f2whitePawn);
        board.AddPiece(h2whitePawn);
    }

    private void AssertLegalMovesDoesNotHaveEnPassant() =>
        Assert.That(blackPawn.legalMoves, Is.EquivalentTo(new Tile[] {
            board.GetTile("g3")
        }));
}