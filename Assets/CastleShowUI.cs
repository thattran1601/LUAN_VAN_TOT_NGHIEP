using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CastleShowUI : MonoBehaviour
{
    public static CastleShowUI instance;
    public CastleData[] castle;
    public TextMeshProUGUI TextCoin;
    public List<CastleRuntimeData> listCastle=new List<CastleRuntimeData>();
    private void Awake()
    {
      
            instance = this;
   
            InitCastle();
     
    }
    void Start()
    {
        UpdateCostUI();
    }
    void Update()
    {
        
    }
    public void UpdateCostUI()
    {
        CastleRuntimeData runtime = GetSelectCastle();

        if (runtime == null) return;

        CastleData data = GetCastle(runtime.CastleID);

        if (data == null) return;

        int cost = data.Gold(runtime.Level);

        TextCoin.text = cost.ToString();

        TextCoin.color =
            CoinManger.Instance.HasCoin(cost)
            ? Color.white
            : Color.red;
    }
    public void InitCastle()
    {
        listCastle.Clear();
        foreach(CastleData cast in castle)
        {
            if (cast == null)
                continue;
            CastleRuntimeData runtime = new CastleRuntimeData(cast.ID);
            runtime.Level = SaveGameManager.instance.LoadCastleLevel(cast.ID);
            int Isselected = SaveGameManager.instance.LoadCastleSelected();
            runtime.IsSelect = cast.ID==Isselected;
            listCastle.Add(runtime);

                
        }
        if(GetSelectCastle()==null && listCastle.Count>0)
        {
            listCastle[0].IsSelect = true;
        }    
    }   
    public CastleData GetCastle(int ID)
    {
        foreach(CastleData data in castle)
        {
            if(data.ID==ID)
                return data;    
        }
        return null;
    }    
    public void SelectCasle(int ID)
    {
        foreach(CastleRuntimeData data in listCastle)
        {
            data.IsSelect=data.CastleID==ID;
        }    
    }    
    public CastleRuntimeData GetSelectCastle()
    {
        foreach(CastleRuntimeData data in listCastle)
        {
            if(data.IsSelect)
                return data;    

        }   
        return null;
    }    
  
    public CastleRuntimeData GetRuntime(int castleID)
    {
        foreach(CastleRuntimeData castles in listCastle)
        {
            if(castles.CastleID==castleID)
                return castles;
        }    
        return null;
    }    
}
