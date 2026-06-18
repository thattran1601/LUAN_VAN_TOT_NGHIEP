using UnityEngine;

public class Attack_enemy : MonoBehaviour
{
    public static Attack_enemy instance;
    public float dame;
    public Transform posionAttack;
    public float attackrange = 1f;
    public LayerMask enemy;
    public LayerMask Thanh;
    public int damethanh;
    public GameObject prelaffire;
    public Transform posion;
    public float speedFire = 10f;
    private void Awake()
    {
        instance = this;
        posion = transform.Find("attackPosition");
    }
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
        Collider2D hitthanh = Physics2D.OverlapCircle(posionAttack.position, attackrange, Thanh);

        if (hits !=null)
        {
            Heals_Linh hp = hits.GetComponent<Heals_Linh>();
            if (hp != null)
            {
                float dameReduction = dame * hp.damageReduction;
                hp.TakeDamage(dameReduction);
            }
            return;
        }    
           
        
         
        if (hitthanh != null)
        {
            Heals_Thanh hpThanh = hitthanh.GetComponent<Heals_Thanh>();
            Debug.Log(hpThanh);
            if (hpThanh != null)
            {
                float dameReduction = damethanh * hpThanh.DurigdamageReduction;
                hpThanh.takedame(dameReduction);
            }
            return;

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
