using UnityEditor;
using UnityEngine;

public class SoliderAoeAttack : MonoBehaviour
{
    public int dame;
    public Transform targetPosition;
    public float radius = 1f;
    public LayerMask enemylayer;
    public LayerMask bosslayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DealAoeDame()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(targetPosition.position, radius, enemylayer);
        Collider2D[] boss = Physics2D.OverlapCircleAll(targetPosition.position, radius, bosslayer);
        if (UISetting.intance != null && UISetting.intance.isSetting)
            return;
        if(enemy!=null)
        {
            foreach(Collider2D c in enemy)
            {
                Heals heathEnemy=c.GetComponent<Heals>();
                heathEnemy.TakeDamage(dame);
            }    
        }   
        if(boss!=null)
        {
            foreach (Collider2D c in boss)
            {
                Heals_boss heathBoss=c.GetComponent<Heals_boss>();
                heathBoss.takedame(dame);
            }    
        }    
    }    
}
