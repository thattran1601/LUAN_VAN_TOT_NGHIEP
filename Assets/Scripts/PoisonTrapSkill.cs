using UnityEngine;

[CreateAssetMenu(fileName = "PoisonTrapSkill", menuName = "Skills/PoisonTrapSkill")]
public class PoisonTrapSkill : SkillBase
{
    public GameObject IceExplosionPrefab;

    public override void Cast(Vector3 pos)
    {
        if (IceExplosionPrefab == null)
        {
            Debug.LogError("Chưa gán Tornado");
            return;
        }

        Instantiate(IceExplosionPrefab, pos, Quaternion.identity);
    }
}