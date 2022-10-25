namespace Chess.Tests.Pieces.Pawns;

interface IPawnTest
{
    void PawnInitialization();
    void PawnHasOneHintTile();
    void PawnHasTwoHintTiles();
    void PawnHasNoHintTilesOnTheEdgeOfTheBoard();
    void PawnHasNoHintsWhenPathBlocked();
    void PawnHasOneHintTileAndOneCapture();
    void PawnHasOneHintTileAndTwoCaptures();
}