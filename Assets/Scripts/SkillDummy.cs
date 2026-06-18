using UnityEngine;

public class SkillDummy : SkillBase
{
    public override void Cast(Vector3 position)
    {
        Attack[] attacks = FindObjectsOfType<Attack>();

        foreach (Attack attack in attacks)
        {
            attack.Buffattack();
        }
        KnockBack[] knockBack = FindObjectsOfType<KnockBack>();

        foreach (KnockBack attack in knockBack)
        {
            attack.Buffattack();
        }
        

        
    }
}