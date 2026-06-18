using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Xml.Serialization;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    public static Spawn_Enemy Instance;
    public GameObject[] enemy;
    public Transform SpawnEnemy;
    public float Lasttime;
    public float cooldown = 1f;
    public int spawn ;
    public int SpawnQuality;
    public int Maxspawm =10;
    public bool isSpawning;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    public void startSpawn()
    {
        
          
        StartCoroutine(spawnEnemy());
    }    
    public IEnumerator spawnEnemy()
    {
        isSpawning = true;
        if (GameManager.instance.IsWin || BossManger.instance.IsBoss == true|| UISetting.intance.isSetting==true)
            yield break;
        
            WaveData currentWave = WaveManager.instance.currentmap.wave[WaveManager.instance.WaveCurrent - 1];
            List<GameObject> list = new List<GameObject>();
            foreach(EnemySpawnInfo enemy in currentWave.enemyinfo)
            {
                for(int i=0;i<enemy.count;i++)
            {
                list.Add(enemy.enemyprelaf);

            }
        }    

            for(int i=0; i<list.Count;i++)
            {
                int random = Random.Range(i, list.Count);
                GameObject enemy= list[i];
                list[i] = list[random];
                list[random] = enemy;
            }
            WaveManager.instance.EnemyQuantity = list.Count;
            WaveManager.instance.UpdateUIWave();
            
            foreach(GameObject enemy in list)
            {
                Instantiate(enemy, SpawnEnemy.position, Quaternion.identity);
                yield return new WaitForSeconds(currentWave.delayspawn);
            }    
        
        isSpawning=false;

    }    
}
