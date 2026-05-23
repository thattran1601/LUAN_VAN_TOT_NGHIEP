using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public static BossUI Instance;
    public Heals_boss bosscurrent;
    public Image UI_Imgae;
    public GameObject HpBar;
    private void Awake()
    { 
        Instance = this;
    }
    void Start()
    {
        
    }
    public void setHpboss(Heals_boss boss)
    {
        bosscurrent = boss;
        HpBar.SetActive(true);


        upHP();
    }    
    public void upHP()
    {
        if (bosscurrent == null)
            return;
        UI_Imgae.fillAmount = (float)bosscurrent.hphientai / bosscurrent.maxhp;
    }    
    // Update is called once per frame
    void Update()
    {
        
    }
}
