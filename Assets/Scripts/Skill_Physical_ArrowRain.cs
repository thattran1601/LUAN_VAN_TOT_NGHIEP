using System.Collections;
using UnityEngine;

public class Skill_Phycical_ArrowRain : SkillBase
{
    [Header("Meteor Rain")]
    public GameObject Arroweffect;

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
       

        for (int i = 0; i < countSkill; i++)
        {
            CastMeteor(centerpos);
            yield return new WaitForSeconds(delay);
        }

       
    }

    void CastMeteor(Vector3 centerpos)
    {
        float randomx = Random.Range(-rangerandom, rangerandom);

        Vector3 targetpos = new Vector3(centerpos.x - randomx, centerpos.y, 0);
        Vector3 spawn = new Vector3(targetpos.x, hightSpawn, 0);

        GameObject meteor = Instantiate(Arroweffect, spawn, Quaternion.identity);
       ArrowEffect arrow = meteor.GetComponent<ArrowEffect>();

        if (arrow != null)
            arrow.target = targetpos;
    }
}