using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Dictionary<ItemData,int> items = new Dictionary<ItemData,int>();
    public ItemData[] Items;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
          
        }    
        else
        {
            Destroy(gameObject);
        }    
    }
    void Start()
    {
        LoadInventory();
        //AddItem(Items[0],999999);
        //AddItem(Items[1],999999);
        //AddItem(Items[2],999999);
        //AddItem(Items[3],999999);
        //AddItem(Items[4],999999);
        //AddItem(Items[5],999999);
        //AddItem(Items[6],999999);
        //AddItem(Items[7],999999);
        //AddItem(Items[8],999999);
        //AddItem(Items[9],999999);
      
    }
    private void Update()
    {
    }
    public void LoadInventory()
    {
        items.Clear();
        foreach(ItemData item in Items)
        {
            if (item == null)
                continue;
               int amount = SaveGameManager.instance.GetItemAmount(item.Id);
            if(amount>0)
                items.Add(item, amount);    
            
        }    
    }    
    public int GetAmount(ItemData item)
    {
        if (items.ContainsKey(item))
            return items[item];
        return 0;
    }
    public void AddItem(ItemData item, int amount)
    {
        if (!items.ContainsKey(item))
            items[item] = 0;
        items[item] += amount;
        SaveGameManager.instance.AddItem(item.Id,amount);
        LoadInventory();

        Debug.Log("Đã thêm " + item.Name + " x" + amount);

    }
    public bool HasItem(ItemData item, int amount)
    {
        return GetAmount(item) >= amount;

    }
    public void RemoveItem(ItemData item, int amount)
    {
        if (!HasItem(item, amount))
            return;
        items[item] -= amount;
        SaveGameManager.instance.RemoveItem(item.Id, amount);
        if(items[item]<=0)
        {
            items.Remove(item);
        }    
            


    }
    public ItemData GetByIdItem(int id)
    {
        foreach (var pair in items)
        {
            ItemData item = pair.Key;

            if (item != null && item.Id == id && pair.Value > 0)
                return item;
        }

        return null;
    }

}
