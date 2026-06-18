using System.Collections;
using UnityEditor;
using UnityEngine;

public class SoliderAoeAttack : MonoBehaviour
{
    public int dame;
    public Transform targetPosition;
    public float radius = 1f;
    public LayerMask enemylayer;
    public LayerMask bosslayer;
    public LayerMask Conglayer;
    public GameObject BuffAttack;
    private Coroutine hideCoroutine;
    public int damemove;
    void Start()
    {
        BuffAttack.SetActive(false);
        Attack attack = GetComponent<Attack>();
        dame= attack.dame;
        damemove = dame;

    }
    //public void Buffattack()
    //{
    //    BuffAttack.SetActive(true);
    //    if (hideCoroutine != null)
    //    {
    //        StopCoroutine(hideCoroutine);
    //    }
    //    hideCoroutine = StartCoroutine(buff());
    //}
    //IEnumerator buff()
    //{
        
    //    dame = dame * 2;
    //    yield return new WaitForSeconds(5f);
    //    BuffAttack.SetActive(false);
    //    dame = damemove;



    //}
    // Update is called once per frame
    void Update()
    {
        
    }
    public void DealAoeDame()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(targetPosition.position, radius, enemylayer);
        Collider2D[] boss = Physics2D.OverlapCircleAll(targetPosition.position, radius, bosslayer);
        if (UISetting.intance != null && UISetting.intance.isSetting)
            return;
        if(enemy!=null)
        {
            foreach(Collider2D c in enemy)
            {
                Heals heathEnemy=c.GetComponent<Heals>();
                float dameDuring = dame * heathEnemy.damageReduction;
                heathEnemy.TakeDamage(dameDuring);
            }    
        }   
        if(boss!=null)
        {
            foreach (Collider2D c in boss)
            {
                Heals_boss heathBoss=c.GetComponent<Heals_boss>();
                heathBoss.takedame(dame);
            }    
        }
        Collider2D Cong = Physics2D.OverlapCircle(targetPosition.position, radius,Conglayer);
        if (Cong != null)
        {
            HeathCong heath = Cong.GetComponent<HeathCong>();
            heath.TakeDame(dame);
        }
    }    
}
