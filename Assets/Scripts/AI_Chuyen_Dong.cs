using System;
using System.Collections;
using UnityEngine;

public class AI_Chuyen_Dong : MonoBehaviour
{
    public static AI_Chuyen_Dong instance;
    public float speed ;
    private Animator animator;
    public int IsEnemy;
    public Transform GioiHanChuyeDong;
    public bool IsStun;
    float speedNomal;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        instance = this;
    }
    void Start()
    {
         speedNomal = speed;
        GioiHanChuyeDong = ManagerLimit.instance.GioiHanChuyenDong;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.IsOver)
            return;
        if (GameManager.instance.IsWin)
            return;
        if (UISetting.intance.isSetting == true)
            return;
        if (transform.position.x>=GioiHanChuyeDong.position.x)
        {
            speed = 0f;
            //animator.SetBool("idel", true);

        }    
        ChuyenDong();
    }
    void ChuyenDong()
    {
        if (IsStun == true)
            return;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy_Body"))
        {
          

            speed = 0f;
                IsEnemy++;
                //animator.SetBool("idel", false);
                animator.SetBool("attack", true);
              
              
            
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Boss_Body"))
        {
            speed = 0f;
            //animator.SetBool("idel", false);
            animator.SetBool("attack", true);
         
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer ==LayerMask.NameToLayer("Enemy_Body"))
        {
            IsEnemy--;
            if(IsEnemy==0)
            {
                speed = 2f;
                animator.SetBool("attack", false);
            }    
            
           ;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Boss_Body"))
        {
            speed = 2f;
            animator.SetBool("attack", false);
        }
    }
    public void StartStun(float time)
    {
        StartCoroutine(stun(time));
    }    
    IEnumerator stun(float stuntime)
    {
        IsStun = true;
        speed = 0;
        animator.SetBool("attack", false);
        animator.speed = 0;
        yield return new WaitForSeconds(stuntime);
        IsStun = false;
        animator.speed = 1f;
        if(IsEnemy<=0)
        {
            speed = speedNomal;

        }
        else
        {
            animator.SetBool("attack", true);
        }
    }
}
