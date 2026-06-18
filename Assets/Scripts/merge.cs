using UnityEngine;

public class merge : MonoBehaviour
{
    public static merge Instance;
    public int Dame;
    public GameObject prelafWizard;
    public int enemy;
    public int Count;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          
    }
    public void setup(int count,int dame)
    {
        Dame = dame;
        Count = count;
    }    
    private void OnTriggerEnter2D(Collider2D collision)
    {           

        if(collision.gameObject.layer==LayerMask.NameToLayer("Enemy_Body"))
        {
            enemy++;
            Heals heals = collision.gameObject.GetComponent<Heals>();
            
            if(enemy==Count)
            {

                heals.TakeDamage(Dame);
               
                Destroy(gameObject);
            }
            else
            {
                if (heals != null)
                {
                    heals.TakeDamage(Dame);
                    Destroy(gameObject,10f);
                }
            }
              
        }    
        if(collision.gameObject.layer==LayerMask.NameToLayer("Boss_Body"))
        {
            Heals_boss boss=collision.gameObject.GetComponent<Heals_boss>();
            if (boss != null)
            {
                boss.takedame(Dame);
                Destroy(gameObject);
            }
        } 
        if(collision.gameObject.layer==LayerMask.NameToLayer("Cong"))
        {
            HeathCong heath=collision.gameObject.GetComponent<HeathCong>(); 
            if(heath!=null)
            {
                heath.TakeDame(Dame);
                Destroy(gameObject);
            }    
        }    
    }
}
