[System.Serializable]
public class CastleRuntimeData
{
    public CastleData castle;
    public int CastleID;
    public int Level;
    public bool IsSelect;

    public CastleRuntimeData(int castle)
    {
        CastleID = castle;
        Level = 1;
        IsSelect = true;

    }
}