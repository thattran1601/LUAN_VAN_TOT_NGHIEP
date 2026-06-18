using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float dame;
    public float radius;
    public Transform posionAttack;
    public LayerMask LinhLayer;
    public LayerMask ThanhLayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Dealdame()
    {
        Collider2D[] soliders = Physics2D.OverlapCircleAll(posionAttack.position,radius,LinhLayer);
        Collider2D Castles = Physics2D.OverlapCircle(posionAttack.position,radius,ThanhLayer);
        if(soliders != null)
        {
            foreach(Collider2D solider in soliders)
            {
                Heals_Linh heathsolider = solider.GetComponent<Heals_Linh>();
                heathsolider.TakeDamage(dame);
                DamePopup.intance.show(true, heathsolider.gameObject.transform.position, dame);

            }    
        }   
        if(Castles!=null)
        {
            Heals_Thanh heathcastle=Castles.GetComponent<Heals_Thanh>();
            heathcastle.takedame(dame);
        }    
    }    
    private void OnDrawGizmosSelected()
    {
        if (posionAttack == null)
            return;

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            posionAttack.position,
            radius
        );
    }
}
