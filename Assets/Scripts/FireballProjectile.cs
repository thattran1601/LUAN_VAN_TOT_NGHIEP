using System;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public float speed = 10f;

    public int damage = 50;

    public float damageRadius = 2f;

    public GameObject explosionPrefab;

    public Vector3 targetPosition;

    public void Setup(Vector3 target)
    {
        targetPosition = target;
    }

    void Update()
    {
        //transform.Rotate(
        //    0,
        //    0,
        //    300 * Time.deltaTime
        //);

        transform.position =
            Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );

        if (Vector3.Distance(
            transform.position,
            targetPosition) < 0.1f)
        {
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(
            explosionPrefab,
            transform.position,
            Quaternion.identity
        );

        Collider2D[] hits =
            Physics2D.OverlapCircleAll(
                transform.position,
                damageRadius
            );
        

        foreach (Collider2D hit in hits)
        {
            Heals enemy =
                hit.GetComponent<Heals>();
            Heals_boss Boss = hit.GetComponent<Heals_boss>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            if (Boss!=null)
            {
                Boss.takedame(damage);
            }    
        }
        

        Destroy(gameObject);
    }
}