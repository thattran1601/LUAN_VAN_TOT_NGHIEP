using UnityEngine;

public class MultiTargetAttack : MonoBehaviour
{
    public Transform TargetPosition;
    public float radius = 1f;
    public LayerMask soliderlayer;
    public int dame;

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
        foreach (Collider2D soliders in solider)
        {
            Heals_Linh heath = soliders.GetComponent<Heals_Linh>();

            if (heath != null)
            {
                heath.TakeDamage(dame);
            }    
        }    
        
    }    
}
