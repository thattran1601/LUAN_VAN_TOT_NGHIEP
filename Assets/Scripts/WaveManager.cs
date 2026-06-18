
using System.Collections;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public int WaveCurrent=1;
    public TextMeshProUGUI WaveText;
    public int EnemyQuantity;
    public TextMeshProUGUI EnemyText;
    public float Time;
    public int WaveMax;
    public bool IsBoss;
    public MapData currentmap;
    public SpriteRenderer bcrMap;
    public bool isChangingWave;
    public TextMeshProUGUI NextWaveInfo;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentmap = MapDatabase.instance.GetById(GameData.MapInt);

        WaveMax = currentmap.wave.Length;
        
        BossManger.instance.PrelafBoss = currentmap.Boss;
        Instantiate(currentmap.Map, Vector3.zero, Quaternion.identity);
        startWave();
    }


  
    public void startWave()
    {
        EnemyQuantity = 0;
        WaveData wave = currentmap.wave[WaveCurrent -1];
        foreach(EnemySpawnInfo info in wave.enemyinfo)
        {
            EnemyQuantity += info.count;
        }
        Debug.Log("so quai cua wave" + EnemyQuantity);
        UpdateUIWave();
        if(wave.isboss)
        {
            IsBoss = true;
            BossManger.instance.spawnBoss();
        }
        else
        {
            IsBoss = false;
            Spawn_Enemy.Instance.startSpawn();
        }
        
    }    
    public void UpdateUIWave()
    {
       
        WaveText.text = "WAVE :" + WaveCurrent + "/" + WaveMax;
        EnemyText.text = "ENEMY QUANLITY : " + EnemyQuantity;
        UpdateNextWave();
       
    }   
    public void UpdateNextWave()
    {
        int Wave=WaveCurrent;
        if(Wave>=currentmap.wave.Length)
        {
            NextWaveInfo.text = "NEXT: NONE";
            return;
        }    
        WaveData enemy = currentmap.wave[Wave];
        if(enemy.isboss)
        {
            NextWaveInfo.text = "NEXT: BOSS";
            return;
        }
        string text = "NEXT :";
        foreach(EnemySpawnInfo e in enemy.enemyinfo)
        {
            text += e.enemyprelaf.name + " X" + e.count+" ";
        }
        NextWaveInfo.text = text;


    }    
    public void EnemyKilled()
    {
        EnemyQuantity--;
        UpdateUIWave();
        if(EnemyQuantity<=0 && !isChangingWave)
        {
            if(WaveCurrent>=WaveMax)
            {
                GameManager.instance.victory();
                return;
            }    
            isChangingWave = true;
            StartCoroutine(NextWave());
        }
       
    }    
    public IEnumerator NextWave()
    {

        yield return new WaitForSeconds(Time);
        WaveCurrent++;
        GoldManager.instance.CurrentGold += 20;
        GoldManager.instance.UpdateGoldUI();
        StartCoroutine(wavePopup.Intance.wavepopup(WaveCurrent));
        isChangingWave = false;
        startWave();
    }    
}
