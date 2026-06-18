
using UnityEngine;

public class ArrowEffect : MonoBehaviour
{
    public float speed;
    public float dame;
    public float dameRadius;
    public Vector3 target;
    public void setup(Vector3 position)
    {
        target = position;
    }    
    void Start()
    {
        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.down*speed*Time.deltaTime);
        if(transform.position.y<=target.y)
        {
            speed = 0f;
            return;
           
        }    
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("Enemy_Body"))
        {
            Heals heals = collision.gameObject.GetComponent<Heals>();
            if(heals!=null)
            {
                heals.TakeDamage(dame);
            }
        }  
        if(collision.gameObject.layer==LayerMask.NameToLayer("Boss_Body"))
        {
            Heals_boss heals = collision.gameObject.GetComponent<Heals_boss>();
            if(heals!=null)
            {
                heals.takedame(dame);
            }
        }    
    }

}
