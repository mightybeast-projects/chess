using Chess.Core;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.PawnTests.EnPassantTests;

[TestFixture]
internal class BlackPawnEnPassantTests : BoardTestFixtureSetUp
{
    [Test]
    public void BlackPawn_HasEnPassantLegalMove()
    {
        Pawn blackPawn = new Pawn(board.GetTile("g4"), Color.BLACK);
        Pawn f2whitePawn = new Pawn(board.GetTile("f2"), Color.WHITE);
        Pawn h2whitePawn = new Pawn(board.GetTile("h2"), Color.WHITE);

        board.AddPiece(blackPawn);
        board.AddPiece(f2whitePawn);
        board.AddPiece(h2whitePawn);

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
}