using UnityEngine;

public class Attack : MonoBehaviour
{
    public int dame;
    public Transform posionAttack;
    public float attackrange = 1f;
    public LayerMask enemy;
    public LayerMask Boss;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Dealdame()
    {
        if (UISetting.intance.isSetting == true)
            return;
        Collider2D hits = Physics2D.OverlapCircle(posionAttack.position, attackrange, enemy);
        Collider2D hitboss = Physics2D.OverlapCircle(posionAttack.position, attackrange, Boss);
        if (hits == null && hitboss == null)
            return;
            Heals hp=hits.GetComponent<Heals>();
            if(hp!=null)
            {
                hp.TakeDamage(dame);
            }    
        
      
            Heals_boss hpboss=hitboss.GetComponent<Heals_boss>();
            if(hp!=null)

            {
                hpboss.takedame(dame);
            }        
           

        

    }
    private void OnDrawGizmosSelected()
    {
        if (posionAttack == null)
            return;

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            posionAttack.position,
            attackrange
        );
    }
}
