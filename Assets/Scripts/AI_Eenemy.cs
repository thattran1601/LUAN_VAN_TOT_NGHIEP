using Unity.VisualScripting;
using UnityEngine;

public class AI_Eenemy : MonoBehaviour
{
    public static AI_Eenemy Instance;
    public float speed = 2f;
    Animator animator;
    public int Hp_enemy = 100;
    private Heals enemy;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void Update()
    {

        if (GameManager.instance.IsOver)
            return;
        if (GameManager.instance.IsWin)
            return;
        if (UISetting.intance.isSetting == true)
            return;
        if (Heals.instance.isKnock == true)
            return;
        ChuyenDong();
    }
    public void ChuyenDong()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("Linh_Body"))
        {
            speed = 0f;
            animator.SetBool("attack", true);

        }    
        if(collision.gameObject.layer==LayerMask.NameToLayer("Thanh"))
        {
            WaveManager.instance.EnemyKilled();
            Destroy(gameObject);
         
        }    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer==LayerMask.NameToLayer("Linh_Body"))
        {
            speed = 2f;
            animator.SetBool("attack", false);
        }
    }
   
  
}
