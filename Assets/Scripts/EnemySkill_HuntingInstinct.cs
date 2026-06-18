using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySkill_HuntingInstinct : MonoBehaviour
{
    int count;
    float dame;
    public SpriteRenderer spriteRenderer;
   
    void Start()
    {
       dame=Attack_enemy.instance.dame;
    }

    // Update is called once per frame
    void Update()
    {
        EnemySkill();
    }
    public void EnemySkill()
    {
        Heals heath = GetComponent<Heals>();
        if(heath.currentHp<=heath.maxHp/9)
        {
            if(count==0)
            {
                StartCoroutine(Enemyimmortal());

            }
        }    
    }    
    public IEnumerator Enemyimmortal()
    {
        count++;
        Heals heath = GetComponent<Heals>();
        Attack_enemy attack=GetComponent<Attack_enemy>();
        float Reduction = heath.damageReduction;
        float attackEnemy = attack.dame;
        attack.dame = dame * 3;
        

        Debug.Log(Reduction);
        heath.damageReduction = 0f;
        yield return new WaitForSeconds(2f);
        heath.damageReduction = Reduction;
        attack.dame= attackEnemy;
    }    
}
