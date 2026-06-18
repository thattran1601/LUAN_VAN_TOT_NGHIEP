using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class IceExplosionEffect : MonoBehaviour
{
    public float delayExplode = 0.3f;
    public float damageRadius = 2.5f;
    public float damage = 50f;
    public float stunDuration = 2f;

    public LayerMask enemyLayer;    
    public LayerMask bosslayer;


    void Start()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(delayExplode);

       

        Collider2D[] enemies = Physics2D.OverlapCircleAll(
            transform.position,
            damageRadius,
            enemyLayer
        );
        Collider2D boss = Physics2D.OverlapCircle(transform.position, damageRadius, bosslayer);
        if(boss!=null)
        {
            Heals_boss heath = boss.GetComponent<Heals_boss>();
            heath.takedame(damage);
        }    

        foreach (Collider2D enemy in enemies)
        {
            Heals hp = enemy.GetComponent<Heals>();
           

            if (hp != null)
            {
                hp.TakeDamage(damage);
            }

            AI_Eenemy move = enemy.GetComponent<AI_Eenemy>();

            if (move != null)
            {
                move.StartStun(stunDuration);
            }
        }
        

        Destroy(gameObject, 0.2f);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
}