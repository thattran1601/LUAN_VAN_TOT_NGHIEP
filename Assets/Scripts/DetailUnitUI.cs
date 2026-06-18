using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DetailUnitUI : MonoBehaviour
{
    public static DetailUnitUI Intance;

    public GameObject PanelDetais;
    public Image icon;
    public Image IconPanelBaoVat;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textLV; 
    public TextMeshProUGUI textNamePanel;
    public TextMeshProUGUI textLVPanel;
    public TextMeshProUGUI textTruockhinang;
    public TextMeshProUGUI TextSaukhinang;
    [Header("Skill")]
    public GameObject PanelRelic;
    public Image IconSkill;
    public TextMeshProUGUI TextSkill;
    public Image PanelUpgrade;

    public Image[] MaterialIcons;
    public TextMeshProUGUI[] MaterialTexts;

    public UnitData Unitdata;
    public UnitRuntimeData RuntimeData;

    public TextMeshProUGUI unitText;

    [Header("Coin nâng cấp")]
    public TextMeshProUGUI TextCoin;
    public Button btnThao;

    public GameObject PanelLock;

    private void Awake()
    {
        Intance = this;
    }

    void Start()
    {
        PanelDetais.SetActive(false);
    }

    public void OpenPanel(UnitData data)
    {
        if (data == null) return;

        Unitdata = data;
        RuntimeData = UnitOwnedManager.Instance.GetRuntime(data.Id);

        if (RuntimeData == null) return;

        PanelDetais.SetActive(true);
        PanelRelic.SetActive(false);
        PanelUpgrade.gameObject.SetActive(true);
        if(RuntimeData.Level==data.LevelMax)
        {
            PanelLock.SetActive(false);
        }    
        else
        {
            PanelLock.SetActive(true);
        }    
        RefreshUI();
    }
    public void UnlockRelic(UnitData data)
    {
        RuntimeData=UnitOwnedManager.Instance.GetRuntime(data.Id);
        if (RuntimeData.Level == data.LevelMax)
        {
            PanelLock.SetActive(false);
        }
        else
        {
            PanelLock.SetActive(true);
        }
    }    
    public void RefreshUI()
    {
        if (Unitdata == null || RuntimeData == null) return;

        icon.sprite = Unitdata.icon;
        textName.text = Unitdata.Name;
        textLV.text = "LV: " + RuntimeData.Level;
        IconPanelBaoVat.sprite = Unitdata.icon;
        textLVPanel.text="LV: "+RuntimeData.Level;
        textNamePanel.text=Unitdata.Name;
        IconSkill.sprite = Unitdata.iconSkill;
        TextSkill.text = Unitdata.ThongTinSkill;
        int hpNow = UnitStatCalculator.getHp(Unitdata, RuntimeData.Level);
        int dameNow = UnitStatCalculator.getDame(Unitdata, RuntimeData.Level);
        int reduceNow = UnitStatCalculator.getdamageReduction(Unitdata, RuntimeData.Level);

        int nextLevel = Mathf.Min(RuntimeData.Level + 1, Unitdata.LevelMax);

        int hpNext = UnitStatCalculator.getHp(Unitdata, nextLevel);
        int dameNext = UnitStatCalculator.getDame(Unitdata, nextLevel);
        int reduceNext = UnitStatCalculator.getdamageReduction(Unitdata, nextLevel);

        textTruockhinang.text =
            hpNow + "\n" +
            dameNow + "\n" +
            reduceNow;

        TextSaukhinang.text =
            hpNext + "\n" +
            dameNext + "\n" +
            reduceNext;

        ShowUpgradeMaterials();
        UpdateCoinUI();
    }
    public void OpenlPanelUpgrade()
    {
        PanelRelic.SetActive(false);
        PanelUpgrade.gameObject.SetActive(true);
    }    
    public void OpenPanelRelic()
    {
        PanelRelic.SetActive(true);
        PanelUpgrade.gameObject.SetActive(false);
        TreasureManager.instance.selectUnit(RuntimeData,Unitdata);
        RuntimeData.EquippedTreasureId = SaveGameManager.instance.LoadRelic(Unitdata.Id);
        if(RuntimeData.EquippedTreasureId==-1)
        {
            btnThao.gameObject.SetActive(false);
        }    
        else
        {
            btnThao.gameObject.SetActive(true);
        }    
   
    }
       
    public void UpdateCoinUI()
    {
        if (TextCoin == null) return;
        if (Unitdata == null || RuntimeData == null) return;

        if (RuntimeData.Level >= Unitdata.LevelMax)
        {
            TextCoin.text = "MAX";
            TextCoin.color = Color.white;
            return;
        }

        int cost = Unitdata.Gold(RuntimeData.Level);

        TextCoin.text = cost.ToString();

        if (CoinManger.Instance != null)
        {
            TextCoin.color = CoinManger.Instance.HasCoin(cost) ? Color.white : Color.red;
        }
    }

    public void ShowUpgradeMaterials()
    {
        if (Unitdata == null || RuntimeData == null) return;

        foreach (Image img in MaterialIcons)
        {
            if (img != null)
                img.gameObject.SetActive(false);
        }

        foreach (TextMeshProUGUI txt in MaterialTexts)
        {
            if (txt != null)
                txt.gameObject.SetActive(false);
        }

        if (RuntimeData.Level >= Unitdata.LevelMax)
        {
            if (unitText != null)
                unitText.text = "MAX LEVEL\nAll skills unlocked";

            return;
        }

        if (unitText != null)
            unitText.text = "";

        MaterialCost[] materialCosts = Unitdata.GetMaterialsCost(RuntimeData.Level);

        if (materialCosts == null) return;

        for (int i = 0; i < materialCosts.Length && i < MaterialIcons.Length; i++)
        {
            if (materialCosts[i] == null || materialCosts[i].item == null)
                continue;

            MaterialIcons[i].gameObject.SetActive(true);
            MaterialIcons[i].sprite = materialCosts[i].item.Item;

            if (i < MaterialTexts.Length && MaterialTexts[i] != null)
            {
                MaterialTexts[i].gameObject.SetActive(true);
                MaterialTexts[i].text = materialCosts[i].amount.ToString();

                MaterialTexts[i].color =
                    InventoryManager.Instance.HasItem(materialCosts[i].item, materialCosts[i].amount)
                    ? Color.white
                    : Color.red;
            }
        }
    }

    public void close()
    {
        PanelDetais.SetActive(false);
        
    }
       
    public void OnClickUpgrade()
    {
        if (Unitdata == null || RuntimeData == null) return;

        bool success = UnitUpgradeManager.Instance.Upgrade(Unitdata, RuntimeData);

        if (success)
        {
            RuntimeData = UnitOwnedManager.Instance.GetRuntime(Unitdata.Id);

            RefreshUI();

            if (UnitListManager.Instance != null)
                UnitListManager.Instance.RefreshList();
        }
    }
}