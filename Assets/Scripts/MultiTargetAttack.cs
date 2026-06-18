using Unity.VisualScripting;
using UnityEngine;

public class MultiTargetAttack : MonoBehaviour
{
    public Transform TargetPosition;
    public float radius = 1f;
    public LayerMask soliderlayer;
    public LayerMask Thanhlayer;
    public int dame;
    public int dameThanh;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DealDame()
    {
        Collider2D[] solider = Physics2D.OverlapCircleAll(TargetPosition.position,radius, soliderlayer);
        Collider2D Thanh = Physics2D.OverlapCircle(TargetPosition.position, radius, Thanhlayer);
        foreach (Collider2D soliders in solider)
        {
            Heals_Linh heath = soliders.GetComponent<Heals_Linh>();

            if (heath != null)
            {
                float dameReduction = heath.damageReduction;
                heath.TakeDamage(dameReduction);
            }    
        }   
        if(Thanh!=null)
        {
            Heals_Thanh heaths=Thanh.GetComponent<Heals_Thanh>();
            float dameReduction = heaths.DurigdamageReduction;
            heaths.takedame(dameReduction);
        }    
        
        
    }    
}
