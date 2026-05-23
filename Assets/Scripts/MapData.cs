using UnityEngine;

[CreateAssetMenu(fileName = "NewMapData", menuName = "Game/Map Data")]

public class MapData : ScriptableObject
{
    public int IdMap;
    public string NameMap;
    public int MaxWave;
    public GameObject[] Enemy;
    public GameObject Boss;
    public GameObject Background;
    public WaveData[] wave;
    

}
