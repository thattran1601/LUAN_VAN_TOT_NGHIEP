using JetBrains.Annotations;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public Transform position;
    public int dame;
    public float radius = 1f;
    public LayerMask enemy;
    public LayerMask boss;
    public GameObject BuffAttack;
    private Coroutine hideCoroutine;
    public int damemove;


    void Start()
    {
        BuffAttack.SetActive(false);
        damemove = dame;


    }

    public void Buffattack()
    {
        BuffAttack.SetActive(true);
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }
        hideCoroutine = StartCoroutine(buff());
    }
    IEnumerator buff()
    {

        dame = dame * 2;
        yield return new WaitForSeconds(5f);
        BuffAttack.SetActive(false);
        dame = damemove;



    }
    void Update()
    {
        
    }
    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.layer==LayerMask.NameToLayer("Enemy_Body"))
    //    {
    //        Heals enemy= collision.gameObject.GetComponent<Heals>();
    //        if(enemy!=null)
    //        {   
    //            StartCoroutine(enemy.KnockBack());
    //        }    
    //    }    
    //}
    public void dealdame()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(position.position, radius);
        Collider2D[] boss = Physics2D.OverlapCircleAll(position.position, radius);
        foreach(Collider2D enemys in enemy)
        {
            Heals HealsEnemy=enemys.GetComponent<Heals>();
            if(HealsEnemy!=null)
            {
                int random = Random.Range(0, 100);
                if(random<=20)
                {
                    
                    StartCoroutine(HealsEnemy.KnockBack());
                }
                else
                {
                    HealsEnemy.TakeDamage(dame);
                }
               
            }    
        }  
        foreach(Collider2D bosss in boss)
        {
            Heals_boss heals_Boss=bosss.GetComponent<Heals_boss>();
            if(heals_Boss!=null)
            {
                heals_Boss.takedame(dame);
            }    
        }    
    }    
      
}
