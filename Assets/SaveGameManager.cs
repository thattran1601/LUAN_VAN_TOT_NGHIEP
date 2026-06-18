using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
    public static SaveGameManager instance;
    public string Coinkey = "COIN";
    public string MapUnlockKey = "MAP_UNLOCK";
    public string ShopRefreshKey = "SHOP_REFRESH";
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
     
    }
    //Coin

    public int GetCoin()
    {
        return PlayerPrefs.GetInt(Coinkey,5000);
    }    
    public void SetCoin(int amount)
    {
       PlayerPrefs.SetInt(Coinkey, amount);
       PlayerPrefs.Save();
    }  
    public void AddCoin(int amount)
    {
        SetCoin(GetCoin()+amount);
    }  
    public bool SpendCoin(int amount)
    {
        if(GetCoin()<amount)
            return false;
        SetCoin(GetCoin()-amount);
        return true;
    }    
    //Map
    public int GetUnlockMap()
    {
        return PlayerPrefs.GetInt(MapUnlockKey,1);
    }  
    public void LoadMap(int mapID)
    {
        if(mapID>GetUnlockMap())
        {
            PlayerPrefs.SetInt (MapUnlockKey, mapID);
            PlayerPrefs.Save();
        }    
    }    
    //Unit
    public void SaveUnit(int unitId, bool unlock)
    {
        PlayerPrefs.SetInt($"UNIT_UNLOCK_{unitId}",unlock?1:0);
        PlayerPrefs.Save();
    }    
    public bool LoadUnit(int unitId)
    {
        return PlayerPrefs.GetInt($"UNIT_UNLOCK_{unitId}", (unitId==0||unitId==1) ? 1 : 0)==1;
    }    
    public void SaveUnitLevel(int unitId,int level )
    {
        PlayerPrefs.SetInt($"UNIT_LEVEL_{unitId}",level);
        PlayerPrefs.Save();
    }   
    public int LoadLevel(int UnitId)
    {
        return PlayerPrefs.GetInt($"UNIT_LEVEL_{UnitId}",1);
    }
    public void SaveTeamSlot(int slotIndex, int unitId)
    {
        PlayerPrefs.SetInt($"TEAM_SLOT_{slotIndex}", unitId);
        PlayerPrefs.Save();
    }

    public int LoadTeamSlot(int slotIndex)
    {
        return PlayerPrefs.GetInt($"TEAM_SLOT_{slotIndex}", -1);
    }
    public void SaveCastLevel(int CastleId, int level)
    {
        PlayerPrefs.SetInt($"CASTLE_LEVEL_{CastleId}",level);
        PlayerPrefs.Save();
    }    
    public int LoadCastleLevel(int CastleId)
    {
        return PlayerPrefs.GetInt($"CASTLE_LEVEL_{CastleId}",1);
    }
    public void SaveCastleSelected(int castleId)
    {
        PlayerPrefs.SetInt("CASTLE_SELECTED", castleId);
        PlayerPrefs.Save();
    }

    public int LoadCastleSelected()
    {
        return PlayerPrefs.GetInt("CASTLE_SELECTED", 0);
    }

    public void SaveRelic(int idRelic,int IdUnit)
    {
        PlayerPrefs.SetInt("RELIC_"+IdUnit, idRelic);
        PlayerPrefs.Save();
        Debug.Log("RELIC_" + idRelic + " UNIT"+ IdUnit);
    }   
    public int LoadRelic(int IdUnit)
    {
        int IdRelic= PlayerPrefs.GetInt("RELIC_" + IdUnit, -1);
        Debug.Log("RELIC" + IdRelic);
        return IdRelic;

    }    
    //Inventory
    public void AddItem(int ItemID, int amount)
    {
        int current = GetItemAmount(ItemID);
        PlayerPrefs.SetInt($"ITEM_{ItemID}", current + amount);
        PlayerPrefs.Save();
    }    
    public bool RemoveItem(int ItemID,int amount) 
    {
        int current=GetItemAmount(ItemID);
        if(current<amount)
            return false;
        PlayerPrefs.SetInt($"ITEM_{ItemID}",current-amount);
        PlayerPrefs.Save();
        return true;
    }
    public int  GetItemAmount(int itemID)
    {
        return PlayerPrefs.GetInt($"ITEM_{itemID}", 0);
    }
    //Shop
    public void SaveShopItem(int slotIndex, int itemId)
    {
        PlayerPrefs.SetInt("SHOP_ITEM_" + slotIndex, itemId);
        PlayerPrefs.Save();
    }

    public int LoadShopItem(int slotIndex)
    {
        return PlayerPrefs.GetInt("SHOP_ITEM_" + slotIndex, -1);
    }

    public void SaveShopSold(int slotIndex, bool isSold)
    {
        PlayerPrefs.SetInt("SHOP_SOLD_" + slotIndex, isSold ? 1 : 0);
        PlayerPrefs.Save();
    }

    public bool LoadShopSold(int slotIndex)
    {
        return PlayerPrefs.GetInt("SHOP_SOLD_" + slotIndex, 0) == 1;
    }

    public void ClearShopSave(int slotCount)
    {
        for (int i = 0; i < slotCount; i++)
        {
            PlayerPrefs.DeleteKey("SHOP_ITEM_" + i);
            PlayerPrefs.DeleteKey("SHOP_SOLD_" + i);
        }

        PlayerPrefs.Save();
    }
    public void SaveShopRefreshTime(string time)
    {
        PlayerPrefs.SetString(ShopRefreshKey, time);
        PlayerPrefs.Save();
    }

    public string LoadShopRefreshTime()
    {
        return PlayerPrefs.GetString(ShopRefreshKey, "");
    }
    public void DeleteAllSave()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
   
    }
}
