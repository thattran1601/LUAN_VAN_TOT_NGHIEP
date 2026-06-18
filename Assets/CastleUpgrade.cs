using TMPro;
using UnityEngine;

public class CastleUpgrade : MonoBehaviour
{
    public static CastleUpgrade Instance;
    public TextMeshProUGUI TextUpgrade;
    public GameObject PanelUpgrade;
    public CastleRuntimeData runtime;
    public CastleData castleDatas;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        PanelUpgrade.SetActive(false);
    }
    void Update()
    {
        
    }
    public void OpenPanel(CastleData data)
    {
        castleDatas = data;
        runtime = CastleShowUI.instance.GetRuntime(data.ID);
        PanelUpgrade.SetActive(true);
        TextUpgrade.text =
     "Lv " + (runtime.Level + 1) +
     "\nHP: " + CastleStatCalculator.GetHp(castleDatas, runtime.Level + 1);

    }   
    public void ClosePanel()
    {
        PanelUpgrade.SetActive(false);
    }    
    public void ClickUpgrade()
    {
     
        SaveGameManager.instance.SaveCastLevel(castleDatas.ID,runtime.Level);
        if(!CoinManger.Instance.HasCoin(castleDatas.coinUpgrade))
        {
            Debug.Log("Khong du vang de nang cap");
            return;
        }
        runtime.Level++;
        refect();
        CoinManger.Instance.RemoveCoin(castleDatas.coinUpgrade);

        CastleSelectUI.Instance.ShowCastle(castleDatas.ID);
    }    
    public void refect()
    {
        runtime = CastleShowUI.instance.GetRuntime(castleDatas.ID);
        TextUpgrade.text =
"Lv " + (runtime.Level+1) +
"\nHP: " + CastleStatCalculator.GetHp(castleDatas, runtime.Level+1);
    }    
}
