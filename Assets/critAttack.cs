using UnityEngine;

public class critAttack : MonoBehaviour
{
    public int dame;
    public LayerMask soliderLayer;
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
                hp.TakeDamage(rd * 2);
                DamePopup.intance.show(true, hp.transform.position, dame * 2);
                
            }
            else
            {
                hp.TakeDamage(dame);

            }
        }
       


    }
}
