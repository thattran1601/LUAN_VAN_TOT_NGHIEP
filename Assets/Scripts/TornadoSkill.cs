using System.Data;
using UnityEngine;

public class TornadoSkill : MonoBehaviour
{

    public int dame;
    public float hieght;
    public float during;
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("Enemy_Body"))
        {
            Heals heath = collision.gameObject.GetComponent<Heals>();
            if(heath != null)
            {
                heath.TakeDamage(dame);
                AI_Eenemy aI_Eenemy=collision.gameObject.GetComponent<AI_Eenemy>();
                StartCoroutine(aI_Eenemy.KnockUp(hieght, during));
            }
        }
        if(collision.gameObject.layer==LayerMask.NameToLayer("Boss_Body"))
        {
            Heals_boss heathboss=collision.gameObject.GetComponent<Heals_boss>();   
            if (heathboss != null)
            {
                heathboss.takedame(dame);
            }

        }
        if(collision.gameObject.layer==LayerMask.NameToLayer("Cong"))
        {
            Destroy(gameObject);
        }    
    }
}
