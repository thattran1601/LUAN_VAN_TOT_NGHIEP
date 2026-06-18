using Unity.Jobs;
using UnityEngine;

public class HandSpeed : MonoBehaviour
{
    public float speed;
    Animator animator;
    public float dame=500f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime); 

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("Ground"))
        {
            animator.SetBool("hand", true);
            speed = 0f;
        }
        if(collision.gameObject.layer==LayerMask.NameToLayer("Linh_Body"))
        {
            Heals_Linh heals_Linh=collision.GetComponent<Heals_Linh>();
            if(heals_Linh!=null)
            {
                heals_Linh.TakeDamage(dame);
            }
        }
    }
    public void DestroyGameobject()
    {
        Destroy(gameObject);
    }    
}
