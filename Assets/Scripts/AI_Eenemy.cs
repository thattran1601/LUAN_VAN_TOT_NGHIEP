using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine;

public class AI_Eenemy : MonoBehaviour
{
    public static AI_Eenemy Instance;
    public float speed = 2f;
    Animator animator;
    public int Hp_enemy = 100;
    public bool IsThanh;
    private Heals enemy;
    public float speedNomal;
    public bool IsStun;
    public bool IsKnock;
    Coroutine stunCoroutine;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        speedNomal = speed;
    }

    void Update()
    {

        if (GameManager.instance.IsOver || 
            GameManager.instance.IsWin || 
            UISetting.intance.isSetting == true||
            IsStun==true||
            IsKnock==true)
        {
            animator.speed = 0f;
            return;
        }
        animator.speed = 1f;

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
    public IEnumerator truSpeed(float movespeed)
    {
        speed -= movespeed;
        yield return new WaitForSeconds(2f);
        speed += movespeed;
    }
  

    public void StartStun(float stunTime)
    {
        if (stunCoroutine != null)
            StopCoroutine(stunCoroutine);

        stunCoroutine = StartCoroutine(Stun(stunTime));
    }

    public IEnumerator Stun(float stunTime)
    {
        Debug.Log("Bắt đầu stun: " + stunTime);

        IsStun = true;

        if (speedNomal <= 0)
            speedNomal = speed;

        speed = 0;

        animator.SetBool("attack", false);
        animator.speed = 0f;

        if (DamePopup.intance != null)
            DamePopup.intance.showtext("Stun", transform.position);

        yield return new WaitForSeconds(stunTime);

        IsStun = false;

        animator.speed = 1f;
        speed = speedNomal;

        stunCoroutine = null;

        Debug.Log("Hết stun, speed = " + speed);
    }
    public IEnumerator KnockUp(float height, float during)
    {
        IsKnock = true;
        Vector3 start = transform.position;
        Vector3 end = start + Vector3.up * height;
        float time = 0;
        while(time<during)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, time / during);
            yield return null;
        }
        time = 0;
        while(time<during)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(end, start, time / during);
            yield return null;
        }    
        IsKnock=false;
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
            IsThanh = true;
            speed = 0f;
            animator.SetBool("attack", true);

        }    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer==LayerMask.NameToLayer("Linh_Body"))
        {
            if (IsThanh == true)
                return;

            speed = speedNomal;
            animator.SetBool("attack", false);
        }
        if(collision.gameObject.layer==LayerMask.NameToLayer("Thanh"))
        {
            IsThanh = false;
            speed = speedNomal;
            animator.SetBool("attack", false);
        }    
    }
   
  
}
