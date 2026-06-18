using System;
using System.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class AI_Chuyen_Dong : MonoBehaviour
{
    public static AI_Chuyen_Dong instance;
    public float speed ;
    private Animator animator;
    public int IsEnemy;
    public Transform GioiHanChuyeDong;
    public bool IsStun;
    float speedNomal;
    public bool isTour;
    public bool IsSkill;
    public UnitRuntimeData runtimeData;
    public UnitData unitdata;
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
        if (GameManager.instance.IsOver || GameManager.instance.IsWin|| UISetting.intance.isSetting == true)
        {
            animator.speed = 0f;
            return;
        }
        
        animator.speed = 1f;
        if (transform.position.x>=GioiHanChuyeDong.position.x)
        {
            speed = 0f;
            //animator.SetBool("idel", true);

        }    
        ChuyenDong();
    }
    public void setup(UnitData unit)
    {
        unitdata = unit;
        CheckTreasure();
    }    
    void ChuyenDong()
    {
        if (IsStun == true)
            return;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    public void CheckTreasure()
    {
        runtimeData = UnitOwnedManager.Instance.GetRuntime(unitdata.Id);
        ItemData relic = InventoryManager.Instance.GetByIdItem(runtimeData.EquippedTreasureId);
       if(runtimeData==null)
        {
            Debug.Log(runtimeData.UnitId);
            return;
        }    
        if(relic==null)
        {
            Debug.Log(relic);
            return;
        }    
            IsSkill=false;
       if(relic.TreasureType==unitdata.UnitId)
        {
            IsSkill = true;
        }    
       
    }   
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy_Body"))
        {
          

            speed = 0f;
                IsEnemy++;
            if(IsSkill==true)
            {
                animator.SetBool("skill", true);
                animator.SetBool("attack", false);
            }
            else
            {//animator.SetBool("idel", false);
                animator.SetBool("attack", true);
                animator.SetBool("skill", false);
            }
                
              
              
            
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Boss_Body"))
        {
            speed = 0f;
            //animator.SetBool("idel", false);
            animator.SetBool("attack", true);
         
        }
        if(collision.gameObject.layer==LayerMask.NameToLayer("Cong"))
        {
            isTour = true;
            speed = 0f;
            animator.SetBool("attack", true);
        }    

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer ==LayerMask.NameToLayer("Enemy_Body"))
        {
            IsEnemy--;
            if(IsEnemy==0 && isTour==false)
            {
                if(IsSkill==true)
                {

                    animator.SetBool("skill",false);
                    animator.SetBool("attack",false);

                }
                else
                {
                   
                    animator.SetBool("attack", false);
                }
                speed = speedNomal;
            }    
            
           ;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Boss_Body"))
        {
            speed = speedNomal;
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
        DamePopup.intance.showtext("Stun", gameObject.transform.position);
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
            if (IsSkill)
                animator.SetBool("skill", true);
            else
                animator.SetBool("attack", true);
        }
    }
}
