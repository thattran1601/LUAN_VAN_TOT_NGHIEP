using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CastleSelectUI : MonoBehaviour
{
    public static CastleSelectUI Instance;
    public TextMeshProUGUI TextName;
    public TextMeshProUGUI TextLevel;
    public TextMeshProUGUI TextHp;
    public TextMeshProUGUI MoTaSkill;
    public Image[] ImageSkill;
    public Image IconCastle;
    public int CastleID;
    public CastleData CurrentCastle;
    public CastleRuntimeData castleRuntime;
    public TextMeshProUGUI ButtonText1;
    public Button selecButton;
    public CastleUpgrade castleUpgrade;
    public CastleShowUI castleShowUI;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

        ShowCastle(CastleID);
        selecButton.onClick.RemoveAllListeners();
        selecButton.onClick.AddListener(SelectCastle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowCastle(int id)
    {
        CastleID = id;
        CurrentCastle = castleShowUI.GetCastle(id);
        castleRuntime = castleShowUI.GetRuntime(id);
        TextName.text = CurrentCastle.CastleName;
        IconCastle.sprite = CurrentCastle.icon;
        TextLevel.text = castleRuntime.Level.ToString();
        TextHp.text = CastleStatCalculator.GetHp(CurrentCastle, castleRuntime.Level).ToString();
        //TextHp.text = CurrentCastle.hp.ToString();
        for(int i=0;i<ImageSkill.Length;i++)
        {
            ImageSkill[i].sprite = CurrentCastle.iconSkill[i];
            if(CurrentCastle.MoTaskill.Length>0)
            {
                MoTaSkill.text = CurrentCastle.MoTaskill[0];
            }    
        }

        UpdateUI();
    }    
    public void UpdateUI()
    {
        
    }   
    public void SelectCastle()
    {
        CastleShowUI.instance.SelectCasle(CastleID);
        UpdateUI();   
    }  
    public void showMotoSkill(int index)
    {
        if (CurrentCastle == null)
            return;
        if (index < CurrentCastle.MoTaskill.Length)
            MoTaSkill.text = CurrentCastle.MoTaskill[index];
    }    
    public void UpgradeCastle()
    {
        castleUpgrade.OpenPanel(CurrentCastle);
    }    
    
}
