using UnityEngine;
[System.Serializable]
public class WaveData 
{
    public EnemySpawnInfo[] enemyinfo;

    [Header("Set up Wave")]
    public float delayspawn = 1f;
    public bool isboss;
}
