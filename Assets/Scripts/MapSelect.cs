using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelect : MonoBehaviour
{
    public GameObject Wated;
    public GameObject Panel;
    void Start()
    {
        Panel.SetActive(false);
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
            if(GameData.UnitData.Count==0)
            {
                Panel.SetActive(true);
                return;
            }    
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
    public void ButtonOK()
    {
        Panel.SetActive(false);
    }    
}
