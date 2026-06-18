using System.Collections;
using UnityEngine;

public class Skill_Magic_MeteorRain : SkillBase
{
    [Header("Meteor Rain")]
    public GameObject fireballEffect;
    public GameObject MagicCirle;

    public float rangerandom = 2f;
    public float hightSpawn = 6f;
    public int countSkill = 10;
    public float delay = 0.2f;

    public override void Cast(Vector3 centerpos)
    {
        StartCoroutine(MeteorRain(centerpos));
    }

    IEnumerator MeteorRain(Vector3 centerpos)
    {
        GameObject magic = null;

        if (MagicCirle != null)
            magic = Instantiate(MagicCirle, centerpos, Quaternion.identity);

        for (int i = 0; i < countSkill; i++)
        {
            CastMeteor(centerpos);
            yield return new WaitForSeconds(delay);
        }

        if (magic != null)
            Destroy(magic, 1f);
    }

    void CastMeteor(Vector3 centerpos)
    {
        float randomx = Random.Range(-rangerandom, rangerandom);

        Vector3 targetpos = new Vector3(centerpos.x - randomx, centerpos.y, 0);
        Vector3 spawn = new Vector3(targetpos.x, hightSpawn, 0);

        GameObject meteor = Instantiate(fireballEffect, spawn, Quaternion.identity);

        FireballProjectile fireball = meteor.GetComponent<FireballProjectile>();

        if (fireball != null)
            fireball.targetPosition = targetpos;
    }
}