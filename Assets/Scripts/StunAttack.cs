using System.Collections;
using UnityEngine;

public class StunAttack : MonoBehaviour
{
    public static StunAttack Instance;
    public bool IsStun;
    public int dame;
    public Transform TargetPosition;
    public float radius = 1f;
    public LayerMask soliderLayer;


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeadDameStun()
    {
        Collider2D[] solider = Physics2D.OverlapCircleAll(TargetPosition.position, radius, soliderLayer);
        foreach (Collider2D col in solider)
        {
            Heals_Linh heath=col.GetComponent<Heals_Linh>();
            if (heath!=null)
            {
                int rd = Random.Range(1, 100);
                if(rd<=50)
                {
                    Debug.Log("choáng");
                
                    AI_Chuyen_Dong.instance.StartStun(1.5f);
                 
                    heath.TakeDamage(dame);
                }
                else
                {
                    heath.TakeDamage(dame);

                }
            }    
        }
    }
  

}
