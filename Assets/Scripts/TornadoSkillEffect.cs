using UnityEngine;

[CreateAssetMenu(fileName = "TornadoSkill", menuName = "Skills/Tornado")]
public class TornadoSkillEffect : SkillBase
{
    public GameObject IceExplosionPrefab;
    public Transform target;
    public override void Cast(Vector3 pos)
    {
        if (IceExplosionPrefab == null)
        {
            Debug.LogError("Chưa gán Tornado");
            return;
        }

        Instantiate(IceExplosionPrefab, target.position, Quaternion.identity);
        StartCoroutine(CameraShake.instance.camerashake(0.5f,0.15f));
    }
}