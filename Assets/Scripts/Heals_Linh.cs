using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Heals_Linh : MonoBehaviour
{
   
    [Header("HP")]
    public int maxHp = 100;
    private float currentHp;

    [Header("HP BAR")]
    public GameObject hpCanvas;
    public Image Hpfill;

    private Animator animator;
    private Coroutine hideCoroutine;

    private bool isDead = false;
    private SpriteRenderer sr;
    public float damageReduction = 0f;
    private void Awake()
    {
        
        animator = GetComponent<Animator>();
        sr= GetComponent<SpriteRenderer>();
        
    }

    private void Start()
    {
        currentHp = maxHp;

        hpCanvas.SetActive(false);

        UpdateBar();
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;
        float dame = damage * damageReduction;
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

    void Die()
    {
        if (isDead) return;

        isDead = true;

        animator.SetBool("die", true);

        // tắt collider
        Collider2D[] cols = GetComponents<Collider2D>();

        foreach (Collider2D col in cols)
        {
            col.enabled = false;
        }

        // dừng coroutine
        StopAllCoroutines();
        sr.color=Color.white;
        Destroy(gameObject, 1f);
    }

    void UpdateBar()
    {
        Hpfill.fillAmount = (float)currentHp / maxHp;
    }
    IEnumerator hit()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
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

    IEnumerator HideHpBar()
    {
        yield return new WaitForSeconds(2f);

        if (currentHp > 0)
        {
            hpCanvas.SetActive(false);
        }
    }
}
