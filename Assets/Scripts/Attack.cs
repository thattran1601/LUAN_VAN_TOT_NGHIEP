using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public static Attack Instance;
    public int dame;
    public Transform posionAttack;
    public float attackrange = 1f;
    public LayerMask enemy;
    public LayerMask Boss;
    public LayerMask Conglayer;
    public GameObject BuffAttack;
    private Coroutine hideCoroutine;
    public int damemove;
    

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        BuffAttack.SetActive(false);
        damemove = dame;


    }

    public void Buffattack()
    {
        BuffAttack.SetActive(true);
        Debug.Log("Đã bật hiệu ứng BuffAttack");
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }
        hideCoroutine = StartCoroutine(buff());
    }
    IEnumerator buff()
    {

        dame = dame * 2;
        yield return new WaitForSeconds(5f);
        BuffAttack.SetActive(false);
        dame = damemove;



    }
    public void Dealdame()
    {
        if (UISetting.intance != null && UISetting.intance.isSetting)
            return;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            posionAttack.position,
            attackrange,
            enemy
        );
        Collider2D Cong = Physics2D.OverlapCircle
            (posionAttack.position, attackrange, Conglayer);
        //if (hitEnemies != null && Cong != null)
        //{
        //    if (hitEnemies.Length > 0)
        //    {
        //        Heals hp = hitEnemies[0].GetComponent<Heals>();

        //        if (hp != null)
        //        {
        //            float dameDuring = hp.damageReduction;
        //            hp.TakeDamage(dameDuring * dame);
        //            DamePopup.intance.show(true, hp.transform.position + Vector3.up * 2f, dameDuring * dame); ;
                   
        //        }
        //    }
        //    return;
        //}
            


        if (hitEnemies.Length > 0)
        {
            Heals hp = hitEnemies[0].GetComponent<Heals>();

            if (hp != null)
            {
                float dameDuring = hp.damageReduction;
                hp.TakeDamage(dameDuring*dame);
                DamePopup.intance.show(true,hp.transform.position+Vector3.up*2f, dameDuring * dame); ;
                return;
            }
        }

        Collider2D hitBoss = Physics2D.OverlapCircle(
            posionAttack.position,
            attackrange,
            Boss
        );

        if (hitBoss != null)
        {
            Heals_boss hpBoss = hitBoss.GetComponent<Heals_boss>();

            if (hpBoss != null)
            {
                hpBoss.takedame(dame);
            }
            return;
        }
       
        if (Cong != null)
        {
            HeathCong heath=Cong.GetComponent<HeathCong>();
            heath.TakeDame(dame);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (posionAttack == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(posionAttack.position, attackrange);
    }
}