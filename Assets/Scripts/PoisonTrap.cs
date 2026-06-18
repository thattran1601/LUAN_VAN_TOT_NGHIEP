using System.Collections.Generic;
using UnityEngine;

public class PoisonTrap : MonoBehaviour
{
    public int dame;
    public float time;
    public float end;
    public float timer;
    public LayerMask enemy;
    public LayerMask boss;
    private HashSet<Collider2D> enemies = new HashSet<Collider2D>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,end);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer==LayerMask.NameToLayer("Enemy_Body"))
        {
            timer += Time.deltaTime;
            if (timer > time)
            {
                Heals hp = collision.GetComponent<Heals>();
                if (hp != null)
                {
                    hp.TakeDamage(dame);
                }
                timer = 0;
            }
        }    
        if (collision.gameObject.layer==LayerMask.NameToLayer("Boss_Body"))
        {
            timer += Time.deltaTime;
            if (timer > time)
            {
                Heals_boss hp = collision.GetComponent<Heals_boss>();
                if (hp != null)
                {
                    hp.takedame(dame);
                }
                timer = 0;
            }
        }    
            
        
        
    }
}
