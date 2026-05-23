using UnityEngine;

public class Fire : MonoBehaviour
{
    public int dameLinh;
    public int dameThanh;
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("Linh_Body"))
        {
          Heals_Linh linh=collision.GetComponent<Heals_Linh>();
            if(linh!=null)
            {
                linh.TakeDamage(dameLinh);
            }
            Destroy(gameObject);
        }  
        if(collision.gameObject.layer==LayerMask.NameToLayer("Thanh"))
        {
            Heals_Thanh.instance.takedame(dameLinh);
            Destroy(gameObject);
        }    
    }
}
