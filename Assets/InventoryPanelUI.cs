using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryPanelUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject inventoryPrelaf;
    public int Soluongtuido;
    public Transform content;
    public List<InventoryItemUI> slots= new List<InventoryItemUI>();

    void Start()
    {
        //inventoryPanel.SetActive(false);
        CreateInventory();
        refectInventory();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openPanel()
    {
        inventoryPanel.SetActive(true);
        refectInventory();
    }   
    public void closePanel()
    {
        inventoryPanel.SetActive(false);
    }    
    public void CreateInventory()
    {
        for(int i=0;i<Soluongtuido;i++)
        {
            GameObject ojb= Instantiate(inventoryPrelaf,content);
            InventoryItemUI slot=ojb.GetComponent<InventoryItemUI>();
            slot.setEmpty();
            slots.Add(slot);
        }
       
    }
    public void refectInventory()
    {
        if (InventoryManager.Instance == null)
        {
            Debug.LogError("InventoryManager.Instance đang null - scene này chưa có InventoryManager");
            return;
        }

        if (InventoryManager.Instance.items == null)
        {
            Debug.LogError("InventoryManager.items đang null");
            return;
        }

        int index = 0;

        foreach (var item in InventoryManager.Instance.items)
        {
            if (index >= slots.Count)
                break;

            if (item.Key == null)
                continue;

            slots[index].Setup(item.Key, item.Value);
            index++;
        }

        for (int i = index; i < slots.Count; i++)
        {
            slots[i].setEmpty();
        }
    }
}
