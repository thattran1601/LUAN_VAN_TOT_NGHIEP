using UnityEngine;

public class arrowEnemy : MonoBehaviour
{
    public int dame;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("Linh_Body"))
        {
            Heals_Linh health=collision.gameObject.GetComponent<Heals_Linh>();
            if(health!=null)
            {
                int random = Random.Range(1, 100);
                if(random<30)
                {
                    
                    health.TakeDamage(dame*2);
                    CameraShake.instance.camerashake(0.05f,0.08f);
                    DamePopup.intance.show(true, health.transform.position, dame * 2);
                    Destroy(gameObject);


                }
                else
                {
                    health.TakeDamage(dame);
                    Destroy(gameObject);
                }
            }
        }    
    }
}
