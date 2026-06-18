using System.Xml.Serialization;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    [Header("Info")]
    public string Name;
    public Sprite icon;

    [Header("Cost")]
    public int mana;
    public float cooldown;

    [Header("TypeSkill")]
    public SkillTargetType type;
    [HideInInspector]
    public float currentCooldown;
   
    public bool IsRedy()
    {
        return currentCooldown <= 0;
    }
    public void StartCooldown()
    {
        currentCooldown = cooldown;
    }
    public void TickCooldown()
    {
        if (cooldown <= 0)
        {
            cooldown = 0;
        }
        if(cooldown>0)
        {
            currentCooldown-=Time.deltaTime;
        }    
    }    
    public abstract void Cast(Vector3 vector);
}
