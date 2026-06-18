using System.Collections.Generic;
using UnityEngine;

public class CastleManager : MonoBehaviour
{
    public static CastleManager Instance;
    public CastleData[] castleData;
    public List<CastleRuntimeData> castleRuntimes=new();
    public CastleType CastleTypeCurrent = CastleType.Physical;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadCastle();
           LoadLevelCastle();
            DontDestroyOnLoad(gameObject);
            Debug.Log("CastleManager được giữ lại");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectPhysical()
    {
        CastleTypeCurrent = CastleType.Physical;
        Debug.Log("Đã chọn thành: " + CastleTypeCurrent);
        SaveGameManager.instance.SaveCastleSelected(0);
    }
    
    public void SelectMagic()
    {
        CastleTypeCurrent = CastleType.Magic;
        Debug.Log("Đã chọn thành: " + CastleTypeCurrent);
        SaveGameManager.instance.SaveCastleSelected(1);
    }
    public void LoadLevelCastle()
    {
        castleRuntimes.Clear();
        foreach(CastleData castle in castleData)
        {
            if (castle == null)
                continue;
            CastleRuntimeData Level = new CastleRuntimeData(castle.ID);
            Level.Level=SaveGameManager.instance.LoadCastleLevel(castle.ID);
            castleRuntimes.Add(Level);
        }    
    }    
    public void DeleteSelectPhysical()
    {
        CastleTypeCurrent= CastleType.None;
        
    }   
    public void DeleteSelectMagic()
    {
        CastleTypeCurrent= CastleType.None;
    }    
    public void LoadCastle()
    {
        int id = SaveGameManager.instance.LoadCastleSelected();
        if (id == 0)
            CastleTypeCurrent = CastleType.Physical;
        else
            CastleTypeCurrent=CastleType.Magic;
    }    
}