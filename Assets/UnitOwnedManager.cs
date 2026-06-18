using System.Collections.Generic;
using UnityEngine;

public class UnitOwnedManager : MonoBehaviour
{
    public static UnitOwnedManager Instance;

    public UnitData[] allunit;
    public List<UnitRuntimeData> ownedUnits = new List<UnitRuntimeData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitUnit();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitUnit()
    {
        ownedUnits.Clear();

        foreach (UnitData unit in allunit)
        {
            bool unlocked = SaveGameManager.instance.LoadUnit(unit.Id);
            int level = SaveGameManager.instance.LoadLevel(unit.Id);
            Debug.Log("Unit ID = " + unit.Id + " | Unlock = " + unlocked);
            UnitRuntimeData runtime = new UnitRuntimeData(unit.Id, unlocked);
            runtime.Level = level;
            runtime.EquippedTreasureId=SaveGameManager.instance.LoadRelic(unit.Id);
            Debug.Log(runtime.EquippedTreasureId);
            ownedUnits.Add(runtime);
        }

        // mở sẵn 2 lính đầu game
        //UnlockUnit(0);
        //UnlockUnit(1);
    }

    public void UnlockUnit(int unitId)
    {
        UnitRuntimeData runtime = GetRuntime(unitId);

        if (runtime != null)
        {
            runtime.iSlock = true;
            SaveGameManager.instance.SaveUnit(unitId, true);
        }
    }

    public bool IsUnlocked(int unitId)
    {
        UnitRuntimeData runtime = GetRuntime(unitId);
        return runtime != null && runtime.iSlock;
    }

    public UnitRuntimeData GetRuntime(int unitId)
    {
        foreach (UnitRuntimeData runtime in ownedUnits)
        {
            if (runtime.UnitId == unitId)
                return runtime;
        }

        return null;
    }

    public void SaveUnitLevel(int unitId, int level)
    {
        UnitRuntimeData runtime = GetRuntime(unitId);

        if (runtime != null)
        {
            runtime.Level = level;
            SaveGameManager.instance.SaveUnitLevel(unitId, level);
        }
    }
}