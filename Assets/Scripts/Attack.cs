using UnityEngine;

public class Attack : MonoBehaviour
{
    public int dame;
    public Transform posionAttack;
    public float attackrange = 1f;
    public LayerMask enemy;
    public LayerMask Boss;

    public void Dealdame()
    {
        if (UISetting.intance != null && UISetting.intance.isSetting)
            return;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            posionAttack.position,
            attackrange,
            enemy
        );

        if (hitEnemies.Length > 0)
        {
            Heals hp = hitEnemies[0].GetComponent<Heals>();

            if (hp != null)
            {
                hp.TakeDamage(dame);
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