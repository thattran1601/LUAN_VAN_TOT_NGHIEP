using UnityEngine;

public class MapDatabase : MonoBehaviour
{
    public static MapDatabase instance;
    public MapData[] maps;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public MapData GetById(int id)
    {
        foreach (var map in maps)
        {
            if(map.IdMap==id)
            {
                return map;
            }    
        }
        return null;
    }    
}
