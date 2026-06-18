using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Heals : MonoBehaviour
{
    public static Heals instance;
    [Header("HP")]
    public int maxHp = 100;
    public float currentHp;

    [Header("HP BAR")]
    public GameObject hpCanvas;
    public Image hpFill;

    private Animator animator;
    private Coroutine hideCoroutine;
    public GameObject coinPrefab;
    private bool isDead = false;
    public int Gold;
    private SpriteRenderer sr;
    public float damageReduction = 0f;
    public bool isKnock;
    public bool isHit;
    public bool hasShield;
    public bool IsnotKnock;
    public GameObject ngonlua;
    private Coroutine hideCoroutine1;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sr= GetComponent<SpriteRenderer>();
        instance = this;
    }

    private void Start()
    {
        currentHp = maxHp;

        hpCanvas.SetActive(false);
        ngonlua.SetActive(false);

        UpdateBar();
    }

    public void TakeDamage(float damage)
    {
        float dame = damage * damageReduction;
        AudioManager.instance.PlaySFX(AudioManager.instance.Hit);

        currentHp -= dame;

            currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        
        UpdateBar();
        StartCoroutine(hit());
        ShowHp();
     
        if (currentHp <= 0)
        {
            Die();
        
           
        }
    }
    public IEnumerator KnockBack(float KnockBack=1f)
    {
        if (IsnotKnock == true)
            yield break;
        isKnock = true;   
        Vector3 start = transform.position;
        Vector3 end=start+Vector3.right*KnockBack;
        float t = 0;
        while(t<1)
        {
            t += Time.deltaTime / 0.08f;
            transform.position=Vector3.Lerp(start, end, t);
            yield return null;
        }
        isKnock = false;
    }    
    void Die()
    {
        if (isDead) return;

        isDead = true;


        animator.SetBool("die", true);

        // tắt collider
        Collider2D[] cols = GetComponents<Collider2D>();
        WaveManager.instance.EnemyKilled();
        spawnCoin();

        foreach (Collider2D col in cols)
        {
            col.enabled = false;
        }
        UnShowHp();
        // dừng coroutine
        StopAllCoroutines();
        sr.color = Color.white;
        Destroy(gameObject, 1f);
    }

    void UpdateBar()
    {
        hpFill.fillAmount = (float)currentHp / maxHp;
    }
    IEnumerator hit()
    {
        isHit = true;
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
        isHit=false;
    }    
    void ShowHp()
    {
        hpCanvas.SetActive(true);

        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        hideCoroutine = StartCoroutine(HideHpBar());
    }
   
    public void NgonLuaSkill(int dame)
    {
        ngonlua.SetActive(true);
        if (hideCoroutine1!=null)
        {
            StopCoroutine(hideCoroutine1);
        }
        hideCoroutine1 = StartCoroutine(showNgonluaSkill(dame));
    }
  
    public IEnumerator showNgonluaSkill(int dame)
    {
       
        float time = 5f;
        while(time>0)
        {
            TakeDamage(dame);
            DamePopup.intance.ShowDame(true, gameObject.transform.position, dame);
            yield return new WaitForSeconds(1f);
            time -= 1f;  
        }
     
        ngonlua.SetActive(false);
        

    }
    IEnumerator HideHpBar()
    {
        yield return new WaitForSeconds(2f);

        if (currentHp > 0)
        {
            hpCanvas.SetActive(false);
        }
    }
    public void spawnCoin()
    {
        GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        coin.GetComponent<CoinPly>().setup(Gold);
    }    
    public void UnShowHp()
    {
        hpCanvas.SetActive(false);
    }    
    
}