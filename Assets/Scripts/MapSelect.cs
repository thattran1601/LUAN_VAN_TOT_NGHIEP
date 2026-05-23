using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelect : MonoBehaviour
{
    public GameObject Wated;
    void Start()
    {
        Wated.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mapselect(int mapselect)
    {
        int MapInt = SaveManager.instance.GetUnLockMap();
        if (mapselect <= MapInt)
        {
            GameData.MapInt = mapselect;
            SceneTransition.Instance.LoadSceneManager("GamePlay");
        } 
        else
        {
           Wated.SetActive(true);
        }    
            
      
    }   
    public void OK()
    {
        Wated.SetActive(false);
    }    
}
