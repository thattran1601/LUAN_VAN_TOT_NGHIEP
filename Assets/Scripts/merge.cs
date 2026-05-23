using UnityEngine;

public class merge : MonoBehaviour
{
    public int dame;
    public GameObject prelafWizard;
    public int enemy;
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
            Instantiate(prelafWizard,transform.position,Quaternion.identity);
            enemy++;
            Heals heals = collision.gameObject.GetComponent<Heals>();
            if(enemy>=3)
            {
                heals.TakeDamage(dame);
                Destroy(gameObject);
            }
            else
            {
                if (heals != null)
                {
                    heals.TakeDamage(dame);
                    Destroy(gameObject,10f);
                }
            }
              
        }    
        if(collision.gameObject.layer==LayerMask.NameToLayer("Boss_Body"))
        {
            Heals_boss boss=collision.gameObject.GetComponent<Heals_boss>();
            if (boss != null)
            {
                boss.takedame(dame);
                Destroy(gameObject);
            }
        }    
    }
}
