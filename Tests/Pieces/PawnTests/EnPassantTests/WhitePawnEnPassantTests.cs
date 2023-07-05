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

    [Test]
    public void WhitePawn_CapturedRightEnemyPawn_OnSuccessfulEnPassantMove()
    {
        AddPawns();

        c7blackPawn.Move("c5");
        whitePawn.Move("c6");

        Assert.AreEqual(1, board.blackPieces.Count);
        Assert.IsTrue(board.GetTile("c5").isEmpty);
    }

    [Test]
    public void WhitePawn_CapturedLeftEnemyPawn_OnSuccessfulEnPassantMove()
    {
        AddPawns();

        a7blackPawn.Move("a5");
        whitePawn.Move("a6");

        Assert.AreEqual(1, board.blackPieces.Count);
        Assert.IsTrue(board.GetTile("a5").isEmpty);
    }

    [Test]
    public void WhitePawn_DoesNotCaptureEnemyPawn_OnNonEnPassantMove()
    {
        AddPawns();

        Pawn c6blackPawn = new Pawn(board.GetTile("c6"), Color.BLACK);
        Pawn c5blackPawn = new Pawn(board.GetTile("c5"), Color.BLACK);

        board.AddPiece(c6blackPawn);
        board.AddPiece(c5blackPawn);

        whitePawn.Move("c6");

        Assert.AreEqual(3, board.blackPieces.Count);
        Assert.IsFalse(board.GetTile("c5").isEmpty);
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