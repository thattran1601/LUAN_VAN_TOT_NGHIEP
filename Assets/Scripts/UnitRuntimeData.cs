[System.Serializable]
public class UnitRuntimeData
{
    public int UnitId;
    public int Level = 1;
    public bool iSlock;
    public int EquippedTreasureId = -1;
    public UnitRuntimeData(int unitId,bool UnLock)
    {
        UnitId = unitId;
        Level = 1;
        iSlock = UnLock;
    }
}