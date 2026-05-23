using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;

public class MuiTen : MonoBehaviour
{
    public float dame;
    public int XuyenGiap;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("Enemy_Body"))
        {
           Heals enemy=collision.gameObject.GetComponent<Heals>();
            if(enemy!=null)
            {
                if(enemy.hasShield==true)
                {
                    Destroy(gameObject);
                }
                else
                {
                    int random = Random.Range(1, 100);
                    Debug.Log(random);
                    if (random < 20)
                    {
                        float dameHientai = dame * enemy.damageReduction;
                        enemy.TakeDamage(dameHientai * 2);
                        CameraShake.instance.camerashake(0.05f, 0.08f);

                        DamePopup.intance.show(true, enemy.transform.position + Vector3.up, dameHientai * 2);
                        ;
                    }
                    else
                    {
                        float dameHientai = dame * enemy.damageReduction;
                        enemy.TakeDamage(dame);
                    }

                }


            }
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Boss_Body"))
        {
            Heals_boss boss = collision.gameObject.GetComponent<Heals_boss>();
            if (boss != null)
            {
                boss.takedame(dame);
            }
            Destroy(gameObject);

        }
    }
}
