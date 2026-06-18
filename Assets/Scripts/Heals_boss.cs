using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Heals_boss : MonoBehaviour
{
    public static Heals_boss instance;
    public float hphientai;
    public int maxhp;
    public int dame;
    Animator animator;
    public bool Isdieboss=false;
    private SpriteRenderer sr;
    int count = 0;
    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        hphientai = maxhp;
        BossUI.Instance.setHpboss(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            takedame(100);
        }
        if (hphientai <= 0&&count==0)
        {
            count = 1;
            die();

        }

    }
       
    public void takedame(float amount)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.Hit);

        hphientai -= amount;
        StartCoroutine(hit());
        BossUI.Instance.upHP();
    }    
    public void die()
    {
        Isdieboss = true;
        BossManger.instance.BossDie();
        GameManager.instance.victory();
        animator.SetBool("die", true);
        BossUI.Instance.HpBar.SetActive(false);
        
        
    }
    IEnumerator hit()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }
    public void DeleteBoss()
    {
        Destroy(gameObject);
        WaveManager.instance.EnemyKilled();
    }    
}
