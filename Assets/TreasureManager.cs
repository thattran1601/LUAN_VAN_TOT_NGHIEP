
using UnityEngine;
using UnityEngine.UI;

public class TreasureManager : MonoBehaviour
{
    public static TreasureManager instance;
    public GameObject PanelTreasure;
    public GameObject PrealafTreasure;
    public Transform content;
    public Image IconBaoVat;
    public UnitRuntimeData runtimeData;
    public UnitData unitData;
    public Sprite IconDauCong;
    public GameObject Panel;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PanelTreasure.SetActive(false);
        Panel.SetActive(false);


    }
    void Update()
    {
        
    }
    public void ShowTreasure()
    {
        PanelTreasure.SetActive(true);
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }    
        foreach(var Treasure in InventoryManager.Instance.items)
        {

            if (Treasure.Key.Used == false)
            {

                if (Treasure.Key.ItemType == ItemType.Treasure)
                {
                    GameObject ojb = Instantiate(PrealafTreasure, content);
                    ojb.GetComponent<TreasureUI>().setup(Treasure.Key);
                    Debug.Log("Bao vat co ten la" + Treasure.Key.Name);
                }
            }


        }    
    }  
    public void Close()
    {
        Panel.SetActive(false);
    }    
    public void selectUnit(UnitRuntimeData unit,UnitData data)
    {
        runtimeData=unit;
        unitData=data;
        RefreshUIPanelRelic();
    }    
    public void closePanel()
    {
        PanelTreasure.SetActive(false);
    }
    public void OnclickUseTreasure(ItemData Treasure)
    {
        
        if (Treasure.TreasureType == unitData.UnitId)
        {
            runtimeData.EquippedTreasureId = Treasure.Id;
            IconBaoVat.sprite = Treasure.Item;
            Treasure.Used = true;
            SaveGameManager.instance.SaveRelic(Treasure.Id, runtimeData.UnitId);
            DetailUnitUI.Intance.btnThao.gameObject.SetActive(true);
            Debug.Log(Treasure.Id);
        } 
        else
        {
            Debug.Log("Khong phải bao vat của tướng");
            Panel.SetActive(true);
        }    
            
      
    }
    public void RefreshUIPanelRelic()
    {
        runtimeData.EquippedTreasureId = SaveGameManager.instance.LoadRelic(runtimeData.UnitId);
        if (runtimeData.EquippedTreasureId == -1)
        {
            IconBaoVat.sprite = IconDauCong;
        }
        ItemData item = InventoryManager.Instance.GetByIdItem(runtimeData.EquippedTreasureId);
        if(item!=null)
        {
            IconBaoVat.sprite = item.Item;
        }    
    }
    public void ThaoTreasure()
    {
        ItemData item = InventoryManager.Instance.GetByIdItem(runtimeData.EquippedTreasureId);
        IconBaoVat.sprite = IconDauCong;
        item.Used = false;
        DetailUnitUI.Intance.btnThao.gameObject.SetActive(false);
        SaveGameManager.instance.SaveRelic(-1,runtimeData.UnitId);
        RefreshUIPanelRelic();
    

    }    
}
