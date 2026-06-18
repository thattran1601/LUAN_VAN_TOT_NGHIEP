using UnityEngine;

public class SkillKight : MonoBehaviour
{
    public int dameThieuDot;
    public Transform posionAttack;
    public float attackrange = 1f;
    public LayerMask Enemy;
    public LayerMask Boss;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void thieudot()
    {
        if (UISetting.intance != null && UISetting.intance.isSetting)
            return;
        Collider2D hitEnemies = Physics2D.OverlapCircle(posionAttack.position,attackrange, Enemy);


        if (hitEnemies != null)
        {
            Heals hp = hitEnemies.GetComponent<Heals>();

            if (hp != null)
            {
                int random = Random.Range(1, 100);
                Heals enemy = hp.GetComponent<Heals>();
                if (random < 100)
                {
                    enemy.NgonLuaSkill(dameThieuDot);

                }
                else
                {

                }
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
                
            }
            return;
        }

       
     
    }
}
