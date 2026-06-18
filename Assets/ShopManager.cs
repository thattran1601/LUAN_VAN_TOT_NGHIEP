using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Image[] ImageShops;
    public TextMeshProUGUI[] TextName;
    public TextMeshProUGUI[] TextPrice;
    public TextMeshProUGUI TextRefreshTime;

    public ItemData[] ItemData;
    public ItemData[] Shopitem;

    public GameObject[] PanelSolds;
    public Button[] buttons;

    public int TimeRefresh = 3600;

    public GameObject PanelShop;
    public GameObject PanelThongBao;
    public Image ImageThongBao;
    public TextMeshProUGUI TextThongBao;

    public GameObject PanelTB;

    public GameObject PanelVatPham;
    public GameObject PanelReload;

    public GameObject PanelRuong;
    public GameObject PanelQuyTac;

    public int CurrentId;

    void Start()
    {
        Shopitem = new ItemData[ImageShops.Length];

        PanelShop.SetActive(false);
        PanelThongBao.SetActive(false);
        PanelTB.SetActive(false);
        PanelRuong.SetActive(false);
        PanelQuyTac.SetActive(false);
        CheckRefreshByRealTime();

        InvokeRepeating(nameof(UpdateRefreshTimeText), 0f, 1f);
    }

    void CheckRefreshByRealTime()
    {
        string lastRefreshString = SaveGameManager.instance.LoadShopRefreshTime();

        if (string.IsNullOrEmpty(lastRefreshString))
        {
            RefreshShop();
            SaveRefreshTime();
            return;
        }

        DateTime lastRefresh = DateTime.FromBinary(Convert.ToInt64(lastRefreshString));
        TimeSpan timePassed = DateTime.Now - lastRefresh;

        if (timePassed.TotalSeconds >= TimeRefresh)
        {
            RefreshShop();
            SaveRefreshTime();
        }
        else
        {
            LoadShopSave();
        }
    }

    public void RefreshShop()
    {
        List<ItemData> listitem = new List<ItemData>();

        for (int i = 0; i < ItemData.Length; i++)
        {
            if (ItemData[i] != null)
                listitem.Add(ItemData[i]);
        }

        for (int i = 0; i < Shopitem.Length; i++)
        {
            if (listitem.Count > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, listitem.Count);
                Shopitem[i] = listitem[randomIndex];

                SaveGameManager.instance.SaveShopItem(i, Shopitem[i].Id);
                SaveGameManager.instance.SaveShopSold(i, false);

                listitem.RemoveAt(randomIndex);
            }
            else
            {
                Shopitem[i] = null;
                SaveGameManager.instance.SaveShopItem(i, -1);
                SaveGameManager.instance.SaveShopSold(i, false);
            }
        }

        show();
    }

    public void LoadShopSave()
    {
        bool hasFullSave = true;

        for (int i = 0; i < Shopitem.Length; i++)
        {
            int itemId = SaveGameManager.instance.LoadShopItem(i);

            if (itemId == -1)
            {
                hasFullSave = false;
                break;
            }

            Shopitem[i] = FindItemById(itemId);

            if (Shopitem[i] == null)
            {
                hasFullSave = false;
                break;
            }
        }

        if (!hasFullSave)
        {
            RefreshShop();
            SaveRefreshTime();
            return;
        }

        show();
    }

    ItemData FindItemById(int itemId)
    {
        for (int i = 0; i < ItemData.Length; i++)
        {
            if (ItemData[i] != null && ItemData[i].Id == itemId)
                return ItemData[i];
        }

        return null;
    }

    public void show()
    {
        for (int i = 0; i < Shopitem.Length; i++)
        {
            int index = i;

            if (Shopitem[i] != null)
            {
                ImageShops[i].gameObject.SetActive(true);

                ImageShops[i].sprite = Shopitem[i].Item;
                TextName[i].text = Shopitem[i].Name;
                TextPrice[i].text = Shopitem[i].Price.ToString();

                bool isSold = SaveGameManager.instance.LoadShopSold(i);
                PanelSolds[i].SetActive(isSold);
                buttons[i].interactable = !isSold;

                buttons[i].onClick.RemoveAllListeners();
                buttons[i].onClick.AddListener(() => ClickBuy(index));
            }
            else
            {
                ImageShops[i].gameObject.SetActive(false);
                PanelSolds[i].SetActive(false);
                buttons[i].interactable = false;
            }
        }
    }

    public void ManualRefreshShop()
    {
        if (!CoinManger.Instance.HasCoin(500))
        {
            PanelTB.SetActive(true);
            return;

        }
        CoinManger.Instance.RemoveCoin(500);
        RefreshShop();
        SaveRefreshTime();
    }
    public void ClosePanelTB()
    {
        PanelTB.SetActive(false );
    }    

    public void SaveRefreshTime()
    {
        SaveGameManager.instance.SaveShopRefreshTime(DateTime.Now.ToBinary().ToString());
    }

    void UpdateRefreshTimeText()
    {
        string lastRefreshString = SaveGameManager.instance.LoadShopRefreshTime();

        if (string.IsNullOrEmpty(lastRefreshString))
            return;

        DateTime lastRefresh = DateTime.FromBinary(Convert.ToInt64(lastRefreshString));
        TimeSpan passed = DateTime.Now - lastRefresh;
        double remaining = TimeRefresh - passed.TotalSeconds;

        if (remaining <= 0)
        {
            RefreshShop();
            SaveRefreshTime();
            remaining = TimeRefresh;
        }

        int hour = Mathf.FloorToInt((float)remaining / 3600);
        int minute = Mathf.FloorToInt(((float)remaining % 3600) / 60);
        int second = Mathf.FloorToInt((float)remaining % 60);

        TextRefreshTime.text =
            hour.ToString("00") + ":" +
            minute.ToString("00") + ":" +
            second.ToString("00");
    }

    public void ClickBuy(int index)
    {
        CurrentId = index;

        ItemData item = Shopitem[index];

        if (item == null)
            return;

        ImageThongBao.sprite = item.Item;
        TextThongBao.text = "Bạn có chắc mua " + item.Name + " không?";
        PanelThongBao.SetActive(true);
    }

    public void BuyItem()
    {
        ItemData item = Shopitem[CurrentId];

        if (item == null)
            return;

        if (SaveGameManager.instance.LoadShopSold(CurrentId))
        {
            Debug.Log("Món này đã bán rồi");
            return;
        }

        bool enoughCoin = CoinManger.Instance.RemoveCoin(item.Price);

        if (!enoughCoin)
        {
            Debug.Log("Không đủ coin");
            return;
        }

        InventoryManager.Instance.AddItem(item, 1);
        SaveGameManager.instance.SaveShopSold(CurrentId, true);

        PanelThongBao.SetActive(false);
        PanelSolds[CurrentId].SetActive(true);
        buttons[CurrentId].interactable = false;
    }

    public void CLoseShop()
    {
        PanelShop.SetActive(false);
    }

    public void CLosePanelThongBao()
    {
        PanelThongBao.SetActive(false);
    }

    public void OpenShop()
    {
        PanelShop.SetActive(true);
    }
    public void OpenPanelRuong()
    {
        PanelRuong.SetActive(true);
        PanelQuyTac.SetActive(true);
        PanelReload.SetActive(false);
        PanelVatPham.SetActive(false);
    } 
    public void OpenPanelVatPham()
    {
        PanelRuong.SetActive(false);
        PanelQuyTac.SetActive(false);
        PanelReload.SetActive(true);
        PanelVatPham.SetActive(true);
    }
}