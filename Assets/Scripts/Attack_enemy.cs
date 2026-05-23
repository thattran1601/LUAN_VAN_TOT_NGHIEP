using UnityEngine;

public class Attack_enemy : MonoBehaviour
{
    public static Attack_enemy instance;
    public int dame;
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

        if (hits == null)
            return;
            Heals_Linh hp = hits.GetComponent<Heals_Linh>();
            if (hp != null)
            {
                hp.TakeDamage(dame);
            }
            Heals_Thanh hpThanh= hits.GetComponent<Heals_Thanh>();
            if (hpThanh != null)
            {
                hpThanh.takedame(damethanh);
            }    
        
        

    }
    public void Attack()
    {
        if (GameManager.instance.IsOver == true)
            return;


        GameObject fire = Instantiate(prelaffire, posion.position, Quaternion.identity);

        Rigidbody2D rb = fire.GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.left * speedFire;
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
