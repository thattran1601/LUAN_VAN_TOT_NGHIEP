using UnityEngine;

[CreateAssetMenu(fileName = "NewMapData", menuName = "Game/Map Data")]
public class MapData : ScriptableObject
{
    public int IdMap;
    public string NameMap;
    public int MaxWave;

    public GameObject[] Enemy;
    public Sprite[] IconEnemy;

    public GameObject Boss;
    public Sprite IconBoss;

    public GameObject Map;
    public WaveData[] wave;

    public Sprite Background;

    public AudioClip Audioclip;

    public RewardData[] Items;
    public int CoinMin;
    public int CoinMax;

}