using System.Collections;
using TMPro;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

public class Heals_Thanh : MonoBehaviour
{
    public static Heals_Thanh instance;
    public float heal;
    public float maxheal;
    public Image IconHP;
    public SpriteRenderer SpriteRenderer;
    public float time;
    public Image redImage;
    public GameObject TestLoss;
    public TextMeshProUGUI textHeath;
    public Image HpPanel;
    public TextMeshProUGUI TextHpPanel;
    public float DurigdamageReduction = 1f;
    private void Awake()
    {
        instance = this;
       
    }
    void Start()
    {
        LoadCastle();
        heal = maxheal;
        ShowHp();

    }
    public IEnumerator Giamdame()
    {
        DurigdamageReduction = 0.5f;
        yield return new WaitForSeconds(AutoDetroy.instance.time);
        DurigdamageReduction = 1f;

    }    
    void Update()
    {
        Redimage();
        show();
        }
    public void LoadCastle()
    {
        CastleRuntimeData runtime = CastleShowUI.instance.GetSelectCastle();
        CastleData data = CastleShowUI.instance.GetCastle(runtime.CastleID);
        maxheal = CastleStatCalculator.GetHp(data, runtime.Level);
    }    
    public void Redimage()
    {

        float HealPhantram = maxheal/3;
     
        if (heal<HealPhantram)
        {
            redImage.color = new Color(1, 0, 0, 0.15f);
        }
    }
    public void takedame(float amount)
    {
        heal -= amount;
        ShowHp();
        StartCoroutine(Hit());
    }    
    public IEnumerator Hit()
    {
        SpriteRenderer.color = Color.red;
       StartCoroutine( CameraShake.instance.camerashake(0.5f, 0.15f));
        yield return new WaitForSeconds(time);
        SpriteRenderer.color = Color.white;

    }    
    public void ShowHp()
    {
        IconHP.fillAmount = (float)heal / maxheal;
        HpPanel.fillAmount=(float)heal/maxheal;
        textHeath.text=heal.ToString() + "/"+maxheal.ToString();
        TextHpPanel.text = heal.ToString()+"/"+maxheal.ToString();
    }    
    public void show()
    {
        if(heal<=0)
        {
            GameManager.instance.GameOver();
      
        }    
    }
  
}
