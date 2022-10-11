class OccupiedByAllyException : Exception
{
    public OccupiedByAllyException() : 
        base("Target tile is occupied by ally") { }
}