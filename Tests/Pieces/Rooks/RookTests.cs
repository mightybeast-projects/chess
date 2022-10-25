using Chess.Core;
using Chess.Core.Pieces;
using NUnit.Framework;

namespace Chess.Tests.Pieces.Rooks;

[TestFixture]
class RookTests : PieceSetUp
{
    [Test]
    public void RookInitialization()
    {
        CreateAndAddPiece(typeof(Rook), "d4", Color.WHITE);
        AssertPiece();
    }
}