using System.Collections;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Heals_Thanh : MonoBehaviour
{
    public static Heals_Thanh instance;
    public int heal;
    public int maxheal;
    public Image IconHP;
    public SpriteRenderer SpriteRenderer;
    public float time;
    public Image redImage;
    public GameObject TestLoss;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       
        heal = maxheal;
    }

    void Update()
    {
        Redimage();
        show();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==LayerMask.NameToLayer("Enemy_Body"))
        {
            StartCoroutine(Hit());  
            heal -= 20;
            ShowHp();
          
        }
    }
    public void Redimage()
    {

        float HealPhantram = maxheal/3;
     
        if (heal<HealPhantram)
        {
            redImage.color = new Color(1, 0, 0, 0.15f);
        }
    }
    public void takedame(int amount)
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
    }    
    public void show()
    {
        if(heal<=0)
        {
            GameManager.instance.GameOver();
      
        }    
    }
  
}
