using UnityEngine;

[CreateAssetMenu(fileName = "IceExplosionSkill", menuName = "Skills/Ice Explosion")]
public class IceExplosionSkill : SkillBase
{
    public GameObject IceExplosionPrefab;

    public override void Cast(Vector3 pos)
    {
        if (IceExplosionPrefab == null)
        {
            Debug.LogError("Chưa gán IceExplosionPrefab");
            return;
        }

        Instantiate(IceExplosionPrefab, pos, Quaternion.identity);
    }
}