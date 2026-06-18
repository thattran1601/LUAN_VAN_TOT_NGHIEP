using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaManager : MonoBehaviour
{
    public static EncyclopediaManager Instance;
 
    public GameObject buttonAll;
    public GameObject buttonEnemy;
    public GameObject buttonBoss;

    public Image icon;
    public Image iconBoss;
    public Image iconAll;
    public Image IconSKill;
    [Header("Thông tin ")]
    public TextMeshProUGUI TextName;
    public TextMeshProUGUI TextHp;
    public TextMeshProUGUI Textdame;
    public TextMeshProUGUI TextSpeed;
    public TextMeshProUGUI TextGiamthuong;
    public TextMeshProUGUI TextSkill;
    public TextMeshProUGUI TextKhacChe; 
    [Header("Thông tin Boss")] 
    
    public TextMeshProUGUI TextNameBoss;
    public TextMeshProUGUI TextHpBoss;
    public TextMeshProUGUI TextdameBoss;
    public TextMeshProUGUI TextSpeedBoss;
    public TextMeshProUGUI TextGiamthuongBoss;
    public TextMeshProUGUI TextSkillBoss;
    public TextMeshProUGUI TextKhacCheBoss;
    private EncyclopediaItem EncyclopediaItem; 
    [Header("Thông tin All")] 
  
    public TextMeshProUGUI TextNameAll;
    public TextMeshProUGUI TextHpAll;
    public TextMeshProUGUI TextdameAll;
    public TextMeshProUGUI TextSpeedAll;
    public TextMeshProUGUI TextGiamthuongAll;
    public TextMeshProUGUI TextSkillAll;
    public TextMeshProUGUI TextKhacCheAll;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        buttonBoss.SetActive(false);
        buttonEnemy.SetActive(false);
    }

    void Update()
    {
        
    }
    
    public void ButtonEnemy()
    {
        buttonEnemy.SetActive(true);
        buttonAll.SetActive(false);
        buttonBoss.SetActive(false);
    }    
    public void ButtonAll()
    {
        buttonAll.SetActive(true);
        buttonEnemy.SetActive(false);
        buttonBoss.SetActive(false);
    }    
    public void ButtonBoss()
    {
        buttonBoss.SetActive(true);
        buttonEnemy.SetActive(false);
        buttonAll.SetActive(false);
    }    
    public void SelectItem(EncyclopediaItem item)
    {
        if(EncyclopediaItem!=null)
            EncyclopediaItem.Chon.gameObject.SetActive(false);
        EncyclopediaItem= item;
        EncyclopediaItem.Chon.gameObject.SetActive(true);

    }
    public void show(EnemyData enemyData)
    {
       
        icon.sprite= enemyData.icon;
        TextHp.text = enemyData.hp.ToString();
        TextSpeed.text=enemyData.speed.ToString();
        Textdame.text=enemyData.damage.ToString();
        TextGiamthuong.text=enemyData.GiamThuong.ToString();
        TextSkill.text=enemyData.skill.ToString();
        TextKhacChe.text=enemyData.Counter.ToString();



    }  
    public void showEnemyAll(EnemyData enemyData)
    {

        iconAll.sprite= enemyData.icon;
        TextHpAll.text = enemyData.hp.ToString();
        TextSpeedAll.text=enemyData.speed.ToString();
        TextdameAll.text=enemyData.damage.ToString();
        TextGiamthuongAll.text=enemyData.GiamThuong.ToString();
        TextSkillAll.text=enemyData.skill.ToString();
        TextKhacCheAll.text=enemyData.Counter.ToString();



    }      
    public void showBoss(BossData enemyData)
    {
       
        iconBoss.sprite= enemyData.icon;
        TextHpBoss.text = enemyData.hp.ToString();
        TextSpeedBoss.text=enemyData.speed.ToString();
        TextdameBoss.text=enemyData.damage.ToString();
        TextSkillBoss.text=enemyData.skill.ToString();
        TextGiamthuongBoss.text = enemyData.Giamthuong.ToString();
        TextKhacCheBoss.text=enemyData.Counter.ToString();

    }     
    public void showBossAll(BossData enemyData)
    {

        iconAll.sprite= enemyData.icon;
        TextHpAll.text = enemyData.hp.ToString();
        TextSpeedAll.text=enemyData.speed.ToString();
        TextdameAll.text=enemyData.damage.ToString();
        TextSkillAll.text=enemyData.skill.ToString();
        TextGiamthuongAll.text = enemyData.Giamthuong.ToString();
        TextKhacCheAll.text=enemyData.Counter.ToString();

    }    

}
