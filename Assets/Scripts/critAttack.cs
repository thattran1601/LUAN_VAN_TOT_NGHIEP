using UnityEngine;

public class critAttack : MonoBehaviour
{
    public float dame;
    public LayerMask soliderLayer;
    public LayerMask Thanhlayer;
    public Transform targetPosition;
    public float radius = 1f;
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
        Collider2D hits = Physics2D.OverlapCircle(targetPosition.position, radius, soliderLayer);

        if (hits == null)
            return;
        Heals_Linh hp = hits.GetComponent<Heals_Linh>();
        if (hp != null)
        {
            int rd = Random.Range(1, 100);
            if(rd<=30)
            {
                float dameDuring = dame * hp.damageReduction;
                hp.TakeDamage(dameDuring * 2);
                DamePopup.intance.show(true, hp.transform.position, dameDuring * 2);
                
            }
            else
            {
                float dameDuring = dame * hp.damageReduction;
                hp.TakeDamage(dameDuring);

            }
        }
        Collider2D heals = Physics2D.OverlapCircle(targetPosition.position, radius, Thanhlayer);
        if (heals !=null)
        {
            Heals_Thanh heath=heals.GetComponent<Heals_Thanh>();
            float dameReduction = dame * heath.DurigdamageReduction;
            heath.takedame(dameReduction);

        }    
       


    }
}
