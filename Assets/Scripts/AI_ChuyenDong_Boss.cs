using UnityEngine;

public class AI_ChuyenDong_Boss : MonoBehaviour
{
    public static AI_ChuyenDong_Boss Instance;
    public float speed = 2f;
    Animator animator;
    public bool isThanh;
    public bool islinh;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {

    }

    void Update()
    {
        if (GameManager.instance.IsOver || GameManager.instance.IsWin || UISetting.intance.isSetting == true)
        {
            animator.speed = 0f;
            return;
        }
        animator.speed = 1f;
        if (Heals_boss.instance.Isdieboss)
            return;
        ChuyenDong();
    }
    public void ChuyenDong()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Linh_Body"))
        {
            islinh = true;
            if (islinh == true)
            {
                speed = 0f;
                animator.SetBool("attack", true);
            }
            

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Thanh"))
        {
            isThanh = true;

            speed=0f;
            animator.SetBool("attack", true);
            

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isThanh)
            return;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Linh_Body"))
        {
            speed = 2f;
            animator.SetBool("attack", false);
            islinh= false;
        }
    }
}
