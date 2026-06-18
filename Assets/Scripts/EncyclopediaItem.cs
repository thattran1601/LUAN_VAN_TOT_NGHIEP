using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaItem : MonoBehaviour
{
    public static EncyclopediaItem Instance;
    public EnemyData EnemyDatas;
    public Image Icon;
    public TextMeshProUGUI textName;
    public Button Buttons;
    public Image Chon;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setup(EnemyData EnemyData)
    {
        EnemyDatas = EnemyData;
        Icon.sprite = EnemyData.icon;
        textName.text = EnemyData.name;
        Buttons.onClick.RemoveAllListeners();
        Buttons.onClick.AddListener(()=>OnClick(EnemyData));
        Chon.gameObject.SetActive(false);


    }
    public void setupboss(BossData boss)
    {
        Icon.sprite = boss.icon;
        textName.text=boss.name;
        Buttons.onClick.RemoveAllListeners();
        Buttons.onClick.AddListener(() => OnClickBoss(boss));
        
    }    
    public void OnClick(EnemyData EnemyData)
    {
        EncyclopediaManager.Instance.SelectItem(this);
        EncyclopediaManager.Instance.show(EnemyData);
        
    }    
    public void OnClickBoss(BossData EnemyData)
    {
        EncyclopediaManager.Instance.SelectItem(this);
        EncyclopediaManager.Instance.showBoss(EnemyData);
        
    }  
    public void setupAll(EnemyData EnemyData)
    {
        EnemyDatas = EnemyData;
        Icon.sprite = EnemyData.icon;
        textName.text = EnemyData.name;
        Buttons.onClick.RemoveAllListeners();
        Buttons.onClick.AddListener(()=>OnClickAll(EnemyData));
        Chon.gameObject.SetActive(false);


    }
    public void setupbossAll(BossData boss)
    {
        Icon.sprite = boss.icon;
        textName.text=boss.name;
        Buttons.onClick.RemoveAllListeners();
        Buttons.onClick.AddListener(() => OnClickBossAll(boss));
        
    }    
    public void OnClickAll(EnemyData EnemyData)
    {
        EncyclopediaManager.Instance.SelectItem(this);
        EncyclopediaManager.Instance.showEnemyAll(EnemyData);
        
    }    
    public void OnClickBossAll(BossData EnemyData)
    {
        EncyclopediaManager.Instance.SelectItem(this);
        EncyclopediaManager.Instance.showBossAll(EnemyData);
        
    }    
}
