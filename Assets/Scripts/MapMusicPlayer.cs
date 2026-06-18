using UnityEngine;

public class MapMusicPlayer : MonoBehaviour
{
    public MapData[] mapdata;
    void Start()
    {
        int Id = GameData.MapInt;
        MapData currentmap = null;
        foreach (MapData data in mapdata)
        {
            if(data.IdMap==Id)
            {
                currentmap = data;
                break;

            }
        }    
        if(currentmap==null)
        {
            Debug.Log("khong co map");
        }    
        if(currentmap.Audioclip==null)
        {
            Debug.Log("khong co nhac");

        }
        AudioManager.instance.PlayBMG(currentmap.Audioclip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
