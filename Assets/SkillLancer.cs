using UnityEngine;

public class SkillLancer : MonoBehaviour
{
    public int dame;
    public Transform posionAttack;
    public float attackrange = 2f;
    public LayerMask enemy;
    public LayerMask Boss;
    public LayerMask Conglayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DealDame()
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
  


        if (hitEnemies.Length > 0)
        {
            Heals hp = hitEnemies[0].GetComponent<Heals>();

            if (hp != null)
            {
                int random = Random.Range(0,100);
                if(random<10)
                {
                    dame = Attack.Instance.dame * 3;
                }
                else if(random>10 && random<30)
                {
                    dame=Attack.Instance.dame*2;
                }
                else
                {
                    dame = Attack.Instance.dame;
                }
                float dameDuring = hp.damageReduction;
                hp.TakeDamage(dameDuring * dame);
                DamePopup.intance.show(true, hp.transform.position + Vector3.up * 2f, dameDuring * dame); ;
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
            int random = Random.Range(0, 100);
            if (random < 10)
            {
                dame = Attack.Instance.dame * 3;
            }
            else if (random > 10 && random < 30)
            {
                dame = Attack.Instance.dame * 2;
            }
            else
            {
                dame = Attack.Instance.dame;
            }
            Heals_boss hpBoss = hitBoss.GetComponent<Heals_boss>();

            if (hpBoss != null)
            {
                hpBoss.takedame(dame);
            }
            return;
        }

        if (Cong != null)
        {
            HeathCong heath = Cong.GetComponent<HeathCong>();
            heath.TakeDame(Attack.Instance.dame);
        }
    }
}
