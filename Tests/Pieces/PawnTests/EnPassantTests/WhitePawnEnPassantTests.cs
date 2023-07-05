using Chess.Core;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces.PawnTests.EnPassantTests;

[TestFixture]
internal class WhitePawnEnPassantTests : BoardTestFixtureSetUp
{
    [Test]
    public void WhitePawn_HasEnPassantLegalMove()
    {
        Pawn whitePawn = new Pawn(board.GetTile("b5"), Color.WHITE);
        Pawn a7blackPawn = new Pawn(board.GetTile("a7"), Color.BLACK);
        Pawn c7blackPawn = new Pawn(board.GetTile("c7"), Color.BLACK);

        board.AddPiece(whitePawn);
        board.AddPiece(a7blackPawn);
        board.AddPiece(c7blackPawn);

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
}