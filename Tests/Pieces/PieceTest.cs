using System.Reflection;
using Chess.Core;
using Chess.Core.Pieces;
using Chess.Tests.TestFixtureSetUps;
using NUnit.Framework;

namespace Chess.Tests.Pieces;

internal abstract class PieceTest<TPiece> : BoardTestFixtureSetUp
    where TPiece : Piece
{
    protected abstract Color pieceColor { get; }

    [Test]
    public void PieceInitialization()
    {
        Type pieceType = typeof(TPiece);
        string tileNotation = "d4";

        Piece piece = CreatePiece(pieceType, tileNotation, pieceColor);

        AssertPiece(piece, tileNotation);
    }

    public virtual void PieceHasCorrectLegalMoves_InGeneralCases(
        string piecePosition,
        string[] legalMoves)
    {
        Piece piece = CreatePiece(typeof(TPiece), piecePosition, pieceColor);

        AssertPieceLegalMoves(piece, legalMoves);
    }

    public virtual void PieceHasCorrectLegalMoves_InEdgeCases(
        string piecePos,
        string[] legalMoves,
        Color blockerPawnsColor,
        string[] blockerPawnsPos
        )
    {
        foreach (string pawnPos in blockerPawnsPos)
            CreatePiece(typeof(Pawn), pawnPos, blockerPawnsColor);
        Piece piece = CreatePiece(typeof(TPiece), piecePos, pieceColor);

        AssertPieceLegalMoves(piece, legalMoves);
    }

    public virtual void PieceHasCorrectTilesUnderAttack(
        string piecePosition,
        string[] tilesUnderAttack)
    {
        Piece piece = CreatePiece(typeof(TPiece), piecePosition, pieceColor);

        AssertPieceTilesUnderAttack(piece, tilesUnderAttack);
    }

    protected Piece CreatePiece(Type pieceType, string tileName, Color color)
    {
        Tile tile = board.GetTile(tileName);

        Type[] ctorTypes = new[] {
            typeof(Tile), typeof(Color)
        };
        object[] ctorArgs = new object[] {
            tile, color
        };

        ConstructorInfo ctor = pieceType.GetConstructor(ctorTypes);
        object pieceObj = ctor?.Invoke(ctorArgs);
        Piece piece = (Piece)pieceObj!;

        board.AddPiece(piece);

        return piece;
    }

    private void AssertPiece(Piece piece, string tileNotation)
    {
        Tile pieceTile = board.GetTile(tileNotation);

        Assert.AreEqual(board, piece.board);
        Assert.AreEqual(pieceTile, piece.tile);
        Assert.AreEqual(pieceTile.piece, piece);
        Assert.AreEqual(pieceColor, piece.color);
        Assert.IsFalse(pieceTile.isEmpty);
        Assert.IsTrue(board.Contains(piece));
    }

    protected void AssertPieceLegalMoves(Piece piece, string[] legalMovesArr)
    {
        Tile[] expectedLegalMoves = new Tile[piece.legalMoves.Count];
        for (int i = 0; i < piece.legalMoves.Count; i++)
            expectedLegalMoves[i] = board.GetTile(legalMovesArr[i]);

        Assert.That(piece.legalMoves, Is.EquivalentTo(expectedLegalMoves));
    }

    protected void AssertPieceTilesUnderAttack(Piece piece, string[] tilesArr)
    {
        Tile[] expectedTilesUnderAttack = new Tile[piece.tilesUnderAttack.Count];
        for (int i = 0; i < piece.tilesUnderAttack.Count; i++)
            expectedTilesUnderAttack[i] = board.GetTile(tilesArr[i]);

        Assert.That(piece.tilesUnderAttack,
            Is.EquivalentTo(expectedTilesUnderAttack)
        );
    }
}