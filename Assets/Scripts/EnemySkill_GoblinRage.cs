using Unity.VisualScripting;
using UnityEngine;

public class EnemySkill_GoblinRage : MonoBehaviour
{
    public int count=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count==0)
        {
            Skill();
           
        }    
        
    }
    public void Skill()
    {
        
        Heals enemy = GetComponent<Heals>();
        if(enemy.currentHp<=enemy.maxHp/2)
        {
            enemy.currentHp += 50;
            count++;
        }    
    }    
}
