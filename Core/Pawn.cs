using Chess.Core;

class Pawn : Piece
{
    private string _currentPositionStr;
    private string _newPositionStr;
    private string _hintTileIndexStr;
    private int _currentTileIndex;

    public Pawn(Tile tile, Color color) : base (tile, color) { }

    public override void UpdateHints()
    {
        base.UpdateHints();

        _currentPositionStr = tile.notation;
        _currentTileIndex = Int32.Parse(_currentPositionStr[1].ToString());

        AddNewHintTileWithIndex(1);
        if (hints.Count == 0) return;

        if (_currentTileIndex == 2)
            AddNewHintTileWithIndex(2);
    }

    private void AddNewHintTileWithIndex(int tileIndex)
    {
        _hintTileIndexStr = (_currentTileIndex + tileIndex).ToString();
        _newPositionStr = _currentPositionStr[0] + _hintTileIndexStr;
        Tile hintTile = board.GetTile(_newPositionStr);
        if (hintTile.isEmpty)
            hints.Add(hintTile);
    }
}