using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;

public class MuiTen : MonoBehaviour
{
    public static MuiTen Instance;
    public float dame;
    public int XuyenGiap;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        dame = Attack.Instance.dame;
      
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
                    DamePopup.intance.showtext("Block",enemy.transform.position);
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
        if(collision.gameObject.layer==LayerMask.NameToLayer("Cong"))
        {
            HeathCong heath=collision.gameObject.GetComponent<HeathCong>();
            if(heath !=null)
            {
                heath.TakeDame(dame);
                Destroy(gameObject);
            }    
        }    
    }
}
